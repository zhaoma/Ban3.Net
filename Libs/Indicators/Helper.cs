using Ban3.Infrastructures.Indicators.Entries;
using Ban3.Infrastructures.Indicators.Enums;
using Ban3.Infrastructures.Indicators.Inputs;
using Ban3.Infrastructures.Indicators.Outputs;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Common.Attributes;
using Ban3.Infrastructures.Common.Extensions;

namespace Ban3.Infrastructures.Indicators;

[TracingIt]
public static class Helper
{
    static readonly ILog Logger = LogManager.GetLogger(typeof(Helper));

    #region 特征定义

    /// <summary>
    /// 指标
    /// </summary>
    public static readonly List<string> FeatureGroups = new List<string>
    {
        "AMOUNT", "BIAS", "CCI", "DMI", "ENE", "KD", "MA", "MACD"
    };

    /// <summary>
    /// 指标颜色定义字典
    /// </summary>
    public static readonly Dictionary<string, string> ColorsDic = new Dictionary<string, string>
    {
        { "AMOUNT", "#CCC" },
        { "MA", "#CCC" },
        { "BIAS", "#FC0" },
        { "CCI", "#FC0" },
        { "DMI", "#C09" },
        { "ENE", "#CCC" },
        { "KD", "#FC0" },
        { "MACD", "#C09" }
    };

    /// <summary>
    /// 指标特征字典
    /// </summary>
    public static readonly List<SetsFeature> Features = new List<SetsFeature>
    {
        new("AMOUNT.UP", "量升", 0),
        new("BIAS.GE", "乖离合理", 1),
        new("BIAS.LT", "乖离不合理", -1),
        new("BIAS.GC", "乖离金叉", 2),
        new("BIAS.DC", "乖离死叉", -2),

        new("CCI.200", "CCI200", 0),
        new("CCI.100", "CCI100", 0),

        new("CCI.-200", "CCI-200", 0),

        new("DMI.PDI", "多空多头", 1),
        new("DMI.MDI", "多空空头", -1),
        new("DMI.80", "多空转向", -1),
        new("DMI.GC", "多空金叉", 2),
        new("DMI.DC", "多空死叉", -2),

        new("ENE.UPPER", "轨道上轨", 0),
        new("ENE.LOWER", "轨道下轨", 0),

        new("KD.PDI", "随机多头", 1),
        new("KD.MDI", "随机空头", -1),
        new("KD.GC", "随机金叉", 2),
        new("KD.80", "随机强势", 1),
        new("KD.10", "随机超跌", -1),
        new("KD.DC", "随机死叉", -2),

        new("MA.UP", "均线多头", 0),

        new("MACD.PDI", "平均线多头", 1),
        new("MACD.MDI", "平均线空头", -1),
        new("MACD.P", "平均线零上", 1),
        new("MACD.N", "平均线零下", -1),
        new("MACD.GC", "平均线金叉", 2),
        new("MACD.DC", "平均线死叉", -2),
        new("MACD.C0", "平均线上穿零", 3),
        new("MACD.D0", "平均线下穿零", -3)
    };

    /// <summary>
    /// 指标下加分/减分特征集合
    /// </summary>
    /// <param name="indicator"></param>
    /// <param name="plus"></param>
    /// <returns></returns>
    public static List<string> FeatureKeys(string indicator, bool plus)
        => Features
            .Where(o => o.Key.StartsWith($"{indicator.ToUpper()}.") && (o.Value > 0) == plus)
            .Select(o => o.Key + ".")
            .ToList();

    /// <summary>
    /// 输出特征值描述信息
    /// </summary>
    /// <param name="feature"></param>
    /// <param name="cycleSubject"></param>
    /// <param name="newValue"></param>
    /// <returns></returns>
    static SetsFeature ReNew(this SetsFeature feature, string cycleSubject, int newValue)
    {
        return new SetsFeature(feature.Key, cycleSubject + feature.Subject, feature.Value * newValue);
    }


    static Dictionary<string, SetsFeature> PrepareFeatureDictionary()
    {
        var result = new Dictionary<string, SetsFeature>();

        result.AddRange(
            Features.Select(o =>
                new KeyValuePair<string, SetsFeature>($"{o.Key}.{StockAnalysisCycle.DAILY}", o.ReNew("日线", 1)))
        );
        result.AddRange(
            Features.Select(o =>
                new KeyValuePair<string, SetsFeature>($"{o.Key}.{StockAnalysisCycle.WEEKLY}", o.ReNew("周线", 2)))
        );
        result.AddRange(
            Features.Select(o =>
                new KeyValuePair<string, SetsFeature>($"{o.Key}.{StockAnalysisCycle.MONTHLY}", o.ReNew("月线", 3)))
        );

        return result;
    }

    static readonly object ObjectLock = new();
    static Dictionary<string, SetsFeature>? _allFeatures;

    /// <summary>
    /// 所有指标特征值
    /// </summary>
    public static Dictionary<string, SetsFeature> AllFeatures
    {
        get
        {
            if (_allFeatures != null) return _allFeatures;

            lock (ObjectLock)
            {
                _allFeatures ??= PrepareFeatureDictionary();
            }

            return _allFeatures;
        }
    }

    #endregion

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

    #region Profiles

    /// <summary>
    /// 默认策略
    /// </summary>
    public static readonly Profile DefaultProfile = new()
    {
        Identity = "default",
        Subject = "MACD MWD C0",
        BuyingCondition = new ProfileCondition
        {
            Include = new List<string>
                {
                    "MACD.C0.MONTHLY",
                    "MACD.C0.WEEKLY",
                    "MACD.C0.DAILY|MACD.P.DAILY;MACD.GC.DAILY"
                },
            Exclude = new List<string> { "KD.MDI.DAILY" }
        },
        SellingCondition = new ProfileCondition
        {
            Include = new List<string> { "KD.DC.DAILY" }
        },
        Persistence = true,
        IsDefault = true
    };

    /// <summary>
    /// 默认策略池
    /// </summary>
    public static readonly List<Profile> DefaultProfiles = new List<Profile>
    {
       DefaultProfile,
       new Profile(
           "harsh",
           "MACD 3C0",
           new ProfileCondition(new List<string>{"MACD.C0.DAILY","MACD.C0.WEEKLY","MACD.C0.MONTHLY"},new List<string>{"KD.MDI.DAILY"}),
           new ProfileCondition(new List<string>{"KD.DC.DAILY"},new List<string>())
           ),
       new Profile(
           "rebound",
           "Rebound CK",
           new ProfileCondition(new List<string>{"CCI.-200.DAILY","KD.GC.DAILY","KD.10.DAILY"},new List<string>()),
           new ProfileCondition(new List<string>{"KD.DC.DAILY"},new List<string>())
       )
    };

    #endregion

    public static bool SplitAmount(this List<Price> prices, int days, out List<Price> amounts)
    {
        amounts = new List<Price>();

        return false;
    }

    public static bool SplitWeeklyAndMonthly(this List<Price> prices,out List<Price> weekly,out List<Price> monthly)
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

            var exists = lastRecord.MarkTime.End(cycle).ToYmd();
            var add = price.MarkTime.End(cycle).ToYmd();
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
}