using System;
using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Indicators.Entries;
using Ban3.Infrastructures.Indicators.Outputs;
using Ban3.Productions.Casino.Contracts.Entities;
using Ban3.Productions.Casino.Contracts.Enums;
using Ban3.Productions.Casino.Contracts.Interfaces;
using Ban3.Sites.ViaTushare.Entries;

namespace Ban3.Productions.Casino.Contracts.Extensions;

public static partial class Helper
{
    #region 计算/加载复权因子

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


    #endregion

    #region 计算/加载复权价格

    public static bool ReinstatePrices(
        this ICalculator _,
        string code,
        string symbol,
        List<StockPrice> prices)
    {
        if (prices == null || !prices.Any()) return false;

        var seeds = _.LoadSeeds(symbol);

        // if (seeds == null || !seeds.Any()) return false;

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
            Amount = price.Amount,

            Open = price.Open,
            High = price.High,
            Low = price.Low,
            Close = price.Close,
            PreClose = price.PreClose
        };

        try
        {
            if (seeds != null && seeds.Any())
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

    #endregion

    #region 计算/加载指标曲线 

    public static bool GenerateIndicatorLine(this ICalculator _, string code)
    {
        return _.GenerateIndicatorLine(code, StockAnalysisCycle.DAILY)
               && _.GenerateIndicatorLine(code, StockAnalysisCycle.WEEKLY)
               && _.GenerateIndicatorLine(code, StockAnalysisCycle.MONTHLY);
    }

    public static bool GenerateIndicatorLine(this ICalculator _, string code, StockAnalysisCycle cycle)
    {
        var prices = _.LoadReinstatedPrices(code, cycle);
        if (prices == null || !prices.Any()) return false;

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


    /// <summary>
    /// 指标值线转换点
    /// </summary>
    /// <param name="line"></param>
    /// <returns></returns>
    public static List<Latest> LatestList(this LineOfPoint line)
    {
        if (line is { EndPoints: { } } && !line.EndPoints.Any()) return null;

        var list = line?.EndPoints?.Select(o => new Latest
        {
            Current = o
        }).ToList();

        for (var i = 1; i < list?.Count; i++)
        {
            list[i].Prev = list[i - 1].Current;
        }

        return list;
    }

    #endregion

    #region 计算/加载特征集合

    /// <summary>
    /// 指标特征集合并日/周/月指标特征集
    /// </summary>
    /// <param name="sets"></param>
    /// <param name="indicatorValue"></param>
    /// <param name="cycle"></param>
    /// <returns></returns>
    static List<StockSets> Merge(
        this List<StockSets> sets,
        LineOfPoint indicatorValue,
        StockAnalysisCycle cycle)
    {
        var latestList = indicatorValue
            .LatestList();

        if (latestList == null || !latestList.Any()) return sets;

        var setsList = latestList
            .Select(o => (o.Current!.MarkTime, o.Features()))
            .ToList();

        sets.ForEach(o =>
        {
            var ss = setsList.FindLast(x => x.MarkTime.Subtract(o.MarkTime).TotalDays >= 0);
            if (ss.Item2 != null && ss.Item2.Any())
                o.SetKeys = o.SetKeys?.Union(ss.Item2.Select(y => $"{y}.{cycle}"));
        });

        return sets;
    }

    static List<StockSets> Merge(
        this ICalculator _, List<StockSets> sets,string code, StockAnalysisCycle cycle)
    {
        return sets.Merge(_.LoadIndicatorLine(code, cycle), cycle);
    }

    static List<StockSets> Merge(
        this ICalculator _, List<StockSets> sets, string code)
    {
        sets = _.Merge(sets, code, StockAnalysisCycle.DAILY);
        sets = _.Merge(sets, code, StockAnalysisCycle.WEEKLY);
        sets = _.Merge(sets, code, StockAnalysisCycle.MONTHLY);

        return sets;
    }

    public static bool PrepareSets(
        this ICalculator _,
        Stock stock,
        out List<StockSets> sets)
    {
        try
        {
            var prices = _.LoadReinstatedPrices(stock.Code, StockAnalysisCycle.DAILY);
            if (prices != null && prices.Any())
            {
                sets = prices.Select(o => new StockSets
                {
                    Close = (decimal)o.Close,
                    MarkTime = o.TradeDate.ToDateTimeEx(),
                    Code = stock.Code,
                    Symbol = stock.Symbol,
                    SetKeys = new List<string>()
                }).ToList();

                sets = _.Merge(sets, stock.Code);

                var saved = $"{stock.Code}"
                    .DataFile<StockSets>()
                    .WriteFile(sets.ObjToJson());

                return !string.IsNullOrEmpty(saved);
            }
        }catch(Exception ex){Logger.Error(ex);}

        sets = new List<StockSets>();
        return false;
    }

    public static List<StockSets> LoadSets(this ICalculator _, string code)
        => code
            .DataFile<StockSets>()
            .ReadFileAs<List<StockSets>>();

    #endregion

    #region 计算/加载个股榜单

    /// <summary>
    /// 指标特征集转换榜单
    /// </summary>
    /// <param name="stockSets"></param>
    /// <param name="listName"></param>
    /// <returns></returns>
    public static bool GenerateList(this List<StockSets> stockSets, string listName)
    {
        var result = stockSets
            .Where(o => o.SetKeys != null && o.SetKeys.Any())
            .Select(o => new ListRecord(o))
            .OrderByDescending(o => o.Value)
            .ToList();

        var rank = 1;
        int? prev = null;
        foreach (var r in result)
        {
            if (prev == null || r.Value == prev.Value)
            {
                r.Rank = rank;
            }
            else
            {
                rank++;
            }

            prev = r.Value;
        }

        var saved = listName
            .DataFile<ListRecord>()
            .WriteFile(result.ObjToJson());

        return !string.IsNullOrEmpty(saved);
    }

    public static List<ListRecord> LoadList(this ICalculator _, string listName)
        => listName
            .DataFile<ListRecord>()
            .ReadFileAs<List<ListRecord>>();

    #endregion
}