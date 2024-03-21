// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
//  WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Charts.Components;
using Ban3.Infrastructures.Charts.Entries;
using Ban3.Infrastructures.Charts.Styles;
using System.Collections.Generic;

namespace Ban3.Infrastructures.Charts;

/// <summary>
/// 元素的扩展，填充属性
/// </summary>
public static partial class Helper
{
    #region Series

    public static Series CreateSeries(
        this Enums.SeriesType seriesType,
        object? data)
    {
        return new Series
        {
            Type = seriesType,
            Data = data
        };
    }

    ///
    public static Series CreateSeries(
        this Enums.SeriesType seriesType,
        string name,
        object? data,
        int? index,
        string? color = Red,
        int? width = 1,
        decimal? opacity = 0.7M)
    {
        return new Series
        {
            Name = name,
            Type = seriesType,
            Data = data,
            XAxisIndex = index,
            YAxisIndex = index,
            ShowSymbol = false,
            Smooth = true,
            LineStyle = new LineStyle { Opacity = opacity, Width = width, Color = color }
        };
    }

    public static Series SetAxisIndex(this Series series, int? xAxisIndex,int? yAxisIndex)
    {
        if (xAxisIndex != null)
            series.XAxisIndex = xAxisIndex;

        if (yAxisIndex != null)
            series.YAxisIndex = yAxisIndex;
        
        return series;
    }

    #endregion

    /// <summary>
    /// 桑基图序列线(元素扩展，参数为链接)
    /// </summary>
    /// <param name="data"></param>
    /// <param name="links"></param>
    /// <returns></returns>
    public static Series SankeySeries(this List<SankeyRecord>? data, List<SankeyLink>? links)
    {
        var series = Enums.SeriesType.Sankey
            .CreateSeries(data);

        series.Links = links;

        return series;
    }

}