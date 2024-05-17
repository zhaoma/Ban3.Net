//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Contracts.Entries.CasinoServer;
using Ban3.Infrastructures.Contracts.Enums.CasinoServer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Ban3.Implements.Alpha.Extensions;

/// <summary>
/// Casino的一些静态扩展方法
/// </summary>
public static partial class Helper
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="prices"></param>
    /// <param name="addPrice"></param>
    /// <param name="cycle"></param>
    public static void AppendLatest(this List<Price> prices, Price addPrice, CycleIs cycle)
    {
        Price price = new Price
        {
            Code = addPrice.Code,
            MarkTime = addPrice.MarkTime,
            TradeDate = addPrice.TradeDate,
            Open = addPrice.Open,
            High = addPrice.High,
            Low = addPrice.Low,
            Close = addPrice.Close,
            PreClose = addPrice.PreClose,
            Volumn = addPrice.Volumn,
            Amount = addPrice.Amount
        };
        if (!prices.Any())
        {
            prices.Add(price);
            return;
        }

        Price price2 = prices.Last();
        string strValue = price2.MarkTime.End(cycle).ToYmd();
        string strValue2 = price.MarkTime.End(cycle).ToYmd();
        if (strValue.ToInt().Equals(strValue2.ToInt()))
        {
            price2.Close = price.Close;
            price2.High = Math.Max(price2.High, price.High);
            price2.Low = Math.Min(price2.Low, price.Low);
            price2.Volumn += price.Volumn;
            price2.Amount += price.Amount;
            price2.Change = price2.Close - price2.PreClose;
            price2.ChangePercent = price2.PreClose != 0.0M ? Math.Round((price2.Close - price2.PreClose) / price2.PreClose * 100.0M, 2) : 0M;
        }
        else
        {
            prices.Add(price);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="begin"></param>
    /// <param name="stockCycle"></param>
    /// <returns></returns>
    private static DateTime End(this DateTime begin, CycleIs stockCycle)
    {
        if (stockCycle != CycleIs.Weekly)
        {
            return begin.FindMonthEnd();
        }

        return begin.FindWeekEnd();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="prices"></param>
    /// <param name="selectValue"></param>
    /// <param name="current"></param>
    /// <param name="period"></param>
    /// <returns></returns>
    public static decimal EMA(
        this List<Price> prices,
        Func<Price, decimal> selectValue,
        int current,
        int period)
    {
        var total = 0M;
        var counter = 0;
        var start = Math.Max(0, current - period);

        for (var i = start; i <= current; i++)
        {
            total += (i - start) * selectValue(prices[i]);
            counter += i - start;
        }

        return counter > 0 ? Math.Round(total / counter, 3) : 0;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="numbers"></param>
    /// <param name="current"></param>
    /// <param name="period"></param>
    /// <returns></returns>
    public static decimal EMA(
        this List<decimal> numbers,
        int current,
        int period)
    {
        var total = 0M;
        var counter = 0;
        var start = Math.Max(0, current - period);

        for (var i = start; i <= current; i++)
        {
            total += (i - start) * numbers[i];
            counter += i - start;
        }

        return counter > 0 ? Math.Round(total / counter, 3) : 0;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="prices"></param>
    /// <param name="selectValue"></param>
    /// <param name="current"></param>
    /// <param name="period"></param>
    /// <returns></returns>
    public static decimal MA(
        this List<Price> prices,
        Func<Price, decimal> selectValue,
        int current,
        int period)
    {
        var total = 0M;
        var counter = 0;
        var start = Math.Max(0, current - period);

        for (int i = start; i < current; i++)
        {
            total += selectValue(prices[i]);
            counter++;
        }

        return counter > 0 ? Math.Round(total / counter, 3) : 0;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="numbers"></param>
    /// <param name="current"></param>
    /// <param name="period"></param>
    /// <returns></returns>
    public static decimal MA(
        this List<decimal> numbers,
        int current,
        int period)
    {
        var total = 0M;
        var counter = 0;
        var start = Math.Max(0, current - period);

        for (int i = start; i < current; i++)
        {
            total += numbers[i];
            counter++;
        }

        return counter > 0 ? Math.Round(total / counter, 3) : 0;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="result"></param>
    /// <returns></returns>
    public static Result GenerateSuggestsAndNotices(this Result result)
    {
        if (result.Remarks != null && result.Remarks.Any() && result.Suggest != SuggestIs.Ignore)
        {
            if (result.Notices == null) result.Notices = new List<Notice>();

            for (var i = 1; i < result.Remarks.Count; i++)
            {
                if (result.Remarks[i - 1].DayOutput != null
                     && result.Remarks[i].DayOutput != null)
                {
                    result.Remarks[i].Suggest = Judge(result.Remarks[i - 1].DayOutput, result.Remarks[i].DayOutput, result.Suggest);
                    result.Suggest = result.Remarks[i].Suggest;

                    if (result.Remarks[i].DayPrice.LimitFeature(out var feature))
                    {
                        result.Notices.Add(new Notice
                        {
                            Code = result.Stock.Code,
                            MarkTime = result.Remarks[i].DayPrice.MarkTime,
                            Feature = feature
                        });
                    }

                    if (result.Remarks[i].DayOutput.OutputFeature(result.Remarks[i - 1].DayOutput, out var f,out var s))
                    {
                        result.Notices.Add(new Notice
                        {
                            Code = result.Stock.Code,
                            MarkTime = result.Remarks[i].DayPrice.MarkTime,
                            Feature = f,
                            Note=s
                        });
                    }
                }
            }
        }

        return result;
    }

    static Func<Output, Output, SuggestIs, SuggestIs> Judge =
        (Output yesterday, Output today, SuggestIs currentSuggest) =>
    {
        switch (currentSuggest)
        {
            case SuggestIs.Skip:
                if (yesterday.MA.Short < yesterday.MA.Long
                && today.MA.Short > today.MA.Long
                && today.MX.Buy > today.MX.Sell
                && today.MACD.DIF > 0
                && today.MACD.DIF > today.MACD.DEA)
                    return SuggestIs.Buy;
                break;

            case SuggestIs.Buy:
                if (today.MA.Short > today.MA.Long)
                    return SuggestIs.Keep;
                break;

            case SuggestIs.Keep:
                if (yesterday.MX.Buy > yesterday.MX.Sell && today.MX.Buy < today.MX.Sell)
                    return SuggestIs.Sell;
                break;

            case SuggestIs.Sell:
                if (today.MX.Buy < today.MX.Sell)
                    return SuggestIs.Skip;
                break;
        }

        return currentSuggest;
    };

    /// <summary>
    /// 
    /// </summary>
    /// <param name="result"></param>
    /// <returns></returns>
    public static List<TradeDetail> GenerateDetails(this Result result)
    {
        var details = new List<TradeDetail>();
        if (result.Remarks != null && result.Remarks.Any())
        {
            foreach (var r in result.Remarks)
            {
                if (DateTime.Now.Subtract(r.DayPrice.MarkTime).TotalDays < 500)
                {
                    if (r.Suggest == SuggestIs.Buy && details.All(o => o.SellPrice != 0))
                    {
                        details.Add(new TradeDetail
                        {
                            BuyTime = r.DayPrice.MarkTime,
                            BuyPrice = r.DayPrice.Close,
                            SellPrice = 0
                        });
                    }

                    if (r.Suggest == SuggestIs.Sell && details.Any(o => o.SellPrice == 0))
                    {
                        var l = details.Last(o => o.SellPrice == 0);
                        l.SellPrice = r.DayPrice.Close;
                        l.SellTime = r.DayPrice.MarkTime;
                    }
                }
            }
        }

        return details;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="row"></param>
    /// <returns></returns>
    public static Price Row2Price(this List<string> row) => new Price
    {
        Code = row[0],
        TradeDate = row[1],
        Open = row[2].ToDecimal(),
        High = row[3].ToDecimal(),
        Low = row[4].ToDecimal(),
        Close = row[5].ToDecimal(),
        PreClose = row[6].ToDecimal(),
        Change = row[7].ToDecimal(),
        ChangePercent = row[8].ToDecimal(),
        Volumn = row[9].ToDecimal(),
        Amount = row[10].ToDecimal(),
        MarkTime = row[1].ToDateTimeEx()
    };

    /// <summary>
    /// 
    /// </summary>
    /// <param name="price"></param>
    /// <param name="upOrDown"></param>
    /// <param name="closeOrReach"></param>
    /// <returns></returns>
    public static bool IsLimit(this Price price,bool upOrDown, bool closeOrReach)
    {
        var percent = upOrDown ? 10m : -10m;

        if (price.Code.StartsWith("30") || price.Code.StartsWith("68"))
            percent = upOrDown ? 20m : -20m;

        if (price.Code.StartsWith("4") || price.Code.StartsWith("8"))
            percent = upOrDown ? 30m : -30m;

        var to = closeOrReach ? price.Close : (upOrDown ? price.High : price.Low);

        return to.IsLimit(price.PreClose, percent);
    }

    static bool IsLimit(this decimal close, decimal preClose, decimal changeRatio)
    {
        var num = Math.Round(preClose * (changeRatio / 100m + 1m), 2);
        var num2 = Math.Round(close, 2);
        return num.Equals(num2);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="price"></param>
    /// <param name="feature"></param>
    /// <returns></returns>
    public static bool LimitFeature(this Price price,out FeatureIs feature)
    {
        if (price.IsLimit(true, true))
        {
            feature=FeatureIs.LimitUp;
            return true;
        }

        if (price.IsLimit(true, false))
        {
            feature = FeatureIs.ReachUp;
            return true;
        }

        if (price.IsLimit(false, true))
        {
            feature = FeatureIs.LimitDown;
            return true;
        }

        if (price.IsLimit(false, false))
        {
            feature = FeatureIs.ReachDown;
            return true;
        }

        feature = FeatureIs.Normal;
        return false;
    }

    /// <summary>
    /// 汇总报告生产
    /// </summary>
    /// <param name="summary"></param>
    /// <returns></returns>
    public static Summary Latest(this Summary summary)
    {
        var result=new Summary {MarkTime=summary.MarkTime,Records=new List<TradeRecord>() };

        foreach (var record in summary.Records)
        {
            if (record.Details.Any(x => x.SellPrice == 0))
            {
                result.Records.Add(new TradeRecord
                {
                    Code=record.Code,
                    Details=record.Details.Where(x=>x.SellPrice == 0).ToList()
                });
            }
        }

        return result;
    }

    static bool OutputFeature(this Output today,Output yesterday, out FeatureIs feature,out string note)
    {
        if (yesterday.MACD.DIF < 0 && today.MACD.DIF > 0)
        {
            feature = FeatureIs.Launch;
            note = "DIF上穿0";
            return true;
        }

        if (yesterday.MACD.DIF < yesterday.MACD.DEA && today.MACD.DIF > today.MACD.DEA)
        {
            feature = FeatureIs.Plus;
            note = "MACD金叉";
            return true;
        }
        if (yesterday.MA.Short < yesterday.MA.Long && today.MA.Short > today.MA.Long)
        {
            feature = FeatureIs.Plus;
            note = "MA金叉";
            return true;
        }
        if (yesterday.MX.Buy < yesterday.MX.Sell && today.MX.Buy > today.MX.Sell)
        {
            feature = FeatureIs.Plus;
            note = "MX金叉";
            return true;
        }

        if (yesterday.MACD.DIF > 0 && today.MACD.DIF < 0)
        {
            feature = FeatureIs.Hold;
            note = "DIF下穿0";
            return true;
        }

        if (yesterday.MACD.DIF > yesterday.MACD.DEA && today.MACD.DIF < today.MACD.DEA)
        {
            feature = FeatureIs.Minus;
            note = "MACD死叉";
            return true;
        }
        if (yesterday.MA.Short > yesterday.MA.Long && today.MA.Short < today.MA.Long)
        {
            feature = FeatureIs.Minus;
            note = "MA死叉";
            return true;
        }
        if (yesterday.MX.Buy > yesterday.MX.Sell && today.MX.Buy < today.MX.Sell)
        {
            feature = FeatureIs.Minus;
            note = "MX死叉";
            return true;
        }

        feature = FeatureIs.Normal;
        note = "";
        return false;
    }

    static void AddNotice(this List<Notice> notices, Notice notice)
    {
        if (notices.Any(n => n.MarkTime.ToYmd() == notice.MarkTime.ToYmd() && n.Feature == notice.Feature))
        {
            return;
        }
        notices.Add(notice);
    }
}
