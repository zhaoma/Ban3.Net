﻿using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Charts;
using Ban3.Infrastructures.Charts.Axes;
using Ban3.Infrastructures.Charts.Cogs;
using Ban3.Infrastructures.Charts.Components;
using Ban3.Infrastructures.Charts.Composites;
using Ban3.Infrastructures.Charts.Entries;
using Ban3.Infrastructures.Charts.Enums;
using Ban3.Infrastructures.Charts.Labels;
using Ban3.Infrastructures.Charts.Styles;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Indicators.Inputs;
using Ban3.Infrastructures.Indicators.Outputs;
using Ban3.Productions.Casino.Contracts.Entities;
using Ban3.Productions.Casino.Contracts.Interfaces;
using Ban3.Sites.ViaTushare.Entries;

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
                    new Title($"{stock.Name}.{stock.Code}"){Show =false ,Left = "5%"}
                })
            .SetDataZoom(
                new DataZoom[]
                {
                    new DataZoomInside { XAxisIndex = new[] { 0, 1, 2, 3, 4, 5, 6 } ,Start = 90,End = 100},
                    new DataZoomSlider { XAxisIndex = new[] { 0, 1, 2, 3, 4, 5, 6 } }
                })
            .SetGrid(
                new Grid[]
                {
                    new("5%", "5%", "30%", "3%"),
                    new("5%", "5%", "10%", "38%"),
                    new("5%", "5%", "10%", "50%"),
                    new("5%", "5%", "7%", "60%"),
                    new("5%", "5%", "7%", "70%"),
                    new("5%", "5%", "7%", "80%"),
                    new("5%", "5%", "7%", "90%")
                })
            .SetXAxis(
                new CartesianAxis[]
                {
                    new(AxisType.Category, candlestickData.CategoryData(), 0, true),
                    new(AxisType.Category, candlestickData.CategoryData(), 1, false),
                    new(AxisType.Category, candlestickData.CategoryData(), 2, false),
                    new(AxisType.Category, candlestickData.CategoryData(), 3, false),
                    new(AxisType.Category, candlestickData.CategoryData(), 4, false),
                    new(AxisType.Category, candlestickData.CategoryData(), 5, false),
                    new(AxisType.Category, candlestickData.CategoryData(), 6, false)
                })
            .SetYAxis(
                new CartesianAxis[]
                {
                    new(true, true),
                    new(true, true, 1){Show = false},
                    new(true, true, 2){Show = false},
                    new(true, true, 3){Show = false},
                    new(true, true, 4){Show = false},
                    new(true, true, 5){Show = false},
                    new(true, true, 6){Show = false}
                });
        
        diagram.AddSeries(SeriesType.Candlestick.CreateSeries(stock.Symbol, candlestickData.ChartData(), null));
        diagram.AddSeries(indicatorValue.MA(null, out var legendMA));
        diagram.AddSeries(indicatorValue.ENE(null,out var legendENE));

        var legendDataOne = new List<string> { stock.Symbol };

        legendDataOne.AddRange(legendMA);
        legendDataOne.AddRange(legendENE);
        
        diagram.AddSeries(indicatorValue.AMOUNT(prices, 1, out var legendAmount));
        diagram.AddSeries(indicatorValue.MACD(2,out var legendMACD));
        diagram.AddSeries(indicatorValue.DMI(3,out var legendDMI));
        diagram.AddSeries(indicatorValue.KD(4,out var legendKD));
        diagram.AddSeries(indicatorValue.BIAS(5,out var legendBIAS));
        diagram.AddSeries(indicatorValue.CCI(6,out var legendCCI));

        diagram.SetLegend(new[]
        {
            new Legend(legendDataOne,"5%","3%" ),
            new Legend(legendAmount,"5%","38%" ),
            new Legend(legendMACD,"5%","50%" ),
            new Legend(legendDMI,"5%","60%" ),
            new Legend(legendKD,"5%","70%" ),
            new Legend(legendBIAS,"5%","80%" ),
            new Legend(legendCCI,"5%","90%" ),

        });

        diagram.AxisPointer = new AxisPointer
        {
            Link = new object[] { new KeyValuePair<string, string>("xAxisIndex", "all") },
            Label = new Label { BackgroundColor = "#777" }
        };

        diagram.Brush = new Brush
        {
            XAxisIndex = "all",
            BrushLink = "all",
            OutBrush = new KeyValuePair<string, decimal>("colorAlpha", 0.1M)
        };

        diagram.SetTooltip(new[]
        {
            new Tooltip
            {
                Trigger=Trigger.Axis,
                AxisPointer = new AxisPointer{Type = AxisPointerType.Cross},
                BorderWidth=1,
                BorderColor = "#CCC",
                Padding = 10,
                TextStyle = new TextStyle(){Color = "#000"}
            }
        });

        return diagram;
    }

    static Series[] AMOUNT(this LineOfPoint indicatorValue, List<StockPrice> prices, int? index,out List<string> legendData)
    {
        var result = new List<Series>
        {
            SeriesType.Bar.CreateSeries(
                "AMOUNT",
                prices
                    .Select(o => o.Amount).ToList(),
                index)
        };

        var amount = new Infrastructures.Indicators.Formulas.Specials.AMOUNT();
        foreach (var line in amount.Details)
        {
            var s = SeriesType.Line.CreateSeries(
                $"AMOUNT.{line.Days}",
                indicatorValue.EndPoints
                    .Select(o => o.Amount.RefAmounts?.FindLast(o => o.Days == line.Days)?.Ref)
                    .ToList(),
                index);
            result.Add(s);
        }

        legendData = result.Select(o => o.Name).ToList();

        return result.ToArray();
    }

    static Series[] BIAS(this LineOfPoint indicatorValue, int? index, out List<string> legendData)
    {
        var result= new[]
        {
            SeriesType.Line.CreateSeries(
                "BIAS",
                indicatorValue.EndPoints
                    .Select(o => o.Bias.RefBIAS).ToList(),
                index),
            SeriesType.Line.CreateSeries(
                "BIAS.MA",
                indicatorValue.EndPoints
                    .Select(o => o.Bias.RefBIASMA).ToList(),
                index)
        };

        legendData = result.Select(o => o.Name).ToList();

        return result.ToArray();
    }

    static Series CCI(this LineOfPoint indicatorValue, int? index, out List<string> legendData)
    {
        var result =SeriesType.Line.CreateSeries(
            "CCI",
            indicatorValue.EndPoints
                .Select(o => o.Cci.RefCCI).ToList(),
            index);

        legendData = new List<string>{"CCI"};

        return result;
    }

    static Series[] DMI(this LineOfPoint indicatorValue, int? index, out List<string> legendData)
    {
        var result= new[]
        {
            SeriesType.Line.CreateSeries(
                "DMI.PDI",
                indicatorValue.EndPoints
                    .Select(o => o.Dmi.RefPDI).ToList(),
                index),
            SeriesType.Line.CreateSeries(
                "DMI.MDI",
                indicatorValue.EndPoints
                    .Select(o => o.Dmi.RefMDI).ToList(),
                index),
            SeriesType.Line.CreateSeries(
                "DMI.ADX",
                indicatorValue.EndPoints
                    .Select(o => o.Dmi.RefADX).ToList(),
                index),
            SeriesType.Line.CreateSeries(
                "DMI.ADXR",
                indicatorValue.EndPoints
                    .Select(o => o.Dmi.RefADXR).ToList(),
                index)
        };
        legendData = result.Select(o => o.Name).ToList();

        return result.ToArray();
    }

    static Series[] ENE(this LineOfPoint indicatorValue, int? index, out List<string> legendData)
    {
        var result= new[]
        {
            SeriesType.Line.CreateSeries(
                "ENE.Upper",
                indicatorValue.EndPoints
                    .Select(o => o.Ene.RefUPPER).ToList(),
                index),
            SeriesType.Line.CreateSeries(
                "ENE",
                indicatorValue.EndPoints
                    .Select(o => o.Ene.RefENE).ToList(),
                index),
            SeriesType.Line.CreateSeries(
                "ENE.Lower",
                indicatorValue.EndPoints
                    .Select(o => o.Ene.RefLOWER).ToList(),
                index)
        };
        legendData = result.Select(o => o.Name).ToList();

        return result.ToArray();
    }


    static Series[] KD(this LineOfPoint indicatorValue, int? index, out List<string> legendData)
    {
        var result= new[]
        {
            SeriesType.Line.CreateSeries(
                "KD.K",
                indicatorValue.EndPoints
                    .Select(o => o.Kd.RefK).ToList(),
                index),
            SeriesType.Line.CreateSeries(
                "KD.D",
                indicatorValue.EndPoints
                    .Select(o => o.Kd.RefD).ToList(),
                index)
        };
        legendData = result.Select(o => o.Name).ToList();

        return result.ToArray();
    }

    static Series[] MA(this LineOfPoint indicatorValue, int? index, out List<string> legendData)
    {
        var result = new List<Series>();

        var ma = new Infrastructures.Indicators.Formulas.Specials.MA();
        foreach (var line in ma.Details)
        {
            var s = SeriesType.Line.CreateSeries(
                $"MA.{line.Days}",
                indicatorValue.EndPoints
                    .Select(o => o.Ma.RefPrices?.FindLast(x => x.Days == line.Days)?.Ref).ToList(),
                index);
            result.Add(s);
        }

        legendData = result.Select(o => o.Name).ToList();

        return result.ToArray();
    }

    static Series[] MACD(this LineOfPoint indicatorValue, int? index, out List<string> legendData)
    {
        var result= new[]
        {
            SeriesType.Bar.CreateSeries(
                "MACD",
                indicatorValue.EndPoints
                    .Select(o => o.Macd.RefMACD).ToList(),
                index),
            SeriesType.Line.CreateSeries(
                "MACD.DEA",
                indicatorValue.EndPoints
                    .Select(o => o.Macd.RefDEA).ToList(),
                index),
            SeriesType.Line.CreateSeries(
                "MACD.DIF",
                indicatorValue.EndPoints
                    .Select(o => o.Macd.RefDIF).ToList(),
                index)
        };
        legendData = result.Select(o => o.Name).ToList();

        return result.ToArray();
    }
}