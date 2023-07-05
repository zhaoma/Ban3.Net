/* -------------------------------------------------------------------------------------------------
   Copyright (C) Siemens Healthcare GmbH 2023, All rights reserved. Restricted.
   ------------------------------------------------------------------------------------------------- */
   
using Ban3.Infrastructures.Indicators.Outputs;
using System.Collections.Generic;
using System;
using System.Linq;
using Ban3.Infrastructures.Indicators.Formulas;
using Ban3.Infrastructures.Indicators.Inputs;
using Ban3.Infrastructures.Indicators.Enums;
using StockOperate = Ban3.Infrastructures.Indicators.Outputs.StockOperate;
using Ban3.Infrastructures.Indicators.Entries;
using Ban3.Infrastructures.Charts.Axes;
using Ban3.Infrastructures.Charts.Cogs;
using Ban3.Infrastructures.Charts.Components;
using Ban3.Infrastructures.Charts.Composites;
using Ban3.Infrastructures.Charts.Elements;
using Ban3.Infrastructures.Charts.Entries;
using Ban3.Infrastructures.Charts.Enums;
using Ban3.Infrastructures.Charts.Labels;
using Ban3.Infrastructures.Charts.Styles;
using Ban3.Infrastructures.Charts;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Common;
using System.Collections;

namespace Ban3.Infrastructures.Indicators;

public static partial class Helper
{
    /// <summary>
    /// 行情数据集转指标结果线
    /// </summary>
    /// <param name="prices"></param>
    /// <returns></returns>
    public static LineOfPoint? CalculateIndicators(this List<Price> prices)
        => new Full().Calculate(prices);

    /// <summary>
    /// 结果线转特征集
    /// </summary>
    /// <param name="line"></param>
    /// <returns></returns>
    public static List<StockSets>? LineToSets(this LineOfPoint? line)
    {
        var latestList = line.LatestList();
        if (latestList == null) return null;

        return latestList
            .Select(o => new StockSets
            {
                MarkTime = o.Current!.TradeDate,
                Close = o.Current.Close,
                SetKeys = o.Features()
            })
            .OrderBy(o => o.MarkTime)
            .ToList();
    }

    /// <summary>
    /// 特征集合并
    /// </summary>
    /// <param name="daily"></param>
    /// <param name="weekly"></param>
    /// <param name="monthly"></param>
    /// <returns></returns>
    public static List<StockSets>? MergeWeeklyAndMonthly(
        this List<StockSets>? daily,
        List<StockSets>? weekly,
        List<StockSets>? monthly)
    {
        if (daily == null || !daily.Any()) return daily;

        for (var index = 0; index < daily.Count; index++)
        {
            var keys = daily[index].SetKeys!.Select(o => $"{o}.{StockAnalysisCycle.DAILY}");

            keys = keys.Union(weekly![index].SetKeys!.Select(o => $"{o}.{StockAnalysisCycle.WEEKLY}"));

            keys = keys.Union(monthly![index].SetKeys!.Select(o => $"{o}.{StockAnalysisCycle.MONTHLY}"));

            daily[index].SetKeys = keys;
        }

        return daily;
    }

    /// <summary>
    /// 策略+特征集生成操作建议
    /// </summary>
    /// <param name="profile"></param>
    /// <param name="everydayKeys"></param>
    /// <returns></returns>
    public static List<StockOperate>? OutputDailyOperates(
        this Profile profile,
        List<StockSets>? everydayKeys)
    {
        if (everydayKeys == null || !everydayKeys.Any()) return null;
        
        var operates = everydayKeys.Select(o => new StockOperate
        {
            MarkTime = o.MarkTime,
            Operate = Infrastructures.Indicators.Enums.StockOperate.Left,
            Close = o.Close
        }).ToList();

        var currentOp = Infrastructures.Indicators.Enums.StockOperate.Left;
        for (int op = 0; op < operates.Count(); op++)
        {
            operates[op].Keys = everydayKeys[op].SetKeys != null
                ? everydayKeys[op].SetKeys?.ToList()
                : new List<string>();
            operates[op].Operate = GetOperate(everydayKeys[op].SetKeys!, profile, currentOp);

            currentOp = operates[op].Operate;
        }

        return operates;
    }

    /// <summary>
    /// 操作建议转操作记录
    /// </summary>
    /// <param name="stockOperates"></param>
    /// <param name="code"></param>
    /// <returns></returns>
    public static List<StockOperationRecord>? ConvertToRecords(
        this List<StockOperate>? stockOperates,string code)
    {
        try
        {
            var tradeRecords = new List<StockOperationRecord>();

            if (stockOperates != null && stockOperates.Any())
            {

                foreach (var op in stockOperates)
                {
                    var latest = tradeRecords.Any()
                        ? tradeRecords.Last()
                        : null;

                    if (op.Operate == Enums.StockOperate.Buy)
                    {
                        if (latest == null || latest.SellPrice > 0)
                        {
                            latest = new StockOperationRecord
                            {
                                Code = code,
                                BuyDate = op.MarkTime,
                                BuyPrice = op.Close,

                            };
                            tradeRecords.Add(latest);
                        }
                    }

                    if (op.Operate == Enums.StockOperate.Sell)
                    {
                        if (latest != null)
                        {
                            latest.SellDate = op.MarkTime;
                            latest.SellPrice = op.Close;
                            latest.Ratio = Math.Round((decimal)((op.Close - latest.BuyPrice) / latest.BuyPrice)! * 100M, 2);
                        }
                    }
                }
            }

            return tradeRecords;
        }
        catch (Exception ex)
        {
            Logger.Error($"fault when ConvertOperates2Records {code}");
            Logger.Error(ex);
        }

        return null;
    }

    /// <summary>
    /// 操作记录汇总
    /// </summary>
    /// <param name="records"></param>
    /// <param name="profile"></param>
    /// <returns></returns>
    public static ProfileSummary? RecordsSummary(this List<StockOperationRecord> records, Profile profile)
    {
        var validRecords = records.Where(o => o.SellDate != null && o.BuyPrice > 0).ToList();
        if (!validRecords.Any()) return null;

            return new ProfileSummary
            {
                Identity = profile.Identity,
                StockCount = 1,
                RecordCount = validRecords.Count(),
                RightCount = validRecords.Count(o => o.SellPrice > o.BuyPrice),
                Best = (decimal)validRecords.Max(o => (o.SellPrice - o.BuyPrice) / o.BuyPrice * 100D)!.Value,
                Worst = (decimal)validRecords.Min(o => (o.SellPrice - o.BuyPrice) / o.BuyPrice * 100D)!.Value,
                Average = validRecords.FinalProfit()
            };

    }

    /// <summary>
    /// 个股汇总成策略统计
    /// </summary>
    /// <param name="evaluateSummary"></param>
    /// <param name="one"></param>
    /// <returns></returns>
    public static Dictionary<string, ProfileSummary> MergeSummary(
        this Dictionary<string, ProfileSummary> evaluateSummary,
        ProfileSummary one)
    {
            if (evaluateSummary.TryGetValue(one.Identity, out var summary))
            {
                summary.Best = Math.Max(summary.Best, one.Best);
                summary.Worst = Math.Min(summary.Worst, one.Worst);
                summary.Average = (summary.StockCount * summary.Average + one.Average) /
                                  (summary.StockCount + 1);
                summary.StockCount += 1;
                summary.RecordCount += one.RecordCount;
                summary.RightCount += one.RightCount;

                evaluateSummary[one.Identity] = summary;
            }
            else
            {
                evaluateSummary.Add(one.Identity, one);
            }

            return evaluateSummary;
    }

    /// <summary>
    /// 个股K线以及指标图表
    /// </summary>
    /// <param name="prices"></param>
    /// <param name="indicatorValue"></param>
    /// <param name="marks"></param>
    /// <param name="symbol"></param>
    /// <returns></returns>
    public static Diagram CreateCandlestickDiagram(
        this List<Price> prices,
        LineOfPoint indicatorValue,
        List<GeneralData>? marks,
        string symbol
    )
    {
        var candlestickData = new CandlestickData()
        {
            Records = prices.Select(o => new CandlestickRecord
            {
                TradeDate = o.TradeDate.ToDateTimeEx(),
                Close = o.Close.ToFloat(),
                Open = o.Open.ToFloat(),
                High =o.High.ToFloat(),
                Low = o.Low.ToFloat()
            }).ToList()
        };

        var diagram = Infrastructures.Charts.Helper.CreateDiagram();

        diagram.Toolbox = new Toolbox { Show = false };
        diagram
            .SetTitle(
                new[]
                {
                    new Title($"{symbol}") { Show = false, Left = "5%" }
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

        var candlestickSeries = SeriesType.Candlestick.CreateSeries(symbol, candlestickData.ChartData(), null);

        if (marks != null && marks.Any())
        {
            candlestickSeries.MarkPoint ??= new GeneralMark
            {
                Data = marks
            };
        }

        var now = DateTime.Now;
        var notices = indicatorValue.LineToSets()
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

        var legendDataOne = new List<string> { symbol };

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
        var dailyDiagram =LoadDiagram($"{code}.{StockAnalysisCycle.DAILY}");
        var weeklyDiagram =LoadDiagram($"{code}.{StockAnalysisCycle.WEEKLY}");
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
        this List<StockSets> records,
        string title
    )
    {
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
                Color = Infrastructures.Indicators.Helper.ColorsDic[o],
                BorderColor = Infrastructures.Indicators.Helper.ColorsDic[o],
            }
        }));

        var features = Infrastructures.Indicators.Helper.Features
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

        var allFeatureDetails = Infrastructures.Indicators.Helper.AllFeatures
            .Where(o => o.Key.StartsWithIn(groups.Select(x => $"{x}.")) && keys.ContainsKey(o.Key))
            .Where(o => records.Any(x => x.SetKeys.Any(y => y == o.Key)))
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

            links.AddRange(o.SetKeys
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
}