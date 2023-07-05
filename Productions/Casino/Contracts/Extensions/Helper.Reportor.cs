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
using Ban3.Infrastructures.Charts.Labels;
using Ban3.Infrastructures.Charts.Styles;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Indicators;
using Ban3.Infrastructures.Indicators.Inputs;
using Ban3.Infrastructures.Indicators.Outputs;
using Ban3.Infrastructures.RuntimeCaching;
using Ban3.Productions.Casino.Contracts.Entities;
using Ban3.Productions.Casino.Contracts.Enums;
using Ban3.Productions.Casino.Contracts.Interfaces;
using Ban3.Productions.Casino.Contracts.Request;
using Ban3.Sites.ViaTushare.Entries;

namespace Ban3.Productions.Casino.Contracts.Extensions;

/// <summary>
/// IReportor扩展方法，报告报表相关
/// </summary>
public static partial class Helper
{
    #region 特征值图表（sankey）

    /// <summary>
    /// 
    /// </summary>
    /// <param name="_"></param>
    /// <param name="title"></param>
    /// <param name="records"></param>
    /// <param name="keys"></param>
    /// <returns></returns>
    public static Diagram CreateSankeyDiagram(
	    this IReportor _,
        string title,
        List<DotRecord> records,
        Dictionary<string, int> keys
    )
    {
        var data =new List<SankeyRecord>();
        var links = new List<SankeyLink>();

        var groups = Infrastructures.Indicators.Helper.FeatureGroups
            .Where(o => new[] { "MACD","DMI","BIAS","KD" }.Contains(o))
            .ToList();

        records = records.Where(o => o.Code.StartsWith("68")).ToList();

        data.AddRange(groups.Select(o => new SankeyRecord
        {
            Name = o,
            ItemStyle = new ItemStyle
            {
                Color =Infrastructures.Indicators.Helper.ColorsDic[o],
                BorderColor = Infrastructures.Indicators.Helper.ColorsDic[o],
            }
        }));

        var features = Infrastructures.Indicators.Helper.Features
            .Where(o => o.Key.StartsWithIn(groups.Select(x => $"{x}.")))
            .ToList();

        data.AddRange(features.Select(o => new SankeyRecord { Name = o.Key }));
        data.AddRange(keys
            .Where( o=>o.Key.StartsWithIn(groups.Select(x => $"{x}.")))
            .Select(o => new SankeyRecord { Name = o.Key }));

        groups
            .ForEach(g =>
            {
                links.AddRange(
                    features
                    .Where(f => f.Key.StartsWith($"{g}."))
                    .Select(f => new SankeyLink { Source = g, Target = f.Key, Value = keys.Where(o=> o.Key.StartsWith($"{f.Key}.")).Sum(o=>o.Value) }));
            });

        var allFeatureDetails= Infrastructures.Indicators.Helper.AllFeatures
            .Where(o => o.Key.StartsWithIn(groups.Select(x => $"{x}.")) && keys.ContainsKey(o.Key))
            .Where(o=>records.Any(x=>x.SetKeys.Any(y=>y==o.Key)))
            .ToList();

        features
            .ForEach(f =>
            {
                links.AddRange(allFeatureDetails
                    .Where(a=>a.Key.StartsWith($"{f.Key}."))
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
                .Where( x=>x.StartsWithIn(groups.Select(y => $"{y}.")))
                .Select(x => new SankeyLink { Source = x, Target = o.Code,Value=1 }));
        });

        var diagram = Infrastructures.Charts.Helper.CreateDiagram();

        diagram.SetTitle(new[] { new Title(title) });

        data = data.Where(x => links.Any(y => y.Source + "" == x.Name||y.Target+""==x.Name)).ToList();

        var series = Infrastructures.Charts.Helper.SankeySeries(data, links);
        series.NodeAlign = "left";

        diagram.AddSeries(series);
        diagram.SetTooltip(new[] { new Tooltip { Trigger = Trigger.Item,TriggerOn=TriggerOn.MouseoverOrClick } });

        return diagram;
    }

    public static List<DotRecord> LoadDotsSankey(
        this IReportor _,
        FocusFilter filter)
    {
        var key = $"{filter.Identity}.Sankey";
        return typeof(DotOfBuyingOrSelling)
            .LocalFile(key)
            .ReadFileAs<List<DotRecord>>();
    }

    #endregion

    #region 特征值图表（treemap）

    /// <summary>
    /// 
    /// </summary>
    /// <param name="_"></param>
    /// <param name="keysDic"></param>
    /// <param name="title"></param>
    /// <returns></returns>
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

    public static Dictionary<string, int> LoadDotsKey(
        this IReportor _,
        FocusFilter filter,
        bool forBuying)
    {
        var key = forBuying ? $"{filter.Identity}.Buying" : $"{filter.Identity}.Selling";
        return typeof(DotOfBuyingOrSelling)
            .LocalFile(key)
            .ReadFileAs<Dictionary<string, int>>();
    }

    public static Dictionary<string, List<DotInfo>> LoadDots(
	    this IReportor _, 
	    FocusFilter filter)
            => Config.CacheKey<DotOfBuyingOrSelling>(filter.Identity)
            .LoadOrSetDefault<Dictionary<string, List<DotInfo>>>(
                typeof(DotOfBuyingOrSelling).LocalFile(filter.Identity)
                );

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
        List<Price> prices,
        LineOfPoint indicatorValue
        )
    {
        var marks=new List<GeneralData>();

        if (_.LoadDots(Config.DefaultFilter).TryGetValue(stock.Code, out var dots))
        {
            if (dots != null && dots.Any())
            {
                marks = dots.Select(dot => dot.IsDotOfBuying
                    ? Infrastructures.Charts.Helper.DotOfBuying(
                        dot.TradeDate,
                        new object[] { dot.TradeDate, dot.Close })
                    : Infrastructures.Charts.Helper.DotOfSelling(
                        dot.TradeDate,
                        new object[] { dot.TradeDate, dot.Close })).ToList();
            }
        }

        return prices.CreateCandlestickDiagram(indicatorValue, marks, stock.Symbol);
    }
    
    public static Diagram MacdDiagram(this IReportor _, Stock stock)
        => stock.Code.MacdDiagram();

    public static Diagram DmiDiagram(this IReportor _, Stock stock)
        =>stock.Code.DmiDiagram();

    public static Diagram KdDiagram(this IReportor _, Stock stock)
        => stock.Code.KdDiagram();

    public static Diagram BiasDiagram(this IReportor _, Stock stock)
        => stock.Code.BiasDiagram();
    
    #endregion

}