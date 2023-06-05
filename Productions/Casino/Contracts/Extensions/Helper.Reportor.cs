using System;
using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Charts;
using Ban3.Infrastructures.Charts.Axes;
using Ban3.Infrastructures.Charts.Cogs;
using Ban3.Infrastructures.Charts.Components;
using Ban3.Infrastructures.Charts.Composites;
using Ban3.Infrastructures.Charts.Elements;
using Ban3.Infrastructures.Charts.Entries;
using Ban3.Infrastructures.Charts.Enums;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Indicators.Formulas.Specials;
using Ban3.Infrastructures.Indicators.Outputs;
using Ban3.Infrastructures.Indicators.Outputs.Values;
using Ban3.Productions.Casino.Contracts.Entities;
using Ban3.Productions.Casino.Contracts.Interfaces;
using Ban3.Sites.ViaTushare.Entries;
using BIAS = Ban3.Infrastructures.Indicators.Outputs.Values.BIAS;

namespace Ban3.Productions.Casino.Contracts.Extensions;

public static partial class Helper
{
    public static Diagram CreateOnesDiagram(
        this IReportor _,
        Stock stock,
        List<StockPrice> prices,
        LineOfPoint indicatorValue)
    {
        var candlestickData = new CandlestickData()
        {
            Records = prices.Select(o => new CandlestickRecord
            {
                TradeDate = o.TradeDate.ToDateTimeEx(),
                Close = o.Close,
                Open = o.Open,
                High = o.High,
                Low = o.Low
            }).ToList()
        };

        var diagram = Infrastructures.Charts.Helper.CreateDiagram();

        diagram
            .SetTitle(
                new[]
                {
                    new Title(stock.Name) { Subtext = stock.Symbol },
                    new Title("AMOUNT") { Top = "40%" },
                    new Title("MACD") { Top = "50%" },
                    new Title("DMI") { Top = "60%" },
                    new Title("KD") { Top = "70%" },
                    new Title("BIAS") { Top = "80%" },
                    new Title("CCI") { Top = "90%" },

                })
            .SetDataZoom(
                new DataZoom[]
                {
                    new DataZoomInside(),
                    new DataZoomSlider()
                })
            .SetGrid(
                new[]
                {
                    new Grid() { Height = "40%" },
                    new Grid() { Height = "10%" },
                    new Grid() { Height = "10%" },
                    new Grid() { Height = "10%" },
                    new Grid() { Height = "10%" },
                    new Grid() { Height = "10%" },
                    new Grid() { Height = "10%" }
                })
            .SetXAxis(
                new SingleAxis[]
                {
                    new SingleAxis(),
                    new SingleAxis(),
                    new SingleAxis(),
                    new SingleAxis(),
                    new SingleAxis(),
                    new SingleAxis(),
                    new SingleAxis(),
                })
            .SetYAxis(
                new SingleAxis[]
                {
                    new SingleAxis(),
                    new SingleAxis(),
                    new SingleAxis(),
                    new SingleAxis(),
                    new SingleAxis(),
                    new SingleAxis(),
                    new SingleAxis(),
                });

        diagram.AddSeries(SeriesType.Candlestick.CreateSeries(stock.Symbol, candlestickData.ChartData(),null));

        diagram.AddSeries(indicatorValue.MA(null));
        diagram.AddSeries(indicatorValue.ENE(null)); 

        diagram.AddSeries(indicatorValue.AMOUNT(prices, 1));
        diagram.AddSeries(indicatorValue.MACD(2));
        diagram.AddSeries(indicatorValue.DMI(3));
        diagram.AddSeries(indicatorValue.KD(4));
        diagram.AddSeries(indicatorValue.BIAS(5));
        diagram.AddSeries(indicatorValue.CCI(6));

        return diagram;
    }

    static Series[] AMOUNT(this LineOfPoint indicatorValue, List<StockPrice> prices, int? index)
    {
        var result = new List<Series>
        {
            SeriesType.Bar.CreateSeries(
                "AMOUNT",
                prices
                    .Select(o => new object[]{o.TradeDate.ToDateTimeEx().ToYmd(), o.Amount}).ToList(),
                index)
        };

        var amount = new Infrastructures.Indicators.Formulas.Specials.AMOUNT();
        foreach (var line in amount.Details)
        {
            var s = SeriesType.Line.CreateSeries(
                $"AMOUNT.{line.Days}",
                indicatorValue.EndPoints
                    .Select(o => new object[] { o.MarkTime.ToYmd(), o.Amount.RefAmounts?.FindLast(o => o.Days == line.Days)?.Ref})
                    .ToList(),
                index);
            result.Add(s);
        }

        return result.ToArray();
    }

    static Series[] BIAS(this LineOfPoint indicatorValue, int? index)
    {
        return new[]
        {
            SeriesType.Line.CreateSeries(
                "BIAS",
                indicatorValue.EndPoints
                    .Select(o=>new object[]{o.MarkTime.ToYmd(),o.Bias.RefBIAS}).ToList(),
                index),
            SeriesType.Line.CreateSeries(
                "BIAS.MA",
                indicatorValue.EndPoints
                    .Select(o=>new object[]{o.MarkTime.ToYmd(),o.Bias.RefBIASMA}).ToList(),
                index)
        };
    }

    static Series CCI(this LineOfPoint indicatorValue, int? index)
    {
        return SeriesType.Line.CreateSeries(
            "CCI",
            indicatorValue.EndPoints
                .Select(o => new object[] { o.MarkTime.ToYmd(), o.Cci.RefCCI}).ToList(),
            index);
    }

    static Series[] DMI(this LineOfPoint indicatorValue, int? index)
    {
        return new[]
        {
            SeriesType.Line.CreateSeries(
                "DMI.PDI",
                indicatorValue.EndPoints
                    .Select(o => new object[]{o.MarkTime.ToYmd(), o.Dmi.RefPDI}).ToList(),
                index),
            SeriesType.Line.CreateSeries(
                "DMI.MDI",
                indicatorValue.EndPoints
                    .Select(o => new object[]{o.MarkTime.ToYmd(), o.Dmi.RefMDI}).ToList(),
                index),
            SeriesType.Line.CreateSeries(
                "DMI.ADX",
                indicatorValue.EndPoints
                    .Select(o => new object[]{o.MarkTime.ToYmd(), o.Dmi.RefADX}).ToList(),
                index),
            SeriesType.Line.CreateSeries(
                "DMI.ADXR",
                indicatorValue.EndPoints
                    .Select(o => new object[]{o.MarkTime.ToYmd(), o.Dmi.RefADXR}).ToList(),
                index)
        };
    }

    static Series[] ENE(this LineOfPoint indicatorValue, int? index)
    {
        return new[]
        {
            SeriesType.Line.CreateSeries(
                "ENE.Upper",
                indicatorValue.EndPoints
                    .Select(o => new object[]{o.MarkTime.ToYmd(), o.Ene.RefUPPER}).ToList(),
                index),
            SeriesType.Line.CreateSeries(
                "ENE",
                indicatorValue.EndPoints
                    .Select(o => new object[]{o.MarkTime.ToYmd(), o.Ene.RefENE}).ToList(),
                index),
            SeriesType.Line.CreateSeries(
                "ENE.Lower",
                indicatorValue.EndPoints
                    .Select(o => new object[]{o.MarkTime.ToYmd(), o.Ene.RefLOWER}).ToList(),
                index)
        };
    }


    static Series[] KD(this LineOfPoint indicatorValue, int? index)
    {
        return new[]
        {
            SeriesType.Line.CreateSeries(
                "KD.K",
                indicatorValue.EndPoints
                    .Select(o => new object[]{o.MarkTime.ToYmd(), o.Kd.RefK}).ToList(),
                index),
            SeriesType.Line.CreateSeries(
                "KD.D",
                indicatorValue.EndPoints
                    .Select(o => new object[]{o.MarkTime.ToYmd(), o.Kd.RefD}).ToList(),
                index)
        };
    }

    static Series[] MA(this LineOfPoint indicatorValue, int? index)
    {
        var result = new List<Series>();

        var ma = new Infrastructures.Indicators.Formulas.Specials.MA();
        foreach (var line in ma.Details)
        {
            var s = SeriesType.Line.CreateSeries(
                $"MA.{line.Days}",
                indicatorValue.EndPoints
                    .Select(o => new object[] { o.MarkTime.ToYmd(), o.Ma.RefPrices?.FindLast(o=>o.Days==line.Days)?.Ref}).ToList(),
                index);
            result.Add(s);
        }

        return result.ToArray();
    }

    static Series[] MACD(this LineOfPoint indicatorValue, int? index)
    {
        return new[]
        {
            SeriesType.Bar.CreateSeries(
                "MACD",
                indicatorValue.EndPoints
                    .Select(o => new object[]{o.MarkTime.ToYmd(), o.Macd.RefMACD}).ToList(),
                index),
            SeriesType.Line.CreateSeries(
                "MACD.DEA",
                indicatorValue.EndPoints
                    .Select(o => new object[]{o.MarkTime.ToYmd(), o.Macd.RefDEA}).ToList(),
                index),
            SeriesType.Line.CreateSeries(
                "MACD.DIF",
                indicatorValue.EndPoints
                    .Select(o => new object[]{o.MarkTime.ToYmd(), o.Macd.RefDIF}).ToList(),
                index)
        };
    }
}