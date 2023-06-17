using System.Collections.Generic;
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
using Ban3.Infrastructures.Indicators.Outputs;
using Ban3.Productions.Casino.Contracts.Entities;
using Ban3.Productions.Casino.Contracts.Interfaces;
using Ban3.Productions.Casino.Contracts.Request;
using Ban3.Sites.ViaTushare.Entries;

namespace Ban3.Productions.Casino.Contracts.Extensions;

/// <summary>
/// IReportor扩展方法，报告报表相关
/// </summary>
public static partial class Helper
{
    #region 特征值图表（treemap）

    public static Diagram CreateTreemapDiagram(
        this IReportor _, 
        Dictionary<string, int> keysDic,
	    string title)
    {
        var treemapData = Infrastructures.Indicators.Helper.FeatureGroups.Select(
            g =>
                new TreemapRecord
                {
                    Name = g,
                    Value = keysDic.Where(o => o.Key.StartsWith($"{g}.")).Sum(o => o.Value),
                    Children = Infrastructures.Indicators.Helper.Features
                        .Where(f => f.Key.StartsWith($"{g}."))
                        .Select(f => new TreemapRecord
                        {
                            Name = f.Key,
                            Value = keysDic.Where(o => o.Key.StartsWith($"{f.Key}.")).Sum(o => o.Value),
                            Children = keysDic.Where(o => o.Key.StartsWith($"{f.Key}."))
                                .Select(d => new TreemapRecord
                                {
                                    Name = d.Key,
                                    Value = d.Value
                                }).ToList()
                        })
                        .ToList()
                }).ToList();

        var diagram = Infrastructures.Charts.Helper.CreateDiagram();

        diagram.SetTitle(new [] { new Title(title) {Show = false,Left = "center" } });

        var series = SeriesType.Treemap.CreateSeries(treemapData);
        series.Levels = new List<TreemapLevel>
        {
            new ()
            {
                ItemStyle = new ItemStyle { BorderColor = "#777", BorderWidth = 0, GapWidth = 1 },
                UpperLabel = new Label { Show = false }
            },
            new()
            {
                ItemStyle = new ItemStyle { BorderColor = "#555", BorderWidth = 1, GapWidth =5 },
                Emphasis = new Emphasis { ItemStyle = new ItemStyle{BorderColor = "#ddd"} }
            }
        };

        diagram.AddSeries(series);
        diagram.SetTooltip(new[] { new Tooltip { Formatter = "{b}:{c}" } });

        return diagram;
    }


    #endregion

    #region 个股图表（Candlestick/indicators）

    /// <summary>
    /// init echarts option
    /// </summary>
    /// <param name="_"></param>
    /// <param name="stock"></param>
    /// <param name="prices"></param>
    /// <param name="indicatorValue"></param>
    /// <returns></returns>
    public static Diagram CreateOnesCandlestickDiagram(
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

        diagram.Toolbox = new Toolbox { Show = false };
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
                    new("5%", "5%", "24%", "3%"),
                    new("5%", "5%", "11%", "30%"),
                    new("5%", "5%", "11%", "44%"),
                    new("5%", "5%", "8%", "58%"),
                    new("5%", "5%", "8%", "69%"),
                    new("5%", "5%", "8%", "80%"),
                    new("5%", "5%", "8%", "91%")
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
            new Legend(legendDataOne,"5%","0" ),
            new Legend(legendAmount,"5%","30%" ),
            new Legend(legendMACD,"5%","42%" ),
            new Legend(legendDMI,"5%","55%" ),
            new Legend(legendKD,"5%","68%" ),
            new Legend(legendBIAS,"5%","80%" ),
            new Legend(legendCCI,"5%","89%" ),

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
            var color = Infrastructures.Charts.Helper.Red;
            switch (line.Days)
            {
                case 5:
                    color = Infrastructures.Charts.Helper.Yellow;
                    break;
                case 10:
                    color = Infrastructures.Charts.Helper.Purple;
                    break;
            }
            var s = SeriesType.Line.CreateSeries(
                $"AMOUNT.{line.Days}",
                indicatorValue.EndPoints?
                    .Select(o => o.Amount.RefAmounts.FindLast(x => x.Days == line.Days)?.Ref)
                    .ToList(),
                index,color);
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
                indicatorValue.EndPoints?
                    .Select(o => o.Bias.RefBIAS).ToList(),
                index),
            SeriesType.Line.CreateSeries(
                "BIAS.MA",
                indicatorValue.EndPoints?
                    .Select(o => o.Bias.RefBIASMA).ToList(),
                index,Infrastructures.Charts.Helper.Yellow)
        };

        legendData = result.Select(o => o.Name).ToList();

        return result.ToArray();
    }

    static Series CCI(this LineOfPoint indicatorValue, int? index, out List<string> legendData)
    {
        var result =SeriesType.Line.CreateSeries(
            "CCI",
            indicatorValue.EndPoints?
                .Select(o => o.Cci.RefCCI).ToList(),
            index);

        result.MarkLine = new Mark
        {
            Symbol = Symbol.None,
            LineStyle = new LineStyle{Color = Infrastructures.Charts.Helper.Red },
            Data=new List<MarkLine>
            {
                new MarkLine {YAxis = 200},
                new MarkLine {YAxis = 100}, 
                new MarkLine {YAxis = -200},
            }
        };

        legendData = new List<string>{"CCI"};

        return result;
    }

    static Series[] DMI(this LineOfPoint indicatorValue, int? index, out List<string> legendData)
    {
        var adx = SeriesType.Line.CreateSeries(
            "DMI.ADX",
            indicatorValue.EndPoints?
                .Select(o => o.Dmi.RefADX).ToList(),
            index, Infrastructures.Charts.Helper.Purple);

        adx.MarkLine = new Mark
        {
            Symbol = Symbol.None,
            LineStyle = new LineStyle { Color = Infrastructures.Charts.Helper.Purple },
            Data = new List<MarkLine>
            {
                new MarkLine {YAxis = 80}
            }
        };

        var result= new[]
        {
            SeriesType.Line.CreateSeries(
                "DMI.PDI",
                indicatorValue.EndPoints?
                    .Select(o => o.Dmi.RefPDI).ToList(),
                index),
            SeriesType.Line.CreateSeries(
                "DMI.MDI",
                indicatorValue.EndPoints?
                    .Select(o => o.Dmi.RefMDI).ToList(),
                index,Infrastructures.Charts.Helper.Yellow),
            adx,
            SeriesType.Line.CreateSeries(
                "DMI.ADXR",
                indicatorValue.EndPoints?
                    .Select(o => o.Dmi.RefADXR).ToList(),
                index,Infrastructures.Charts.Helper.Green)
        };
        legendData = result.Select(o => o.Name).ToList();
        
        return result.ToArray();
    }

    static Series[] ENE(this LineOfPoint indicatorValue, int? index, out List<string> legendData)
    {
        var upper = SeriesType.Line.CreateSeries(
            "ENE.Upper",
            indicatorValue.EndPoints?
                .Select(o => o.Ene.RefUPPER).ToList(),
            index, Infrastructures.Charts.Helper.Red, 2);

        upper.LineStyle!.Type = BorderType.Dotted;

        var ene = SeriesType.Line.CreateSeries(
            "ENE",
            indicatorValue.EndPoints?
                .Select(o => o.Ene.RefENE).ToList(),
            index, Infrastructures.Charts.Helper.Purple, 2);

        ene.LineStyle!.Type = BorderType.Dotted;

        var lower = SeriesType.Line.CreateSeries(
            "ENE.Lower",
            indicatorValue.EndPoints?
                .Select(o => o.Ene.RefLOWER).ToList(),
            index, Infrastructures.Charts.Helper.Yellow, 2);

        lower.LineStyle!.Type = BorderType.Dotted;

        var result= new[]
        {
            upper,ene,lower
        };
        legendData = result.Select(o => o.Name).ToList();

        return result.ToArray();
    }


    static Series[] KD(this LineOfPoint indicatorValue, int? index, out List<string> legendData)
    {
        var k = SeriesType.Line.CreateSeries(
            "KD.K",
            indicatorValue.EndPoints?
                .Select(o => o.Kd.RefK).ToList(),
            index);

        k.MarkLine = new Mark
        {
            Symbol = Symbol.None,
            LineStyle = new LineStyle { Color = Infrastructures.Charts.Helper.Red },
            Data = new List<MarkLine>
            {
                new MarkLine {YAxis = 80},
                new MarkLine {YAxis = 10},
            }
        };

        var result= new[]
        {
            k,
            SeriesType.Line.CreateSeries(
                "KD.D",
                indicatorValue.EndPoints?
                    .Select(o => o.Kd.RefD).ToList(),
                index,Infrastructures.Charts.Helper.Yellow)
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
            var color = Infrastructures.Charts.Helper.Red;
            switch (line.Days)
            {
                case 10:
                    color = Infrastructures.Charts.Helper.Yellow;
                    break;
                case 20:
                    color = Infrastructures.Charts.Helper.Purple;
                    break;
                case 30:
                    color = Infrastructures.Charts.Helper.Green;
                    break;
                case 60:
                    color = Infrastructures.Charts.Helper.Gray;
                    break;
            }

	    
	    var s = SeriesType.Line.CreateSeries(
                $"MA.{line.Days}",
                indicatorValue.EndPoints?
                    .Select(o => o.Ma.RefPrices.FindLast(x => x.Days == line.Days)?.Ref).ToList(),
                index,color);
            result.Add(s);
        }

        legendData = result.Select(o => o.Name).ToList();

        return result.ToArray();
    }

    static Series[] MACD(this LineOfPoint indicatorValue, int? index, out List<string> legendData)
    {
        var result = new[]
        {
            SeriesType.Bar.CreateSeries(
                "MACD",
                indicatorValue.EndPoints?
                    .Select(o => o.Macd.RefMACD).ToList(),
                index),
            SeriesType.Line.CreateSeries(
                "MACD.DEA",
                indicatorValue.EndPoints?
                    .Select(o => o.Macd.RefDEA).ToList(),
                index,Infrastructures.Charts.Helper.Yellow),
            SeriesType.Line.CreateSeries(
                "MACD.DIF",
                indicatorValue.EndPoints?
                    .Select(o => o.Macd.RefDIF).ToList(),
                index)
        };
        legendData = result.Select(o => o.Name).ToList();

        return result.ToArray();
    }

    #endregion

}