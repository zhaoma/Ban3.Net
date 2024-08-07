﻿using Ban3.Infrastructures.Charts.Components;
using Ban3.Infrastructures.Charts.Elements;
using Ban3.Infrastructures.Charts.Enums;
using Ban3.Infrastructures.Charts.Styles;
using Ban3.Infrastructures.Indicators.Inputs;
using Ban3.Infrastructures.Indicators.Outputs;
using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Charts;
using Ban3.Infrastructures.Charts.Axes;
using Ban3.Infrastructures.Charts.Cogs;
using Ban3.Infrastructures.Charts.Composites;
using Ban3.Infrastructures.Charts.Entries;
using Ban3.Infrastructures.Charts.Labels;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Indicators.Enums;
using Ban3.Infrastructures.Indicators.Entries;

namespace Ban3.Infrastructures.Indicators;

/// <summary>
/// 图表创建
/// </summary>
public static partial class Helper
{
    /// <summary>
    /// 个股K线以及指标图表
    /// </summary>
    /// <param name="prices"></param>
    /// <param name="indicatorValue"></param>
    /// <param name="stock"></param>
    /// <returns></returns>
    public static Diagram CreateCandlestickDiagram(
        this List<Price>? prices,
        LineOfPoint indicatorValue,
        Stock stock
    )
    {
        if (prices == null||!prices.Any())
        {
            return new Diagram();
        }

        var candlestickData = new CandlestickData()
        {
            Records = prices.Select(o => new CandlestickRecord
            {
                TradeDate = o.TradeDate,
                Close = o.Close.ToFloat(),
                Open = o.Open.ToFloat(),
                High = o.High.ToFloat(),
                Low = o.Low.ToFloat()
            }).ToList()
        };

        var diagram = Infrastructures.Charts.Helper.CreateDiagram();

        diagram.Toolbox = new Toolbox { Show = false };
        diagram
            .SetTitle(
                new[]
                {
                    new Title($"{stock.Symbol}") { Show = false, Left = "5%" }
                })
            .SetDataZoom(
                new DataZoom[]
                {
                    new DataZoomInside { XAxisIndex = "all", Start = 90, End = 100 },
                    new DataZoomSlider { XAxisIndex = "all" }
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
                    new(true, true, 1) { Show = false },
                    new(true, true, 2) { Show = false },
                    new(true, true, 3) { Show = false },
                    new(true, true, 4) { Show = false },
                    new(true, true, 5) { Show = false },
                    new(true, true, 6) { Show = false }
                });

        var candlestickSeries = SeriesType.Candlestick.CreateSeries(stock.Symbol, candlestickData.ChartData(), null);

        var dotsDic = DefaultFilter.LoadDots();
        if (dotsDic != null && dotsDic.TryGetValue(stock.Code, out var dots))
        {
            candlestickSeries.MarkPoint ??= new GeneralMark
            {
                Data = new List<GeneralData>()
            };

            if (dots != null && dots.Any())
            {
                candlestickSeries.MarkPoint.Data!.AddRange(dots.Select(dot => dot.IsDotOfBuying
                    ? Infrastructures.Charts.Helper.DotOfBuying(
                        dot.TradeDate,
                        new object[] { dot.TradeDate, dot.Close! })
                    : Infrastructures.Charts.Helper.DotOfSelling(
                        dot.TradeDate,
                        new object[] { dot.TradeDate, dot.Close! })).ToList());
            }
        }

        var notices = indicatorValue.LineToSets(stock)!
            .Where(o => o.SetKeys != null && o.SetKeys.Any(x => x.StartsWith("MACD.C0")))
            .Select(o => new object[] { o.MarkTime.ToYmd(), o.Close })
            .ToList();

        if (notices.Any())
        {
            candlestickSeries.MarkPoint ??= new GeneralMark
            {
                Data = new List<GeneralData>()
            };
            notices.ForEach(os =>
            {
                candlestickSeries.MarkPoint.Data!.Add(
                    Infrastructures.Charts.Helper.DotOfNotice(os[0] + ".MACD.CO", os));
            });
        }

        diagram.AddSeries(candlestickSeries);
        diagram.AddSeries(indicatorValue.MA(null, out var legendMA));
        diagram.AddSeries(indicatorValue.ENE(null, out var legendENE));

        var legendDataOne = new List<string> { stock.Symbol };

        legendDataOne.AddRange(legendMA);
        legendDataOne.AddRange(legendENE);

        diagram.AddSeries(indicatorValue.AMOUNT(prices, 1, out var legendAmount));
        diagram.AddSeries(indicatorValue.MACD(2, out var legendMACD));
        diagram.AddSeries(indicatorValue.DMI(3, out var legendDMI));
        diagram.AddSeries(indicatorValue.KD(4, out var legendKD));
        diagram.AddSeries(indicatorValue.BIAS(5, out var legendBIAS));
        diagram.AddSeries(indicatorValue.CCI(6, out var legendCCI));

        diagram.SetLegend(new[]
        {
            new Legend(legendDataOne, "5%", "2%"),
            new Legend(legendAmount, "5%", "30%"),
            new Legend(legendMACD, "5%", "42%"),
            new Legend(legendDMI, "5%", "55%"),
            new Legend(legendKD, "5%", "68%"),
            new Legend(legendBIAS, "5%", "80%"),
            new Legend(legendCCI, "5%", "89%"),

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
                Trigger = Trigger.Axis,
                AxisPointer = new AxisPointer { Type = AxisPointerType.Cross },
                BorderWidth = 1,
                BorderColor = "#CCC",
                Padding = 10,
                TextStyle = new TextStyle() { Color = "#000" }
            }
        });

        return diagram;
    }

    public static Diagram MacdDiagram(this string code)
        => IndicatorDiagram(code, "MACD");

    public static Diagram DmiDiagram(this string code)
        => IndicatorDiagram(code, "DMI");

    public static Diagram KdDiagram(this string code)
        => IndicatorDiagram(code, "KD");

    public static Diagram BiasDiagram(this string code)
        => IndicatorDiagram(code, "BIAS");

    /// <summary>
    /// 指标图表
    /// </summary>
    /// <param name="code"></param>
    /// <param name="indicator"></param>
    /// <returns></returns>
    public static Diagram IndicatorDiagram(string code, string indicator)
    {
        var dailyDiagram = LoadDiagram($"{code}.{StockAnalysisCycle.DAILY}");
        var weeklyDiagram = LoadDiagram($"{code}.{StockAnalysisCycle.WEEKLY}");
        var monthlyDiagram = LoadDiagram($"{code}.{StockAnalysisCycle.MONTHLY}");

        var candlestickSeries = dailyDiagram.Series!.FirstOrDefault(o => o.Type == SeriesType.Candlestick);

        var dailySeries = dailyDiagram.Series!.FindAll(o => o.Name!.StartsWith(indicator));

        dailySeries.ForEach(o => {
            o.XAxisIndex = 1;
            o.YAxisIndex = 1;
        });
        var dailyX1 = dailyDiagram.XAxis![0];
        dailyX1.Show = false;
        var dailyX2 = dailyDiagram.XAxis[1];
        dailyX2.Show = true;

        var weeklySeries = weeklyDiagram.Series!.FindAll(o => o.Name!.StartsWith(indicator));
        var weeklyXAxis = weeklyDiagram.XAxis![0];
        weeklyXAxis.Show = true;
        weeklyXAxis.GridIndex = 2;
        weeklySeries.ForEach(o => {
            o.XAxisIndex = 2;
            o.YAxisIndex = 2;
            o.Name = $"weekly.{o.Name}";
        });
        var monthlySeries = monthlyDiagram.Series!.FindAll(o => o.Name!.StartsWith(indicator));
        var monthlyXAxis = monthlyDiagram.XAxis![0];
        monthlyXAxis.Show = true;
        monthlyXAxis.GridIndex = 3;
        monthlySeries.ForEach(o => {
            o.XAxisIndex = 3;
            o.YAxisIndex = 3;
            o.Name = $"monthly.{o.Name}";
        });

        var diagram = Infrastructures.Charts.Helper.CreateDiagram();

        diagram.Toolbox = new Toolbox { Show = false };

        diagram.SetGrid(
                new Grid[]
                {
                    new("5%", "5%", "24%", "3%"),
                    new("5%", "5%", "20%", "30%"),
                    new("5%", "5%", "20%", "53%"),
                    new("5%", "5%", "20%", "76%")
                })
            .SetDataZoom(
                new DataZoom[]
                {
                    new DataZoomInside { XAxisIndex = "all",Start = 90,End = 100},
                    new DataZoomSlider { XAxisIndex = "all" }
                })
            .SetXAxis(
                new[]
                {
                    dailyX1,
                    dailyX2,
                    weeklyXAxis,
                    monthlyXAxis
                })
            .SetYAxis(
                new CartesianAxis[]
                {
                    new(true, true),
                    new(true, true, 1){Show = false},
                    new(true, true, 2){Show = false},
                    new(true, true, 3){Show = false}
                });

        diagram.AddSeries(candlestickSeries!);
        diagram.AddSeries(dailySeries.ToArray());
        diagram.AddSeries(weeklySeries.ToArray());
        diagram.AddSeries(monthlySeries.ToArray());

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

    /// <summary>
    /// 用特征字典创建treemap
    /// </summary>
    /// <param name="keysDic"></param>
    /// <param name="title"></param>
    /// <returns></returns>
    public static Diagram CreateTreemapDiagram(
    this Dictionary<string, int> keysDic,
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

        diagram.SetTitle(new[] { new Title(title) { Show = false, Left = "center" } });

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

    /// <summary>
    /// 用特征集合创建桑基图
    /// </summary>
    /// <param name="records"></param>
    /// <param name="title"></param>
    /// <returns></returns>
    public static Diagram CreateSankeyDiagram(
        this List<StockSets>? records,
        string title
    )
    {
        if(records==null||!records.Any())return new Diagram();

        var data = new List<SankeyRecord>();
        var links = new List<SankeyLink>();

        var keys = records
        .Where(o => o.SetKeys != null)
        .Select(o => o.SetKeys!)
            .MergeToDictionary();

        var groups = Infrastructures.Indicators.Helper.FeatureGroups
            .Where(o => new[] { "MACD", "DMI", "BIAS", "KD" }.Contains(o))
            .ToList();

        data.AddRange(groups.Select(o => new SankeyRecord
        {
            Name = o,
            ItemStyle = new ItemStyle
            {
                Color = ColorsDic[o],
                BorderColor = ColorsDic[o],
            }
        }));

        var features = Features
            .Where(o => o.Key.StartsWithIn(groups.Select(x => $"{x}.")))
            .ToList();

        data.AddRange(features.Select(o => new SankeyRecord { Name = o.Key }));
        data.AddRange(keys
            .Where(o => o.Key.StartsWithIn(groups.Select(x => $"{x}.")))
            .Select(o => new SankeyRecord { Name = o.Key }));

        groups
            .ForEach(g =>
            {
                links.AddRange(
                    features
                    .Where(f => f.Key.StartsWith($"{g}."))
                    .Select(f => new SankeyLink { Source = g, Target = f.Key, Value = keys.Where(o => o.Key.StartsWith($"{f.Key}.")).Sum(o => o.Value) }));
            });

        var allFeatureDetails = AllFeatures
            .Where(o => o.Key.StartsWithIn(groups.Select(x => $"{x}.")) && keys.ContainsKey(o.Key))
            .Where(o => records.Any(x => x.SetKeys!.Any(y => y == o.Key)))
            .ToList();

        features
            .ForEach(f =>
            {
                links.AddRange(allFeatureDetails
                    .Where(a => a.Key.StartsWith($"{f.Key}."))
                    .Select(a =>
                    {
                        var v = 1;
                        if (keys.TryGetValue(a.Key, out var vv))
                            v = vv;

                        return new SankeyLink { Source = f.Key, Target = a.Key, Value = v };
                    }));
            });

        records.ForEach(o =>
        {
            if (data.All(x => x.Name != o.Code))
                data.Add(new SankeyRecord { Name = o.Code });

            links.AddRange(o.SetKeys!
                .Where(x => x.StartsWithIn(groups.Select(y => $"{y}.")))
                .Select(x => new SankeyLink { Source = x, Target = o.Code, Value = 1 }));
        });

        var diagram = Infrastructures.Charts.Helper.CreateDiagram();

        diagram.SetTitle(new[] { new Title(title) });

        data = data.Where(x => links.Any(y => y.Source + "" == x.Name || y.Target + "" == x.Name)).ToList();

        var series = Infrastructures.Charts.Helper.SankeySeries(data, links);
        series.NodeAlign = "left";

        diagram.AddSeries(series);
        diagram.SetTooltip(new[] { new Tooltip { Trigger = Trigger.Item, TriggerOn = TriggerOn.MouseoverOrClick } });

        return diagram;
    }

    #region indicators

    static Series[] AMOUNT(this LineOfPoint indicatorValue, List<Price> prices, int? index, out List<string> legendData)
    {
        var result = new List<Series>
        {
            SeriesType.Bar.CreateSeries(
                "AMOUNT",
                prices
                    .Select(o => o.Amount).ToList(),
                index)
        };

        var amount = new Formulas.Specials.AMOUNT();
        foreach (var line in amount.Details!)
        {
            var color = Charts.Helper.Red;
            switch (line.Days)
            {
                case 5:
                    color = Charts.Helper.Yellow;
                    break;
                case 10:
                    color = Charts.Helper.Purple;
                    break;
            }
            var s = SeriesType.Line.CreateSeries(
                $"AMOUNT.{line.Days}",
                indicatorValue.EndPoints?
                    .Select(o => o.Amount!.RefAmounts.FindLast(x => x.Days == line.Days)?.Ref)
                    .ToList(),
                index, color);
            result.Add(s);
        }

        legendData = result.Select(o => o.Name!).ToList();

        return result.ToArray();
    }

    static Series[] BIAS(this LineOfPoint indicatorValue, int? index, out List<string> legendData)
    {
        var result = new[]
        {
            SeriesType.Line.CreateSeries(
                "BIAS",
                indicatorValue.EndPoints?
                    .Select(o => o.Bias!.RefBIAS).ToList(),
                index),
            SeriesType.Line.CreateSeries(
                "BIAS.MA",
                indicatorValue.EndPoints?
                    .Select(o => o.Bias!.RefBIASMA).ToList(),
                index,Infrastructures.Charts.Helper.Yellow)
        };

        legendData = result.Select(o => o.Name!).ToList();

        return result.ToArray();
    }

    static Series CCI(this LineOfPoint indicatorValue, int? index, out List<string> legendData)
    {
        var result = SeriesType.Line.CreateSeries(
            "CCI",
            indicatorValue.EndPoints?
                .Select(o => o.Cci!.RefCCI).ToList(),
            index);

        result.MarkLine = new GeneralMark
        {
            Symbol = Symbol.None.ToString().ToLower(),
            LineStyle = new LineStyle { Color = Infrastructures.Charts.Helper.Red },
            Data = new()
            {
                new GeneralData {YAxis = 200},
                new GeneralData {YAxis = 100},
                new GeneralData {YAxis = -200},
            }
        };

        legendData = new List<string> { "CCI" };

        return result;
    }

    static Series[] DMI(this LineOfPoint indicatorValue, int? index, out List<string> legendData)
    {
        var adx = SeriesType.Line.CreateSeries(
            "DMI.ADX",
            indicatorValue.EndPoints?
                .Select(o => o.Dmi!.RefADX).ToList(),
            index, Infrastructures.Charts.Helper.Purple);

        adx.MarkLine = new GeneralMark
        {
            Symbol = Symbol.None.ToString().ToLower(),
            LineStyle = new LineStyle { Color = Infrastructures.Charts.Helper.Purple },
            Data = new()
            {
                new GeneralData {YAxis = 80}
            }
        };

        var result = new[]
        {
            SeriesType.Line.CreateSeries(
                "DMI.PDI",
                indicatorValue.EndPoints?
                    .Select(o => o.Dmi!.RefPDI).ToList(),
                index),
            SeriesType.Line.CreateSeries(
                "DMI.MDI",
                indicatorValue.EndPoints?
                    .Select(o => o.Dmi!.RefMDI).ToList(),
                index,Infrastructures.Charts.Helper.Yellow),
            adx,
            SeriesType.Line.CreateSeries(
                "DMI.ADXR",
                indicatorValue.EndPoints?
                    .Select(o => o.Dmi!.RefADXR).ToList(),
                index,Infrastructures.Charts.Helper.Green)
        };
        legendData = result.Select(o => o.Name!).ToList();

        return result.ToArray();
    }

    static Series[] ENE(this LineOfPoint indicatorValue, int? index, out List<string> legendData)
    {
        var upper = SeriesType.Line.CreateSeries(
            "ENE.Upper",
            indicatorValue.EndPoints?
                .Select(o => o.Ene!.RefUPPER).ToList(),
            index, Infrastructures.Charts.Helper.Red, 2);

        upper.LineStyle!.Type = BorderType.Dotted;

        var ene = SeriesType.Line.CreateSeries(
            "ENE",
            indicatorValue.EndPoints?
                .Select(o => o.Ene!.RefENE).ToList(),
            index, Infrastructures.Charts.Helper.Purple, 2);

        ene.LineStyle!.Type = BorderType.Dotted;

        var lower = SeriesType.Line.CreateSeries(
            "ENE.Lower",
            indicatorValue.EndPoints?
                .Select(o => o.Ene!.RefLOWER).ToList(),
            index, Infrastructures.Charts.Helper.Yellow, 2);

        lower.LineStyle!.Type = BorderType.Dotted;

        var result = new[]
        {
            upper,ene,lower
        };
        legendData = result.Select(o => o.Name!).ToList();

        return result.ToArray();
    }

    static Series[] KD(this LineOfPoint indicatorValue, int? index, out List<string> legendData)
    {
        var k = SeriesType.Line.CreateSeries(
            "KD.K",
            indicatorValue.EndPoints?
                .Select(o => o.Kd!.RefK).ToList(),
            index);

        k.MarkLine = new GeneralMark
        {
            Symbol = Symbol.None.ToString().ToLower(),
            LineStyle = new LineStyle { Color = Infrastructures.Charts.Helper.Red },
            Data = new()
            {
                new GeneralData {YAxis = 80},
                new GeneralData {YAxis = 10},
            }
        };

        var result = new[]
        {
            k,
            SeriesType.Line.CreateSeries(
                "KD.D",
                indicatorValue.EndPoints?
                    .Select(o => o.Kd!.RefD).ToList(),
                index,Infrastructures.Charts.Helper.Yellow)
        };
        legendData = result.Select(o => o.Name!).ToList();

        return result.ToArray();
    }

    static Series[] MA(this LineOfPoint indicatorValue, int? index, out List<string> legendData)
    {
        var result = new List<Series>();

        var ma = new Formulas.Specials.MA();
        if (ma.Details != null)
        {
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
                        .Select(o => o.Ma!.RefPrices.FindLast(x => x.Days == line.Days)?.Ref).ToList(),
                    index, color);
                result.Add(s);
            }
        }

        legendData = result.Select(o => o.Name!).ToList();

        return result.ToArray();
    }

    static Series[] MACD(this LineOfPoint indicatorValue, int? index, out List<string> legendData)
    {
        var result = new[]
        {
            SeriesType.Bar.CreateSeries(
                "MACD",
                indicatorValue.EndPoints?
                    .Select(o => o.Macd!.RefMACD).ToList(),
                index),
            SeriesType.Line.CreateSeries(
                "MACD.DEA",
                indicatorValue.EndPoints?
                    .Select(o => o.Macd!.RefDEA).ToList(),
                index,Infrastructures.Charts.Helper.Yellow),
            SeriesType.Line.CreateSeries(
                "MACD.DIF",
                indicatorValue.EndPoints?
                    .Select(o => o.Macd!.RefDIF).ToList(),
                index)
        };
        legendData = result.Select(o => o.Name!).ToList();

        return result.ToArray();
    }

    #endregion

}