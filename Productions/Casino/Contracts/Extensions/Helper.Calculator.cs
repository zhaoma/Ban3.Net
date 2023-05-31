using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Indicators.Outputs;
using Ban3.Productions.Casino.Contracts.Entities;
using Ban3.Productions.Casino.Contracts.Enums;
using Ban3.Productions.Casino.Contracts.Interfaces;
using Ban3.Sites.ViaTushare.Entries;

namespace Ban3.Productions.Casino.Contracts.Extensions;

public static partial class Helper
{
    public static List<StockSeed> CalculateSeeds(this ICalculator _, List<StockPrice> prices, List<StockEvent> events)
    {
        var result = new List<StockSeed>();
        try
        {
            if (events.Any())
            {
                foreach (var e in events)
                {
                    var price = prices.Last(o => o.TradeDate.ToDateTimeEx() < e.MarkTime);
                    {
                        var close = (decimal)price.Close;

                        var thisSeed =
                            Math.Round(
                                close * (1 + (Math.Round(e.Sbonus, 0) + Math.Round(e.Zbonus, 0)) / 10M +
                                         Math.Round(e.Pbonus, 0) / 10M) / (close - e.Xmoney / 10M +
                                                                           Math.Round(e.Pbonus, 0) / 10M *
                                                                           Math.Round(e.Pprice, 2)), 4);

                        result.Add(new StockSeed { MarkTime = e.MarkTime, Seed = (float)thisSeed });
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }

        return result;
    }

    public static List<StockSeed> LoadSeeds(this ICalculator _, string symbol)
        => typeof(StockSeed)
            .LocalFile(symbol)
            .ReadFileAs<List<StockSeed>>();

    public static bool ReinstatePrices(
        this ICalculator _,
        string code,
        string symbol,
        List<StockPrice> prices)
    {
        var seeds = _.LoadSeeds(symbol);
        var newPrices = prices.Select(seeds.ReinstateOnePrice)
            .ToList();

        var savedDaily = newPrices.SetsFile($"{code}.{StockAnalysisCycle.DAILY}")
            .WriteFile(newPrices.ObjToJson());

        var weeklyPrices = newPrices.ConvertCycle(StockAnalysisCycle.WEEKLY);
        var savedWeekly = weeklyPrices.SetsFile($"{code}.{StockAnalysisCycle.WEEKLY}")
            .WriteFile(weeklyPrices.ObjToJson());

        var monthlyPrices = newPrices.ConvertCycle(StockAnalysisCycle.MONTHLY);
        var savedMonthly = monthlyPrices.SetsFile($"{code}.{StockAnalysisCycle.MONTHLY}")
            .WriteFile(monthlyPrices.ObjToJson());

        return !string.IsNullOrEmpty(savedDaily)
               && !string.IsNullOrEmpty(savedWeekly)
               && !string.IsNullOrEmpty(savedMonthly);
    }

    static StockPrice ReinstateOnePrice(this List<StockSeed> seeds, StockPrice price)
    {
        var newPrice = new StockPrice
        {
            Code = price.Code,
            TradeDate = price.TradeDate,
            Change = price.Change,
            ChangePercent = price.ChangePercent,
            Vol = price.Vol,
            Amount = price.Amount
        };

        try
        {
            foreach (var s in seeds)
            {
                if (s.MarkTime.Subtract(price.TradeDate.ToDateTimeEx()).TotalDays > 0)
                {
                    newPrice.Open = (float)Math.Round(price.Open / s.Seed, 2);
                    newPrice.High = (float)Math.Round(price.High / s.Seed, 2);
                    newPrice.Low = (float)Math.Round(price.Low / s.Seed, 2);
                    newPrice.Close = (float)Math.Round(price.Close / s.Seed, 2);
                    newPrice.PreClose = (float)Math.Round(price.PreClose / s.Seed, 2);
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }

        return newPrice;
    }

    public static List<StockPrice> LoadReinstatedPrices(this ICalculator _, string code, StockAnalysisCycle cycle)
        => typeof(StockPrice)
            .LocalFile($"{code}.{cycle}")
            .ReadFileAs<List<StockPrice>>();

    public static bool GenerateIndicatorLine(this ICalculator _, string code)
    {
        return _.GenerateIndicatorLine(code, StockAnalysisCycle.DAILY)
               && _.GenerateIndicatorLine(code, StockAnalysisCycle.WEEKLY)
               && _.GenerateIndicatorLine(code, StockAnalysisCycle.MONTHLY);
    }

    public static bool GenerateIndicatorLine(this ICalculator _, string code, StockAnalysisCycle cycle)
    {
        var prices = _.LoadReinstatedPrices(code, cycle);

        var inputsPrices = prices.Select(o => new Infrastructures.Indicators.Inputs.Price
        {
            MarkTime = o.TradeDate.ToDateTimeEx(),
            CloseBefore = (decimal)o.PreClose,
            CurrentOpen = (decimal)o.Open,
            CurrentClose = (decimal)o.Close,
            CurrentHigh = (decimal)o.High,
            CurrentLow = (decimal)o.Low,
            Volume = (decimal)o.Vol,
            Amount = (decimal)o.Amount
        }).ToList();

        var indicator = new Infrastructures.Indicators.Formulas.Full();
        indicator.Calculate(inputsPrices);

        var line = indicator.Result;
        var saved = typeof(LineOfPoint)
            .LocalFile($"{code}.{cycle}")
            .WriteFile(line.ObjToJson());
        return !string.IsNullOrEmpty(saved);
    }

    public static LineOfPoint LoadIndicatorLine(this ICalculator _, string code, StockAnalysisCycle cycle)
        => typeof(LineOfPoint)
            .LocalFile($"{code}.{cycle}")
            .ReadFileAs<LineOfPoint>();
}