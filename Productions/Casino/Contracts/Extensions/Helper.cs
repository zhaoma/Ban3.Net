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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="prefix"></param>
    /// <returns></returns>
    public static Enums.StockGroup StockGroup(this string prefix) => 
	    prefix.Substring(0, 3) switch
            {
                "000" => Enums.StockGroup.SZA,
                "001" => Enums.StockGroup.SZA,
                "002" => Enums.StockGroup.SZZ,
                "003" => Enums.StockGroup.SZZ,
                "300" => Enums.StockGroup.SZC,
                "301" => Enums.StockGroup.SZC,
                "600" => Enums.StockGroup.SHA,
                "601" => Enums.StockGroup.SHA,
                "603" => Enums.StockGroup.SHA,
                "688" => Enums.StockGroup.SHK,
                "689" => Enums.StockGroup.SHK,
                _ => Enums.StockGroup.Other
            };

    public static Enums.PriceScope PriceScope(this double price)
    {
        if (price <= 5D)
            return Enums.PriceScope.LE5;

        if (price <= 10D)
            return Enums.PriceScope.LE10;

        if (price <= 20D)
            return Enums.PriceScope.LE20;

        if (price <= 30D)
            return Enums.PriceScope.LE30;

        if (price <= 50D)
            return Enums.PriceScope.LE50;

        if (price <= 100D)
            return Enums.PriceScope.LE100;

        if (price <= 200D)
            return Enums.PriceScope.LE200;

        return Enums.PriceScope.GT200;
    }
}