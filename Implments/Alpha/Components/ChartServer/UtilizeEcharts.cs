//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Implements.Alpha.Extensions;
using Ban3.Infrastructures.Charts;
using Ban3.Infrastructures.Charts.Axes;
using Ban3.Infrastructures.Charts.Cogs;
using Ban3.Infrastructures.Charts.Components;
using Ban3.Infrastructures.Charts.Composites;
using Ban3.Infrastructures.Charts.Elements;
using Ban3.Infrastructures.Charts.Entries;
using Ban3.Infrastructures.Charts.Enums;
using Ban3.Infrastructures.Charts.Labels;
using Ban3.Infrastructures.Charts.Styles;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Contracts.Components;
using Ban3.Infrastructures.Contracts.Entries.CasinoServer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Ban3.Implements.Alpha.Components.ChartServer;

/// <summary>
/// 
/// </summary>
public class UtilizeEcharts : IChartServer
{
    /// <summary>
    /// 个股K线图
    /// </summary>
    /// <param name="stockResult"></param>
    /// <returns></returns>
    public string CandlestickDiagram(Result stockResult)
    {
        if (stockResult == null || stockResult.Stock == null || !stockResult.Remarks.Any())
            return string.Empty;

        var candlestickData = new CandlestickData
        {
            Records = stockResult.Remarks.Select((Remark remark) => new CandlestickRecord
            {
                TradeDate = remark.DayPrice.MarkTime,
                Close = remark.DayPrice.Close.ToFloat(),
                Open = remark.DayPrice.Open.ToFloat(),
                High = remark.DayPrice.High.ToFloat(),
                Low = remark.DayPrice.Low.ToFloat()
            }).ToList()
        };

        Diagram diagram = Ban3.Infrastructures.Charts.Helper.CreateDiagram();
        diagram.Toolbox = new Toolbox
        {
            Show = false
        };
        diagram.SetTitle(new Title[1]
        {
            new Title(stockResult.Stock.Symbol ?? "")
            {
                Show = false,
                Left = "5%"
            }
        }).SetDataZoom(new DataZoom[2]
        {
            new DataZoomInside
            {
                XAxisIndex = "all",
                Start = 90,
                End = 100
            },
            new DataZoomSlider
            {
                XAxisIndex = "all"
            }
        }).SetGrid(new Grid[4]
        {
            new Grid("5%", "5%", "35%", "10%"),
            new Grid("5%", "5%", "13%", "51%"),
            new Grid("5%", "5%", "13%", "66%"),
            new Grid("5%", "5%", "13%", "81%")
        })
            .SetXAxis(new CartesianAxis[4]
            {
                new CartesianAxis(AxisType.Category, candlestickData.CategoryData(), 0, true),
                new CartesianAxis(AxisType.Category, candlestickData.CategoryData(), 1, false),
                new CartesianAxis(AxisType.Category, candlestickData.CategoryData(), 2, false),
                new CartesianAxis(AxisType.Category, candlestickData.CategoryData(), 3, false)
            })
            .SetYAxis(new CartesianAxis[4]
            {
                new CartesianAxis(scale: true, showSplitArea: true),
                new CartesianAxis(scale: true, showSplitArea: true, 1)
                {
                    Show = false
                },
                new CartesianAxis(scale: true, showSplitArea: true, 2)
                {
                    Show = false
                },
                new CartesianAxis(scale: true, showSplitArea: true, 3)
                {
                    Show = false
                }
            });
        Series candlestickSeries = SeriesType.Candlestick.CreateSeries(stockResult.Stock.Symbol!, candlestickData.ChartData(), null, "#F00", 1, 0.7m);

        diagram.AddSeries(candlestickSeries);
        diagram.AddSeries(stockResult.MA(null, out List<string> legendData));
        List<string> list2 = new List<string> { stockResult.Stock.Symbol! };
        list2.AddRange(legendData);

        diagram.AddSeries(stockResult.AMOUNT(1, out List<string> legendData3));
        diagram.AddSeries(stockResult.MACD(2, out List<string> legendData4));
        diagram.AddSeries(stockResult.MX(3, out List<string> legendData5));
        diagram.SetLegend(new Legend[4]
        {
            new Legend(list2, "5%", "3%"),
            new Legend(legendData3, "5%", "51%"),
            new Legend(legendData4, "5%", "66%"),
            new Legend(legendData5, "5%", "81%")
        });
        diagram.AxisPointer = new AxisPointer
        {
            Link = new object[1]
            {
                new KeyValuePair<string, string>("xAxisIndex", "all")
            },
            Label = new Label
            {
                BackgroundColor = "#777"
            }
        };
        diagram.Brush = new Brush
        {
            XAxisIndex = "all",
            BrushLink = "all",
            OutBrush = new KeyValuePair<string, decimal>("colorAlpha", 0.1m)
        };
        diagram.SetTooltip(new Tooltip[1]
        {
            new Tooltip
            {
                Trigger = Trigger.Axis,
                AxisPointer = new AxisPointer
                {
                    Type = AxisPointerType.Cross
                },
                BorderWidth = 1,
                BorderColor = "#CCC",
                Padding = 10,
                TextStyle = new TextStyle
                {
                    Color = "#000"
                }
            }
        });

        return diagram.ObjToJson();
    }

    /// <summary>
    /// 个股时间线图
    /// </summary>
    /// <param name="stockResult"></param>
    /// <returns></returns>
    public string TimelineDiagram(Result stockResult)
    {
        return string.Empty;
    }

    /// <summary>
    /// 市场矩形树图
    /// </summary>
    /// <param name="stocksSummary"></param>
    /// <returns></returns>
    public string TreemapDiagram(Summary stocksSummary)
    {
        var groups = new List<string> { "60", "68", "30", "4", "8", "0" };
        var codes = stocksSummary.Records.Select(o => o.Code.Substring(0, 3))
            .GroupBy(o => o)
            .Select(o => new KeyValuePair<string, int>(o.Key, o.Count()))
            .ToList();

        var treemapData = groups.Select(
            g =>
                new TreemapRecord
                {
                    Name = g,
                    Value = stocksSummary.Records.Count(o => o.Code.StartsWith($"{g}")),
                    Children = codes
                        .Where(f => f.Key.StartsWith($"{g}"))
                        .Select(f => new TreemapRecord
                        {
                            Name = f.Key,
                            Value = f.Value,
                            Children = stocksSummary.Records.Where(o => o.Code.StartsWith($"{f.Key}"))
                                .Select(d => new TreemapRecord
                                {
                                    Name = $"{d.Code} [{d.LatestClose}]",
                                    Value = Convert.ToInt32(stocksSummary.MarkTime.Subtract(d.Details.FirstOrDefault().BuyTime).TotalDays)
                                }).ToList()
                        })
                        .ToList()
                }).ToList();

        var diagram = Infrastructures.Charts.Helper.CreateDiagram();

        diagram.SetTitle(new[] { new Title($"{stocksSummary.Records.Count} stocks found.") { Show = false, Left = "center" } });

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

        return diagram.ObjToJson();
    }
}
