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
    /// 板块归属
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
                "605" => Enums.StockGroup.SHA,
                "688" => Enums.StockGroup.SHK,
                "689" => Enums.StockGroup.SHK,
                _ => Enums.StockGroup.Other
            };

    /// <summary>
    /// 价格区间划分
    /// </summary>
    /// <param name="price"></param>
    /// <returns></returns>
    public static Enums.PriceScope PriceScope(this double price) =>
        price switch
        {
            <= 5D => Enums.PriceScope.LE5,
            <= 10D => Enums.PriceScope.LE10,
            <= 20D => Enums.PriceScope.LE20,
            <= 30D => Enums.PriceScope.LE30,
            <= 50D => Enums.PriceScope.LE50,
            <= 100D => Enums.PriceScope.LE100,
            <= 200D => Enums.PriceScope.LE200,
            _ => Enums.PriceScope.GT200
        };

    /// <summary>
    /// 按股本划分
    /// </summary>
    /// <param name="capital"></param>
    /// <returns></returns>
    public static Enums.CapitalScope CapitalScope(this double capital) =>
        capital switch
        {
            <= 50D * 1000 * 1000 => Enums.CapitalScope.LE50M,
            <= 100D * 1000 * 1000 => Enums.CapitalScope.LE100M,
            <= 200D * 1000 * 1000 => Enums.CapitalScope.LE200M,
            <= 300D * 1000 * 1000 => Enums.CapitalScope.LE300M,
            <= 500D * 1000 * 1000 => Enums.CapitalScope.LE500M,
            <= 1000D * 1000 * 1000 => Enums.CapitalScope.LE1000M,
            <= 2000D * 1000 * 1000 => Enums.CapitalScope.LE2000M,
            _ => Enums.CapitalScope.GT2000M
        };

    /// <summary>
    /// 按市值划分
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Enums.ValueScope ValueScope(this double value) =>
        value switch
        {
            <= 2D * 1000 * 1000 * 1000 => Enums.ValueScope.LE2B,
            <= 5D * 1000 * 1000 * 1000 => Enums.ValueScope.LE5B,
            <= 10D * 1000 * 1000 * 1000 => Enums.ValueScope.LE10B,
            <= 20D * 1000 * 1000 * 1000 => Enums.ValueScope.LE20B,
            _ => Enums.ValueScope.GT20B
        };
}