//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Charts;
using Ban3.Infrastructures.Charts.Components;
using Ban3.Infrastructures.Charts.Enums;
using Ban3.Infrastructures.Contracts.Entries.CasinoServer;
using System.Collections.Generic;
using System.Linq;

namespace Ban3.Implements.Alpha.Extensions;

/// <summary>
/// 图表的一些静态扩展方法
/// </summary>
public static partial class Helper
{
    public static Series[] AMOUNT(this Result stockResult, int? index, out List<string> legendData)
    {
        var result = new List<Series>
        {
            SeriesType.Bar.CreateSeries(
                "AMOUNT",
                stockResult.Remarks.Select(o => o.DayPrice.Amount).ToList(),
                index),

            SeriesType.Line.CreateSeries(
                $"SHORT",
                stockResult.Remarks.Select(o => o.DayOutput.AMOUNT.Short).ToList(),
                index, Infrastructures.Charts.Helper.Yellow),

            SeriesType.Line.CreateSeries(
                $"LONG",
                stockResult.Remarks.Select(o => o.DayOutput.AMOUNT.Long).ToList(),
                index, Infrastructures.Charts.Helper.Purple)
        };

        legendData = result.Select(o => o.Name!).ToList();

        return result.ToArray();
    }

    public static Series[] MA(this Result stockResult, int? index, out List<string> legendData)
    {
        var result = new List<Series>
        {
            SeriesType.Line.CreateSeries(
                $"SHORT",
                stockResult.Remarks.Select(o => o.DayOutput.MA.Short).ToList(),
                index, Infrastructures.Charts.Helper.Yellow),

            SeriesType.Line.CreateSeries(
                $"LONG",
                stockResult.Remarks.Select(o => o.DayOutput.MA.Long).ToList(),
                index, Infrastructures.Charts.Helper.Purple)
        };

        legendData = result.Select(o => o.Name!).ToList();

        return result.ToArray();
    }

    public static Series[] MACD(this Result stockResult, int? index, out List<string> legendData)
    {
        var result = new[]
        {
            SeriesType.Bar.CreateSeries(
                "MACD",
                stockResult.Remarks.Select(o => o.DayOutput.MACD.Histogram).ToList(),
                index),

            SeriesType.Line.CreateSeries(
                "DIF",
                stockResult.Remarks.Select(o => o.DayOutput.MACD.DIF).ToList(),
                index,Infrastructures.Charts.Helper.Yellow),

            SeriesType.Line.CreateSeries(
                "DEA",
                stockResult.Remarks.Select(o => o.DayOutput.MACD.DEA).ToList(),
                index,Infrastructures.Charts.Helper.Purple)
        };
        legendData = result.Select(o => o.Name!).ToList();

        return result.ToArray();
    }

    public static Series[] MX(this Result stockResult, int? index, out List<string> legendData)
    {
        var result = new List<Series>
        {
            SeriesType.Line.CreateSeries(
                $"Buy",
                stockResult.Remarks.Select(o => o.DayOutput.MX.Buy).ToList(),
                index, Infrastructures.Charts.Helper.Yellow),

            SeriesType.Line.CreateSeries(
                $"Sell",
                stockResult.Remarks.Select(o => o.DayOutput.MX.Sell).ToList(),
                index, Infrastructures.Charts.Helper.Purple)
        };

        legendData = result.Select(o => o.Name!).ToList();

        return result.ToArray();
    }
}
