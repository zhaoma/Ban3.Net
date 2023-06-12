using Ban3.Infrastructures.Indicators.Entries;
using Ban3.Infrastructures.Indicators.Enums;
using Ban3.Infrastructures.Indicators.Inputs;
using Ban3.Infrastructures.Indicators.Outputs;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ban3.Infrastructures.Common.Attributes;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.RuntimeCaching;

namespace Ban3.Infrastructures.Indicators;

[TracingIt]
public static class Helper
{
    static readonly ILog Logger = LogManager.GetLogger(typeof(Helper));

    #region 特征定义

    private static readonly List<SetsFeature> Features = new List<SetsFeature>
    {
        new("AMOUNT.UP", "成交量多头", 1),
        new("BIAS.GE", "乖离合理", 1),
        new("BIAS.LT", "乖离不合理", -1),
        new("BIAS.GC", "乖离金叉", 1),
        new("BIAS.DC", "乖离死叉", -1),
        new("CCI.200", "顺势超买", 1),
        new("CCI.100", "顺势强势", 1),
        new("CCI.-200", "顺势超卖", -1),
        new("DMI.PDI", "多空多头", 1),
        new("DMI.MDI", "多空空头", -1),
        new("DMI.80", "多空转向", -1),
        new("DMI.GC", "多空金叉", 1),
        new("DMI.DC", "多空死叉", -1),
        new("ENE.UPPER", "轨道上轨", 1),
        new("ENE.LOWER", "轨道下轨", -1),
        new("KD.PDI", "随机多头", 1),
        new("KD.MDI", "随机空头", -1),
        new("KD.GC", "随机金叉", 1),
        new("KD.80", "随机强势", 1),
        new("KD.10", "随机超跌", -1),
        new("KD.DC", "随机死叉", -1),
        new("MA.UP", "均线多头", 1),
        new("MACD.PDI", "平均线多头", 1),
        new("MACD.MDI", "平均线空头", -1),
        new("MACD.P", "平均线零上", 1),
        new("MACD.N", "平均线零下", -1),
        new("MACD.GC", "平均线金叉", 1),
        new("MACD.DC", "平均线死叉", -1),
        new("MACD.C0", "平均线上穿零", 1),
        new("MACD.D0", "平均线下穿零", -1)
    };

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
                new KeyValuePair<string, SetsFeature>($"{o.Key}.{StockAnalysisCycle.DAILY}", o.ReNew("月线", 3)))
        );

        return result;
    }

    static readonly object ObjectLock = new();
    static Dictionary<string, SetsFeature>? _allFeatures;

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

    #region Profiles

    private static readonly List<Profile> DefaultProfiles = new()
    {
        new()
        {
            Identity = "default",
            Subject = "MACD MWD C0",
            BuySets = new List<string[]>
            {
                new []{"MACD.C0.DAILY","MACD.C0.WEEKLY","MACD.C0.MONTHLY"}
            },
            SellSets = new List<string[]>{new []{ "MACD.DC.DAILY" } },
            Persistence=true,
            IsDefault = true
        },
        new()
        {
            Identity = "extend",
            Subject = "MACD extend",
            BuySets = new List<string[]>
            {
                new []{"MACD.P.MONTHLY,MACD.P.WEEKLY,MACD.P.DAILY,MACD.GC.DAILY"}
            },
            SellSets = new List<string[]> {new[] {"MACD.DC.DAILY"}},
            Persistence=true,
            IsDefault = false
        }
    };

    const string CacheKey = "casino.Profiles";
    private static readonly string ProfilesFile = "all".DataFile<Profile>();
    public static List<Profile> Profiles
        => CacheKey.LoadOrSetDefault(DefaultProfiles, ProfilesFile);

    #endregion
}