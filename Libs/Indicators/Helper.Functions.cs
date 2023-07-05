/* -------------------------------------------------------------------------------------------------
   Copyright (C) Siemens Healthcare GmbH 2023, All rights reserved. Restricted.
   ------------------------------------------------------------------------------------------------- */
   
using Ban3.Infrastructures.Indicators.Outputs;
using System.Collections.Generic;
using System;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Indicators.Enums;
using Ban3.Infrastructures.Indicators.Inputs;
using System.Linq;

namespace Ban3.Infrastructures.Indicators;

public static partial class Helper
{
    /// <summary>
    /// 是否升序
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="numbers"></param>
    /// <param name="toDecimal"></param>
    /// <returns></returns>
    public static bool IsAsc<T>(this List<T>? numbers, Func<T, double> toDecimal)
    {
        if (numbers is not { Count: > 1 }) return true;

        for (var i = 1; i < numbers.Count; i++)
        {
            if (toDecimal(numbers[i - 1]) > toDecimal(numbers[i]))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// 评估特征计分
    /// </summary>
    /// <param name="features"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public static int Evaluation(this List<string> features, out List<string> result)
    {
        result = new List<string>();
        var value = 0;

        foreach (var f in features)
        {
            if (!AllFeatures.TryGetValue(f, out var sf)) continue;
            value += sf.Value;
            result.Add($"{sf.Subject}:[{sf.Value}]");
        }

        return value;
    }

    /// <summary>
    /// 评估特征计分
    /// </summary>
    /// <param name="sets"></param>
    /// <param name="result"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool Evaluation(this StockSets sets, out List<string> result, out int value)
    {
        result = new List<string>();
        value = 0;
        try
        {
            if (sets.SetKeys != null)
            {
                foreach (var set in sets.SetKeys)
                {
                    if (!AllFeatures.TryGetValue(set, out var sf)) continue;
                    value += sf.Value;
                    result.Add(sf.Subject);
                }
            }

            return true;
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }

        return false;
    }

    public static bool SplitAmount(this List<Price> prices, int days, out List<Price> amounts)
    {
        amounts = new List<Price>();

        for (var index = 0; index < prices.Count; index++)
        {
            var tmpArray = prices.AmountRange(index, days);

            var one = new Price
            {
                Code = prices[index].Code,
                TradeDate = prices[index].TradeDate,
                Open = tmpArray.First(),
                Close = tmpArray.Last(),
                High = tmpArray.Max(),
                Low = tmpArray.Min()
            };

            if (amounts.Count > 1)
                one.PreClose = amounts[amounts.Count - 1].Close;

            amounts.Add(one);
        }

        return false;
    }

    static List<double> AmountRange(this List<Price> prices, int index, int days)
    {
        var start = index;
        var end = Math.Max(start - days, 0);

        var result = new List<double>();
        for (int r = start; r > end; r--)
        {
            result.Add(prices[r].Amount!.Value);
        }

        return result;
    }

    /// <summary>
    /// 价格日行情转周、月行情(每日)
    /// </summary>
    /// <param name="prices"></param>
    /// <param name="weekly"></param>
    /// <param name="monthly"></param>
    /// <returns></returns>
    public static bool SplitWeeklyAndMonthly(this List<Price> prices, out List<Price> weekly, out List<Price> monthly)
    {
        weekly = new List<Price>();
        monthly = new List<Price>();
        try
        {
            for (var i = 1; i <= prices.Count; i++)
            {
                weekly.AppendLatest(prices[i - 1], StockAnalysisCycle.WEEKLY);
                monthly.AppendLatest(prices[i - 1], StockAnalysisCycle.MONTHLY);
            }

            return true;
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }

        return false;
    }

    static void AppendLatest(
        this List<Price> prices,
        Price price,
        StockAnalysisCycle cycle)
    {
        if (!prices.Any())
        {
            prices.Add(price);
        }
        else
        {
            var lastRecord = prices.Last();

            var exists = lastRecord.TradeDate.End(cycle).ToYmd();
            var add = price.TradeDate.End(cycle).ToYmd();
            if (exists.ToInt().Equals(add.ToInt()))
            {
                var p = new Price
                {
                    //    Code = price.Code,
                    //    TradeDate = price.TradeDate,
                    //    Open = price.Open,
                    //    High = Math.Max(lastRecord.High, price.High),
                    //    Low = Math.Min(lastRecord.Low, price.Low),
                    //    Close = price.Close,
                    //    PreClose = price.PreClose,
                    //    Vol = lastRecord.Vol + price.Vol,
                    //    Amount = lastRecord.Amount + price.Amount
                };
                //p.Change = p.Close - p.PreClose;
                //p.ChangePercent = p.PreClose != 0
                //    ? (float)Math.Round((p.Close - p.PreClose) / p.PreClose * 100, 2)
                //    : 0F;

                prices.Add(p);
            }
            else
            {
                prices.Add(price);
            }
        }
    }

    static DateTime End(this DateTime begin, StockAnalysisCycle targetCycle)
    {
        return targetCycle == StockAnalysisCycle.WEEKLY
            ? begin.FindWeekEnd()
            : begin.FindMonthEnd();
    }

    static List<Latest>? LatestList(this LineOfPoint? line)
    {
        switch (line)
        {
            case null:
            case { EndPoints: { } } when !line.EndPoints.Any():
                return null;
        }

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

    public static Enums.StockOperate GetOperate(
        this IEnumerable<string> codeKeys,
        Profile profile,
        Enums.StockOperate prevOperation)
    {
        switch (prevOperation)
        {
            case Enums.StockOperate.Buy:
            case Enums.StockOperate.Keep:
                return //codeKeys.AllFoundIn(filterSell)
                    profile.MatchSelling(new StockSets { SetKeys = codeKeys })
                        ? Enums.StockOperate.Sell
                        : Enums.StockOperate.Keep;

            case Enums.StockOperate.Sell:
            case Enums.StockOperate.Left:
                return //codeKeys.AllFoundIn(filterBuy)
                    profile.MatchBuying(new StockSets { SetKeys = codeKeys })
                        ? Enums.StockOperate.Buy
                        : Enums.StockOperate.Left;
        }

        return Enums.StockOperate.Left;
    }

    static decimal FinalProfit(this List<StockOperationRecord> records)
        => (records.Aggregate(1M,
            (current, record) =>
                current * (decimal)(1 + (record.SellPrice - record.BuyPrice) / record.BuyPrice)!.Value) - 1) * 100M;
}