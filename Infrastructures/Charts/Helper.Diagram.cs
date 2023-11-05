// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Charts.Axes;
using Ban3.Infrastructures.Charts.Cogs;
using Ban3.Infrastructures.Charts.Components;
using Ban3.Infrastructures.Charts.Composites;
using System.Collections.Generic;

namespace Ban3.Infrastructures.Charts;

/// <summary>
/// diagram扩展，填充图表属性
/// </summary>
public static partial class Helper
{
    public static Diagram CreateDiagram()
    {
        return new Diagram();
    }

    /// <summary>
    /// 标题组件，包含主标题和副标题。
    /// 在 ECharts 2.x 中单个 ECharts 实例最多只能拥有一个标题组件。
    /// 但是在 ECharts 3 中可以存在任意多个标题组件，这在需要标题进行排版，或者单个实例中的多个图表都需要标题时会比较有用。
    /// </summary>
    /// <param name="diagram"></param>
    /// <param name="title"></param>
    /// <returns></returns>
    public static Diagram SetTitle(this Diagram diagram, Title[] title)
    {
        diagram.Title = title;
        return diagram;
    }

    /// <summary>
    /// 图例组件展现了不同系列的标记(symbol)，颜色和名字。可以通过点击图例控制哪些系列不显示。
    /// </summary>
    /// <param name="diagram"></param>
    /// <param name="legend"></param>
    /// <returns></returns>
    public static Diagram SetLegend(this Diagram diagram, Legend[] legend)
    {
        diagram.Legend = legend;
        return diagram;
    }

    /// <summary>
    /// 直角坐标系内绘图网格，单个 grid 内最多可以放置上下两个 X 轴，左右两个 Y 轴。
    /// 可以在网格上绘制折线图，柱状图，散点图（气泡图）。
    /// 在 ECharts 2.x 里单个 echarts 实例中最多只能存在一个 grid 组件，在 ECharts 3 中可以存在任意个 grid 组件。
    /// </summary>
    /// <param name="diagram"></param>
    /// <param name="grid"></param>
    /// <returns></returns>
    public static Diagram SetGrid(this Diagram diagram, Grid[] grid)
    {
        diagram.Grid = grid;
        return diagram;
    }

    /// <summary>
    /// 直角坐标系 grid 中的 x 轴，一般情况下单个 grid 组件最多只能放上下两个 x 轴，多于两个 x 轴需要通过配置 offset 属性防止同个位置多个 x 轴的重叠。
    /// </summary>
    /// <param name="diagram"></param>
    /// <param name="axis"></param>
    /// <returns></returns>
    public static Diagram SetXAxis(this Diagram diagram, CartesianAxis[] axis)
    {
        diagram.XAxis = axis;
        return diagram;
    }

    /// <summary>
    /// 直角坐标系 grid 中的 y 轴，一般情况下单个 grid 组件最多只能放左右两个 y 轴，多于两个 y 轴需要通过配置 offset 属性防止同个位置多个 Y 轴的重叠。
    /// </summary>
    /// <param name="diagram"></param>
    /// <param name="axis"></param>
    /// <returns></returns>
    public static Diagram SetYAxis(this Diagram diagram, CartesianAxis[] axis)
    {
        diagram.YAxis = axis;
        return diagram;
    }

    /// <summary>
    /// Polar coordinate can be used in scatter and line chart.
    /// Every polar coordinate has an angleAxis and a radiusAxis.
    /// </summary>
    /// <param name="diagram"></param>
    /// <param name="polar"></param>
    /// <returns></returns>
    public static Diagram SetPolar(this Diagram diagram, Polar polar)
    {
        diagram.Polar = polar;
        return diagram;
    }

    /// <summary>
    /// 原点去远端
    /// </summary>
    /// <param name="diagram"></param>
    /// <param name="radiusAxis"></param>
    /// <returns></returns>
    public static Diagram SetRadiusAxis(this Diagram diagram, RadiusAxis radiusAxis)
    {
        diagram.RadiusAxis=radiusAxis;
        return diagram;
    }

    /// <summary>
    /// 顺时针旋转
    /// </summary>
    /// <param name="diagram"></param>
    /// <param name="angleAxis"></param>
    /// <returns></returns>
    public static Diagram SetAngleAxis(this Diagram diagram, AngleAxis angleAxis)
    {
        diagram.AngleAxis = angleAxis;
        return diagram;
    }

    /// <summary>
    /// 雷达图坐标系组件，只适用于雷达图。
    /// </summary>
    /// <param name="diagram"></param>
    /// <param name="radar"></param>
    /// <returns></returns>
    public static Diagram SetRadar(this Diagram diagram, Radar radar)
    {
        diagram.Radar = radar;
        return diagram;
    }

    /// <summary>
    ///  用于区域缩放，从而能自由关注细节的数据信息，或者概览数据整体，或者去除离群点的影响
    /// </summary>
    /// <param name="diagram"></param>
    /// <param name="dataZoom"></param>
    /// <returns></returns>
    public static Diagram SetDataZoom(this Diagram diagram, DataZoom[] dataZoom)
    {
        diagram.DataZoom = dataZoom;
        return diagram;
    }

    /// <summary>
    /// 视觉映射组件，用于进行『视觉编码』，也就是将数据映射到视觉元素（视觉通道）
    /// </summary>
    /// <param name="diagram"></param>
    /// <param name="visualMaps"></param>
    /// <returns></returns>
    public static Diagram SetVisualMap(this Diagram diagram, List<VisualMap> visualMaps)
    {
        diagram.VisualMap = visualMaps;
        return diagram;
    }

    /// <summary>
    /// 提示框组件可以设置在多种地方：
    /// 可以设置在全局，即 tooltip
    /// 可以设置在坐标系中，即 grid.tooltip、polar.tooltip、single.tooltip
    /// 可以设置在series中，即 series.tooltip
    /// 可以设置在系列的每个数据项中，即 series.data.tooltip
    /// </summary>
    /// <param name="diagram"></param>
    /// <param name="tooltip"></param>
    /// <returns></returns>
    public static Diagram SetTooltip(this Diagram diagram, Tooltip[] tooltip)
    {
        diagram.Tooltip = tooltip;
        return diagram;
    }

    /// <summary>
    /// 坐标轴指示器是指示坐标轴当前刻度的工具
    /// </summary>
    /// <param name="diagram"></param>
    /// <param name="axisPointer"></param>
    /// <returns></returns>
    public static Diagram SetAxisPointer(this Diagram diagram, AxisPointer axisPointer)
    {
        diagram.AxisPointer = axisPointer;
        return diagram;
    }

    /// <summary>
    /// 工具栏。内置有导出图片，数据视图，动态类型切换，数据区域缩放，重置五个工具。
    /// </summary>
    /// <param name="diagram"></param>
    /// <param name="toolbox"></param>
    /// <returns></returns>
    public static Diagram SetToolbox(this Diagram diagram, Toolbox toolbox)
    {
        diagram.Toolbox = toolbox;
        return diagram;
    }

    /// <summary>
    /// 区域选择组件，用户可以选择图中一部分数据，从而便于向用户展示被选中数据，或者他们的一些统计计算结果
    /// </summary>
    /// <param name="diagram"></param>
    /// <param name="brush"></param>
    /// <returns></returns>
    public static Diagram SetBrush(this Diagram diagram, Brush brush)
    {
        diagram.Brush = brush;
        return diagram;
    }

    /// <summary>
    /// 地理坐标系组件
    /// </summary>
    /// <param name="diagram"></param>
    /// <param name="geo"></param>
    /// <returns></returns>
    public static Diagram SetGeo(this Diagram diagram, Geo geo)
    {
        diagram.Geo = geo;
        return diagram;
    }

    /// <summary>
    /// 平行坐标系组件
    /// </summary>
    /// <param name="diagram"></param>
    /// <param name="parallel"></param>
    /// <returns></returns>
    public static Diagram SetParallel(this Diagram diagram, Parallel parallel)
    {
        diagram.Parallel = parallel;
        return diagram;
    }

    /// <summary>
    /// 平行坐标系中的坐标轴
    /// </summary>
    /// <param name="diagram"></param>
    /// <param name="parallelAxis"></param>
    /// <returns></returns>
    public static Diagram SetParallelAxis(this Diagram diagram, List<ParallelAxis> parallelAxis)
    {
        diagram.ParallelAxis = parallelAxis;
        return diagram;
    }

    /// <summary>
    /// 单轴。可以被应用到散点图中展现一维数据
    /// </summary>
    /// <param name="diagram"></param>
    /// <param name="singleAxis"></param>
    /// <returns></returns>
    public static Diagram SetSingleAxis(this Diagram diagram, List<SingleAxis> singleAxis)
    {
        diagram.SingleAxis = singleAxis;
        return diagram;
    }

    /// <summary>
    /// timeline 组件，提供了在多个 ECharts option 间进行切换、播放等操作的功能
    /// </summary>
    /// <param name="diagram"></param>
    /// <param name="timeline"></param>
    /// <returns></returns>
    public static Diagram SetTimeline(this Diagram diagram, Timeline timeline)
    {
        diagram.Timeline = timeline;
        return diagram;
    }

    /// <summary>
    /// 原生图形元素组件
    /// 可以支持的图形元素包括：image, text, circle, sector, ring, polygon, polyline, rect, line, bezierCurve, arc, group,
    /// </summary>
    /// <param name="diagram"></param>
    /// <param name="graphic"></param>
    /// <returns></returns>
    public static Diagram SetGraphic(this Diagram diagram, List<Graphic> graphic)
    {
        diagram.Graphic = graphic;
        return diagram;
    }

    /// <summary>
    /// 日历坐标系组件来达到日历图效果
    /// </summary>
    /// <param name="diagram"></param>
    /// <param name="calendar"></param>
    /// <returns></returns>
    public static Diagram SetCalendar(this Diagram diagram, List<Calendar> calendar)
    {
        diagram.Calendar = calendar;
        return diagram;
    }

    /// <summary>
    /// 用于单独的数据集声明
    /// </summary>
    /// <param name="diagram"></param>
    /// <param name="dataSet"></param>
    /// <returns></returns>
    public static Diagram SetDataSet(this Diagram diagram, DataSet dataSet)
    {
        diagram.DataSet = dataSet;
        return diagram;
    }

    /// <summary>
    /// 支持自动根据图表配置项智能生成描述
    /// aria: {enabled:true}
    /// </summary>
    /// <param name="diagram"></param>
    /// <param name="aria"></param>
    /// <returns></returns>
    public static Diagram SetAria(this Diagram diagram, Aria aria)
    {
        diagram.Aria = aria;
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

    ///
    public static Diagram AddSeries(
        this Diagram diagram,
        Series[] series)
    {
        diagram.Series ??= new List<Series>();

        diagram.Series.AddRange(series);

        return diagram;
    }
}