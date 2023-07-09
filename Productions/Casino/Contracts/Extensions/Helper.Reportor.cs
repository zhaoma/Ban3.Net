using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Indicators.Entries;
using Ban3.Infrastructures.RuntimeCaching;
using Ban3.Productions.Casino.Contracts.Interfaces;

namespace Ban3.Productions.Casino.Contracts.Extensions;

/// <summary>
/// IReportor扩展方法，报告报表相关
/// </summary>
public static partial class Helper
{
    public static List<DotRecord> LoadDotsSankey(
        this IReportor _,
        FocusFilter filter)
    {
        var key = $"{filter.Identity}.Sankey";
        return typeof(DotOfBuyingOrSelling)
            .LocalFile(key)
            .ReadFileAs<List<DotRecord>>();
    }

    public static Dictionary<string, int> LoadDotsKey(
        this IReportor _,
        FocusFilter filter,
        bool forBuying)
    {
        var dots = _.LoadDots(filter)
	        .Select(o => o.Value.Where(x => x.IsDotOfBuying == forBuying))
            .UnionAll();

        return dots.Select(o => o.SetKeys).MergeToDictionary();
    }

    public static Dictionary<string, List<DotInfo>> LoadDots(
	    this IReportor _, 
	    FocusFilter filter)
            => Config.CacheKey<DotOfBuyingOrSelling>(filter.Identity)
            .LoadOrSetDefault<Dictionary<string, List<DotInfo>>>(
                filter.Identity.DataFile<DotInfo>()
                );
}