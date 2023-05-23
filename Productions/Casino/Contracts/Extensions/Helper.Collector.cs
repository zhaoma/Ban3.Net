using System;
using System.Collections.Generic;
using Ban3.Productions.Casino.Contracts.Entities;
using Ban3.Productions.Casino.Contracts.Interfaces;
using Ban3.Sites.ViaTushare.Entries;

namespace Ban3.Productions.Casino.Contracts.Extensions;

public static partial class Helper
{
    public static bool PrepareAllCodes(this ICollector _)
    {
        return _.Sites.PrepareAllCodesFromTushare();
    }

    public static List<Stock> LoadAllCodes(this ICollector _)
    {
        return _.Sites.LoadAllCodes();
    }

    public static bool PrepareDailyPrices(this ICollector _)
    {
        return _.Sites.PrepareAllDailyPrices();
    }

    public static bool FixDailyPrices(this ICollector _)
    {
        return _.Sites.FixAllDailyPrices();
    }

    public static List<StockPrice> LoadDailyPrices(this ICollector _, string code)
    {
        return _.Sites.LoadOnesDailyPrices(code);
    }
}
