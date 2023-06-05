using System;
using System.Collections.Generic;
using Ban3.Productions.Casino.Contracts.Entities;
using Ban3.Productions.Casino.Contracts.Interfaces;
using StockPrice = Ban3.Sites.ViaTushare.Entries.StockPrice;

namespace Ban3.Productions.Casino.Contracts.Extensions;

public static partial class Helper
{
    public static bool PrepareAllCodes(this ICollector _, List<Stock> allCodes = null) => _.Sites.PrepareAllCodesFromTushare(allCodes);

    public static List<Stock> LoadAllCodes(this ICollector _) => _.Sites.LoadAllCodes();

    public static bool PrepareDailyPrices(this ICollector _, List<Stock> allCodes = null) => _.Sites.PrepareAllDailyPrices(allCodes);

    public static bool FixDailyPrices(this ICollector _, List<Stock> allCodes = null) => _.Sites.FixAllDailyPrices(allCodes);

    public static List<StockPrice> LoadDailyPrices(this ICollector _, string code) => _.Sites.LoadOnesDailyPrices(code);

    public static bool PrepareAllEvents(this ICollector _, List<Stock> allCodes = null) => _.Sites.PrepareAllEvents(allCodes);

    public static bool PrepareOnesEvents(this ICollector _, string symbol) => _.Sites.PrepareOnesEvents(symbol);

    public static List<StockEvent> LoadOnesEvents(this ICollector _, string symbol) => _.Sites.LoadOnesEvents(symbol);

    public static bool ReadRealtime(this ICollector _, List<Stock> allCodes = null) => _.Sites.ReadRealtime(allCodes).Result;
}
