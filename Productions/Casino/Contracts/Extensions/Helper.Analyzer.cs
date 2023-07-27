using Ban3.Infrastructures.Indicators.Outputs;
using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Indicators;
using Ban3.Infrastructures.Indicators.Entries;
using Ban3.Infrastructures.Indicators.Inputs;
using Ban3.Infrastructures.RuntimeCaching;
using Ban3.Productions.Casino.Contracts.Interfaces;
using Stock = Ban3.Infrastructures.Indicators.Entries.Stock;
using System;
using Ban3.Infrastructures.Common.Models;

namespace Ban3.Productions.Casino.Contracts.Extensions;

/// <summary>
/// IAnalyzer扩展方法，分析相关
/// </summary>
public static partial class Helper
{
    /// <summary>
    /// 加载策略汇总数据
    /// </summary>
    /// <param name="_"></param>
    /// <returns></returns>
    public static Dictionary<string, ProfileSummary> LoadSummary(this IAnalyzer _)
        =>
            Config.CacheKey<ProfileSummary>("all")
                .LoadOrSetDefault(
                Infrastructures.Indicators.Helper.LoadProfileSummaries,typeof(ProfileSummary).LocalFile()
                );

    /// <summary>
    /// 评估策略，生成汇总
    /// </summary>
    public static void EvaluateProfiles(
        this IAnalyzer _,
        List<Stock> stocks)
    {
        var total = stocks.Count;
        var current = 0;
        var profileSummaries = new Dictionary<string, ProfileSummary>();

        stocks.ParallelExecute(one =>
        {
            var now = DateTime.Now;

            var dailySets = one.LoadStockSets();

            Config.Profiles().ForEach(profile =>
            {
                var oneProfileSummary = profile.OutputDailyOperates(dailySets)
                    .SaveFor(one, profile)
                    .ConvertToRecords()
                    .SaveFor(one, profile)
                    .RecordsSummary(profile);

                profileSummaries.MergeSummary(oneProfileSummary);
            });
            current++;
            Logger.Debug(
                $"parse {current}/{total} : {one.Code} over,{DateTime.Now.Subtract(now).TotalMilliseconds} ms elapsed.");
        }, Config.MaxParallelTasks);

        profileSummaries.Save();

        Config.Profiles().ForEach(profile => { _.PrepareCompositeRecords(stocks.Select(o => o.Code).ToList(), profile.Identity); });
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="_"></param>
    /// <param name="codes"></param>
    /// <param name="profileId"></param>
    /// <returns></returns>
    public static Entities.CompositeRecords PrepareCompositeRecords(
        this IAnalyzer _,
        List<string> codes, string profileId)
    {
        var result = new Entities.CompositeRecords
        {
            Profile = Config.Profiles().Last(o => o.Identity == profileId),
            Records = _.LoadProfileDetails(codes, profileId)
        };

        var rightSets = new List<List<string>>();
        var wrongSets = new List<List<string>>();

        result.Records.ForEach(r =>
        {
            if (r.SellDate != null)
            {
                var sets = new Entities.Stock { Code = r.Code }.LoadStockSets()
                    .GetSetKeys(r.BuyDate.ToYmd());
                //.Except(result.Profile.BuyingCondition.);

                if (sets != null)
                {
                    if (r.SellPrice > r.BuyPrice)
                    {
                        rightSets.Add(sets);
                    }
                    else
                    {
                        wrongSets.Add(sets);
                    }
                }
            }
        });

        result.RightKeys = rightSets.MergeToDictionary();
        result.WrongKeys = wrongSets.MergeToDictionary();

        result.SaveEntity(_ => profileId);

        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="_"></param>
    /// <param name="codes"></param>
    /// <param name="identity"></param>
    /// <returns></returns>
    public static List<StockOperationRecord> LoadProfileDetails(this IAnalyzer _, List<string> codes, string identity)
        =>
            Config.CacheKey<StockOperationRecord>(identity)
                .LoadOrSetDefault(
                    () => _.PrepareProfileDetails(codes, identity),60
                );

    private static List<StockOperationRecord> PrepareProfileDetails(
        this IAnalyzer _, 
        IEnumerable<string> codes,
        string identity)
    {
        var result = new List<StockOperationRecord>();

        codes.AsParallel()
            .ForAll(s =>
            {
                var rs = new Stock { Code = s }.LoadStockOperationRecords(new Profile { Identity = identity });
                if (rs != null && rs.Any())
                {
                    lock (_lock)
                    {
                        result.AddRange(rs);
                    }
                }
            });

        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    public static void PrepareDistributeRecords(this IAnalyzer _)
    {
        var all = "all".LoadEntities<Entities.TimelineRecord>();
        var result =
            new Dictionary<Entities.DistributeCondition, MultiResult<Entities.TimelineRecord>>();

        if (all != null && all.Any())
        {
            Config.DistributeConditions().ForEach(condition =>
            {
                all.FindAll(condition.IsTarget).ToList()
                    .ForEach(o => result.AppendInMultiResult(condition, o));
            });
        }

        typeof(Entities.DistributeCondition)
            .LocalFile("result")
            .WriteFile(result.ObjToJson());
    }

}