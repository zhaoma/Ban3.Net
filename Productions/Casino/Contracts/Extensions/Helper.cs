using System;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Indicators.Entries;
using Ban3.Productions.Casino.Contracts.Request;
using log4net;

namespace Ban3.Productions.Casino.Contracts.Extensions;

public static partial class Helper
{
    static readonly ILog Logger = LogManager.GetLogger(typeof(Helper));
    static object _lock = new();

    /// <summary>
    /// 用RenderView筛选字符串
    /// </summary>
    private static readonly Func<string, RenderView, bool> StrFilter =
        (str, filter) =>
        {
            var result = (string.IsNullOrEmpty(filter.StartsWith) || str.StartsWithIn(filter.StartsWith.Split(',')));
            result = result && (string.IsNullOrEmpty(filter.EndsWith) || str.EndsWith(filter.EndsWith));
            result = result && (string.IsNullOrEmpty(filter.Id) || str == filter.Id);
            return result;
        };

    /// <summary>
    /// 用RenderView筛选Dots
    /// </summary>
    private static readonly Func<DotInfo, RenderView, bool> DotFilter =
        (dot, filter) =>
        {
            var result = (filter.RedOnly is 0 or null || dot.ChangePercent > 0);
            result = result && (filter.GreenOnly is 0 or null || dot.ChangePercent < 0);
            result = result && StrFilter(dot.Code, filter);

            return result;
        };


}