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
using Ban3.Infrastructures.Indicators.Entries;
using Ban3.Infrastructures.Indicators.Inputs;
using Ban3.Infrastructures.Indicators.Outputs;
using Ban3.Infrastructures.RuntimeCaching;
using Ban3.Productions.Casino.Contracts.Entities;
using Ban3.Productions.Casino.Contracts.Enums;
using Ban3.Productions.Casino.Contracts.Interfaces;
using Ban3.Productions.Casino.Contracts.Request;
using Ban3.Sites.ViaTushare.Entries;
using Stock = Ban3.Infrastructures.Indicators.Entries.Stock;

namespace Ban3.Productions.Casino.Contracts.Extensions;

/// <summary>
/// IReportor扩展方法，报告报表相关
/// </summary>
public static partial class Helper
{
    #region 特征值图表（sankey）
    

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