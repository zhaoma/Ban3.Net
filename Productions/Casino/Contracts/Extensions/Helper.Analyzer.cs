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
using Stock = Ban3.Infrastructures.Indicators.Entries.Stock;

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
        => stockOperates.ConvertToRecords()
            .SaveEntities($"{code}.{profile.Identity}");

    /// <summary>
    /// 加载操作纪录
    /// </summary>
    /// <param name="_"></param>
    /// <param name="profile"></param>
    /// <param name="code"></param>
    /// <returns></returns>
    public static List<StockOperationRecord> LoadOperationRecords(
        this IAnalyzer _,
        Profile profile,
        string code) 
        => $"{code}.{profile.Identity}".LoadEntities<StockOperationRecord>();

    #endregion

    public static Dictionary<string, ProfileSummary> LoadSummary(this IAnalyzer _)
        => Infrastructures.Indicators.Helper.LoadProfileSummaries();

    public static List<StockOperationRecord> LoadProfileDetails(this IAnalyzer _, List<string> codes, string identity)
        =>
            Config.CacheKey<StockOperationRecord>(identity)
                .LoadOrSetDefault(
                    () => _.PrepareProfileDetails(codes, identity), typeof(ProfileSummary)
                        .LocalFile()
                );

    static List<StockOperationRecord> PrepareProfileDetails(this IAnalyzer _, List<string> codes, string identity)
    {
        var result = new List<StockOperationRecord>();

        codes.AsParallel()
            .ForAll(s =>
            {
                var rs = _.LoadOperationRecords(new Profile { Identity = identity }, s);
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