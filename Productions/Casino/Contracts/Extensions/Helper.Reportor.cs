using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Common.Models;
using Ban3.Infrastructures.Indicators.Entries;
using Ban3.Infrastructures.RuntimeCaching;
using Ban3.Productions.Casino.Contracts.Interfaces;
#nullable enable
namespace Ban3.Productions.Casino.Contracts.Extensions;

/// <summary>
/// IReportor扩展方法，报告报表相关
/// </summary>
public static partial class Helper
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="_"></param>
    /// <param name="filter"></param>
    /// <returns></returns>
    public static List<DotRecord>? LoadDotsSankey(
        this IReportor _,
        FocusFilter filter)
    {
        var key = $"{filter.Identity}.Sankey";
        return typeof(DotOfBuyingOrSelling)
            .LocalFile(key)
            .ReadFileAs<List<DotRecord>>();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="_"></param>
    /// <param name="filter"></param>
    /// <param name="forBuying"></param>
    /// <returns></returns>
    public static Dictionary<string, int> LoadDotsKey(
        this IReportor _,
        FocusFilter filter,
        bool forBuying)
    {
        var dots = _.LoadDots(filter)
	        .Select(o => o.Value.Where(x => x.IsDotOfBuying == forBuying))
            .UnionAll();

        return dots.Select(o => o.SetKeys)!.MergeToDictionary();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="_"></param>
    /// <param name="filter"></param>
    /// <returns></returns>
    public static Dictionary<string, List<DotInfo>> LoadDots(
	    this IReportor _, 
	    FocusFilter filter)
            => Config.CacheKey<DotOfBuyingOrSelling>(filter.Identity)
            .LoadOrSetDefault<Dictionary<string, List<DotInfo>>>(
                filter.Identity.DataFile<DotInfo>()
                );

    /// <summary>
    /// 
    /// </summary>
    /// <param name="_"></param>
    /// <returns></returns>
    public static Dictionary<Entities.DistributeCondition, MultiResult<Entities.TimelineRecord>>?
        LoadDistributeRecords(
            this IReportor _)
    {
        var dic = typeof(Entities.DistributeCondition)
            .LocalFile("result")
            .ReadFileAs<Dictionary<string,
                MultiResult<Entities.TimelineRecord>>>();

        if (dic != null)
        {
            var result = new Dictionary<Entities.DistributeCondition, MultiResult<Entities.TimelineRecord>>();
            result.AddRange(
                dic.Select(o => new KeyValuePair<Entities.DistributeCondition, MultiResult<Entities.TimelineRecord>>(
                    o.Key.JsonToObj<Entities.DistributeCondition>()!, o.Value)));

            return result;
        }

        return null;
    }
}