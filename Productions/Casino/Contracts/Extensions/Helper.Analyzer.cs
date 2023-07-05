using Ban3.Infrastructures.Indicators.Outputs;
using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Common.Extensions;
using System;
using Ban3.Infrastructures.Indicators;
using Ban3.Infrastructures.Indicators.Entries;
using Ban3.Infrastructures.Indicators.Inputs;
using Ban3.Infrastructures.RuntimeCaching;
using Ban3.Productions.Casino.Contracts.Interfaces;
using Ban3.Productions.Casino.Contracts.Entities;

namespace Ban3.Productions.Casino.Contracts.Extensions;

/// <summary>
/// IAnalyzer扩展方法，分析相关
/// </summary>
public static partial class Helper
{
    #region 生成每日操作建议

    /// <summary>
    /// 根据策略与每日特征生成每日操作建议
    /// </summary>
    /// <param name="_"></param>
    /// <param name="profile"></param>
    /// <param name="everydayKeys"></param>
    /// <param name="code"></param>
    /// <returns></returns>
    public static List<StockOperate> OutputDailyOperates(
        this IAnalyzer _,
        Profile profile,
        List<StockSets> everydayKeys,
        string code)
        => profile.OutputDailyOperates(everydayKeys)
            .SaveEntities(code);
    
    /// <summary>
    /// 根据每日操作建议记录创建操作纪录
    /// </summary>
    /// <param name="stockOperates"></param>
    /// <param name="profile"></param>
    /// <param name="code"></param>
    /// <returns></returns>
    public static List<StockOperationRecord> ConvertOperates2Records(
        this List<StockOperate> stockOperates, Profile profile, string code)
        => stockOperates.ConvertToRecords(code)
            .SaveEntities($"{code}.{profile.Identity}");

    /// <summary>
    /// 加载操作纪录
    /// </summary>
    /// <param name="_"></param>
    /// <param name="profile"></param>
    /// <param name="code"></param>
    /// <returns></returns>
    public static List<StockOperationRecord>? LoadOperationRecords(
        this IAnalyzer _,
        Profile profile,
        string code) 
        => $"{code}.{profile.Identity}".LoadEntities<StockOperationRecord>();

    #endregion

    private static Dictionary<string, ProfileSummary> _evaluateSummary;

    public static void ClearSummary(this IAnalyzer _)
    {
        lock (_lock)
        {
            _evaluateSummary = new();
        }
    }

    public static void SaveSummary(this IAnalyzer _)
    {
        lock (_lock)
        {
            typeof(ProfileSummary)
                .LocalFile()
                .WriteFile(_evaluateSummary.ObjToJson());
        }
    }

    public static Dictionary<string, ProfileSummary> LoadSummary(this IAnalyzer _)
        => typeof(ProfileSummary)
            .LocalFile()
            .ReadFileAs<Dictionary<string, ProfileSummary>>();

    public static decimal FinalProfit(this List<StockOperationRecord> records) 
        => records.Aggregate(1M,
            (current, record) => current *(decimal) (1 + (record.SellPrice - record.BuyPrice) / record.BuyPrice)!.Value);

    public static void MergeSummary(this List<StockOperationRecord> records, Profile profile)
    {
        var validRecords = records.Where(o => o.SellDate != null && o.BuyPrice > 0).ToList();
        if (!validRecords.Any()) return;
        lock (_lock)
        {

            var newSummary = new ProfileSummary
            {
                Identity = profile.Identity,
                StockCount = 1,
                RecordCount = validRecords.Count(),
                RightCount = validRecords.Count(o => o.SellPrice > o.BuyPrice),
                Best =(decimal) validRecords.Max(o => (o.SellPrice - o.BuyPrice) / o.BuyPrice * 100D)!.Value,
                Worst = (decimal)validRecords.Min(o => (o.SellPrice - o.BuyPrice) / o.BuyPrice * 100D)!.Value,
                Average = validRecords.FinalProfit()
            };
            
            if (_evaluateSummary.TryGetValue(profile.Identity, out var summary))
            {
                summary.Best = Math.Max(summary.Best, newSummary.Best);
                summary.Worst = Math.Min(summary.Worst, newSummary.Worst);
                summary.Average = (summary.StockCount * summary.Average + newSummary.Average) /
                                  (summary.StockCount + 1);
                summary.StockCount += 1;
                summary.RecordCount += newSummary.RecordCount;
                summary.RightCount+= newSummary.RightCount;

                _evaluateSummary[profile.Identity] = summary;
            }
            else
            {
                _evaluateSummary.Add(profile.Identity,newSummary);
            }
        }
    }

    public static List<StockOperationRecord> LoadProfileDetails(this IAnalyzer _, List<Stock> stocks, string identity)
        =>
            Config.CacheKey<StockOperationRecord>(identity)
                .LoadOrSetDefault(
                    () => _.PrepareProfileDetails(stocks, identity), typeof(ProfileSummary)
                        .LocalFile()
                );

    static List<StockOperationRecord> PrepareProfileDetails(this IAnalyzer _, List<Stock> stocks, string identity)
    {
        var result = new List<StockOperationRecord>();

        stocks.AsParallel()
            .ForAll(s =>
            {
                var rs = _.LoadOperationRecords(new Profile { Identity = identity }, s.Code);
                if (rs != null && rs.Any())
                {
                    lock (_lock)
                    {
                        result.AddRange(rs.Where(o => o.SellDate != null));
                    }
                }
            });

        return result;
    }
}