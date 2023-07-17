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

namespace Ban3.Productions.Casino.Contracts.Extensions;

/// <summary>
/// IAnalyzer扩展方法，分析相关
/// </summary>
public static partial class Helper
{
    public static Dictionary<string, ProfileSummary> LoadSummary(this IAnalyzer _)
        =>
            Config.CacheKey<ProfileSummary>("all")
                .LoadOrSetDefault(
                Infrastructures.Indicators.Helper.LoadProfileSummaries,typeof(ProfileSummary).LocalFile()
                ); 

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
                    () => _.PrepareProfileDetails(codes, identity), typeof(ProfileSummary)
                        .LocalFile()
                );

    static List<StockOperationRecord> PrepareProfileDetails(this IAnalyzer _, List<string> codes, string identity)
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
}