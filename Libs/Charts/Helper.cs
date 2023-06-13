using System;
using System.Collections.Generic;
using Ban3.Infrastructures.Charts.Axes;
using Ban3.Infrastructures.Charts.Cogs;
using Ban3.Infrastructures.Charts.Components;
using Ban3.Infrastructures.Charts.Composites;
using Ban3.Infrastructures.Charts.Styles;
using Ban3.Infrastructures.Common.Attributes;

namespace Ban3.Infrastructures.Charts;

[TracingIt]
public static partial class Helper
{
    public const string White = "#FFF";
    public const string Yellow = "#FC0";
    public const string Purple = "#C09";
    public const string Green = "#3C0";
    public const string Gray = "#CCC";
    public const string Red = "#F00";

    #region Diagram

    /// TODO : init default values
    public static Diagram CreateDiagram()
    {
        return new Diagram();
    }

    public static Diagram SetTitle(this Diagram diagram, Title[] title)
    {
        diagram.Title = title;
        return diagram;
    }

    public static Diagram SetLegend(this Diagram diagram, Legend[] legend)
    {
        diagram.Legend = legend;
        return diagram;
    }


    public static Diagram SetTooltip(this Diagram diagram, Tooltip[] tooltip)
    {
        diagram.Tooltip = tooltip;
        return diagram;
    }

    public static Diagram SetGrid(this Diagram diagram, Grid[] grid)
    {
        diagram.Grid = grid;
        return diagram;
    }

    public static Diagram SetXAxis(this Diagram diagram, CartesianAxis[] axis)
    {
        diagram.XAxis = axis;
        return diagram;
    }

    public static Diagram SetYAxis(this Diagram diagram, CartesianAxis[] axis)
    {
        diagram.YAxis = axis;
        return diagram;
    }

    public static Diagram SetDataZoom(this Diagram diagram, DataZoom[] dataZoom)
    {
        diagram.DataZoom = dataZoom;
        return diagram;
    }

    ///
    public static Diagram AddSeries(
        this Diagram diagram,
        Series series)
    {
        diagram.AddSeries(new[] { series });

        return diagram;
    }

    public static Diagram AddSeries(
        this Diagram diagram,
        Series[] series)
    {
        diagram.Series = diagram.Series ?? new List<Series>();

        diagram.Series.AddRange(series);

        return diagram;
    }

    #endregion

    #region Series

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
            LineStyle = new LineStyle { Opacity =opacity, Width = width, Color = color }
        };
    }

    #endregion
}