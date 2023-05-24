using System;
using System.Collections.Generic;
using System.Security.Policy;
using Ban3.Productions.Casino.Contracts.Entities;
using Ban3.Productions.Casino.Contracts.Interfaces;
using Ban3.Sites.ViaTushare.Entries;

namespace Ban3.Productions.Casino.Contracts.Extensions;

public static partial class Helper
{
    public static bool PrepareAllCodes(this ICollector _) => _.Sites.PrepareAllCodesFromTushare();

    public static List<Stock> LoadAllCodes(this ICollector _) => _.Sites.LoadAllCodes();

    public static bool PrepareDailyPrices(this ICollector _) => _.Sites.PrepareAllDailyPrices();

    public static bool FixDailyPrices(this ICollector _) => _.Sites.FixAllDailyPrices();

    public static List<StockPrice> LoadDailyPrices(this ICollector _, string code) => _.Sites.LoadOnesDailyPrices(code);

    public static bool PrepareAllEvents(this ICollector _) => _.Sites.PrepareAllEvents();

    public static bool PrepareOnesEvents(this ICollector _, string symbol) => _.Sites.PrepareOnesEvents(symbol);

    public static List<StockEvent> LoadOnesEvents(this ICollector _, string symbol) => _.Sites.LoadOnesEvents(symbol);
}
