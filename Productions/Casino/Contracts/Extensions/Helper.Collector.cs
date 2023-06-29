using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Productions.Casino.Contracts.Entities;
using Ban3.Productions.Casino.Contracts.Interfaces;
using StockPrice = Ban3.Sites.ViaTushare.Entries.StockPrice;

namespace Ban3.Productions.Casino.Contracts.Extensions;

/// <summary>
/// ICollector扩展方法，采集相关
/// </summary>
public static partial class Helper
{
    /// <summary>
    /// 准备标的数据
    /// </summary>
    /// <param name="_"></param>
    /// <param name="allCodes"></param>
    /// <returns></returns>
    public static bool PrepareAllCodes(this ICollector _, List<Stock> allCodes = null) => _.Sites.PrepareAllCodesFromTushare(allCodes);

    /// <summary>
    /// 加载标的数据
    /// </summary>
    /// <param name="_"></param>
    /// <returns></returns>
    public static List<Stock> LoadAllCodes(this ICollector _) => _.Sites.LoadAllCodes();

    public static List<Stock> ScopedCodes(this ICollector _)
        => _.LoadAllCodes().Where(o => o.Code.EndsWith(".SH") || o.Code.EndsWith(".SZ")).ToList();

    /// <summary>
    /// 获取某一标的
    /// </summary>
    /// <param name="_"></param>
    /// <param name="code"></param>
    /// <returns></returns>
    public static Stock LoadStock(this ICollector _, string code)
        => _.LoadAllCodes().FindLast(o => o.Code.StringEquals(code));
    
    /// <summary>
    /// 获取所有历史行情
    /// </summary>
    /// <param name="_"></param>
    /// <param name="allCodes"></param>
    /// <returns></returns>
    public static bool PrepareDailyPrices(this ICollector _, List<Stock> allCodes = null) => _.Sites.PrepareAllDailyPrices(allCodes);

    /// <summary>
    /// 获取某一历史行情
    /// </summary>
    /// <param name="_"></param>
    /// <param name="code"></param>
    /// <returns></returns>
    public static bool PrepareOnesPrices(this ICollector _, string code) => _.Sites.PrepareOnesDailyPrices(code);

    /// <summary>
    /// 补充所有行情数据
    /// </summary>
    /// <param name="_"></param>
    /// <param name="allCodes"></param>
    /// <returns></returns>
    public static bool FixDailyPrices(this ICollector _, List<Stock> allCodes = null) => _.Sites.FixAllDailyPrices(allCodes);

    /// <summary>
    /// 加载行情数据
    /// </summary>
    /// <param name="_"></param>
    /// <param name="code"></param>
    /// <returns></returns>
    public static List<StockPrice> LoadDailyPrices(this ICollector _, string code) => _.Sites.LoadOnesDailyPrices(code);

    /// <summary>
    /// 准备所有事件数据
    /// </summary>
    /// <param name="_"></param>
    /// <param name="allCodes"></param>
    /// <returns></returns>
    public static bool PrepareAllEvents(this ICollector _, List<Stock> allCodes = null) => _.Sites.PrepareAllEvents(allCodes);

    /// <summary>
    /// 准备某一事件数据
    /// </summary>
    /// <param name="_"></param>
    /// <param name="symbol"></param>
    /// <returns></returns>
    public static bool PrepareOnesEvents(this ICollector _, string symbol) => _.Sites.PrepareOnesEvents(symbol);

    /// <summary>
    /// 加载某一事件数据
    /// </summary>
    /// <param name="_"></param>
    /// <param name="symbol"></param>
    /// <returns></returns>
    public static List<StockEvent> LoadOnesEvents(this ICollector _, string symbol) => _.Sites.LoadOnesEvents(symbol);

    /// <summary>
    /// 刷新实时行情
    /// </summary>
    /// <param name="_"></param>
    /// <param name="allCodes"></param>
    /// <returns></returns>
    public static bool ReadRealtime(this ICollector _, List<Stock> allCodes = null) => _.Sites.ReadRealtime(allCodes).Result;
}
