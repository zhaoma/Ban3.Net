/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022-09-01 08:00
 * function:            Charts序列元素
 * reference:           https://echarts.apache.org/en/option.html#series
 * —————————————————————————————————————————————————————————————————————————————
 */

using System.Collections.Generic;
using  Ban3.Infrastructures.Charts.Cogs;
using  Ban3.Infrastructures.Charts.Elements;
using  Ban3.Infrastructures.Charts.Styles;
using  Ban3.Infrastructures.Charts.Labels;
using  Ban3.Infrastructures.Charts.Lines;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ECharts =  Ban3.Infrastructures.Charts.Enums;

namespace  Ban3.Infrastructures.Charts.Components;

/// <summary>
/// 序列
/// </summary>
public class Series
    : GeneralComponent, ISeries, IHasSymbol
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("colorBy", NullValueHandling = NullValueHandling.Ignore)]
    public ECharts.ColorBy? ColorBy { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public ECharts.SeriesType Type { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("silent", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Silent { get; set; }

    #region IHasAnimation

    public bool? Animation { get; set; }

    public int? AnimationThreshold { get; set; }

    public object? AnimationDuration { get; set; }

    public ECharts.EasingEffect? AnimationEasing { get; set; }

    public object? AnimationDelay { get; set; }

    public object? AnimationDurationUpdate { get; set; }

    public ECharts.EasingEffect? AnimationEasingUpdate { get; set; }

    public object? AnimationDelayUpdate { get; set; }

    #endregion

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("coordinateSystem", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public ECharts.CoordinateSystem? CoordinateSystem { get; set; }

    /// <summary>
    /// 指定哪些 xAxis 被控制。如果缺省则控制所有的x轴。如果设置为 false 则不控制任何x轴。
    /// 如果设置成 3 则控制 axisIndex 为 3 的x轴。
    /// 如果设置为 [0, 3] 则控制 axisIndex 为 0 和 3 的x轴。
    /// </summary>
    [JsonProperty("xAxisIndex", NullValueHandling = NullValueHandling.Ignore)]
    public object? XAxisIndex { get; set; }

    /// <summary>
    /// 指定哪些 yAxis 被控制。如果缺省则控制所有的y轴。如果设置为 false 则不控制任何y轴。
    /// 如果设置成 3 则控制 axisIndex 为 3 的y轴。
    /// 如果设置为 [0, 3] 则控制 axisIndex 为 0 和 3 的y轴。
    /// </summary>
    [JsonProperty("yAxisIndex", NullValueHandling = NullValueHandling.Ignore)]
    public object? YAxisIndex { get; set; }

    /// <summary>
    /// 使用的极坐标系的 index，在单个图表实例中存在多个极坐标系的时候有用。
    /// </summary>
    [JsonProperty("polarIndex", NullValueHandling = NullValueHandling.Ignore)]
    public int PolarIndex { get; set; }

    /// <summary>
    /// 是否在环形柱条两侧使用圆弧效果。
    /// 仅对极坐标系柱状图有效。
    /// </summary>
    [JsonProperty("roundCap", NullValueHandling = NullValueHandling.Ignore)]
    public bool? RoundCap { get; set; }

    /// <summary>
    /// 是否开启实时排序，用来实现动态排序图效果，
    /// 具体参见手册中动态排序柱状图的教程。
    /// </summary>
    [JsonProperty("realtimeSort", NullValueHandling = NullValueHandling.Ignore)]
    public bool? RealtimeSort { get; set; }

    /// <summary>
    /// 是否显示柱条的背景色。通过 backgroundStyle 配置背景样式。
    /// </summary>
    [JsonProperty("showBackground", NullValueHandling = NullValueHandling.Ignore)]
    public bool? ShowBackground { get; set; }

    #region IHasSymbol

    /// 
    public ECharts.Symbol? Symbol { get; set; }

    /// 
    public object? SymbolSize { get; set; }

    /// 
    public int? SymbolRotate { get; set; }

    /// 
    public bool? SymbolKeepAspect { get; set; }

    /// 
    public object? SymbolOffset { get; set; }

    #endregion

    /// <summary>
    /// 是否显示 symbol, 
    /// 如果 false 则只有在 tooltip hover 的时候显示。
    /// </summary>
    [JsonProperty("showSymbol", NullValueHandling = NullValueHandling.Ignore)]
    public bool? ShowSymbol { get; set; }

    /// <summary>
    /// TODO
    /// 只在主轴为类目轴（axis.type 为 'category'）时有效。 可选值：
    /// 'auto'：默认，如果有足够空间则显示标志图形，否则随主轴标签间隔隐藏策略。
    /// true：显示所有图形。
    /// false：随主轴标签间隔隐藏策略。
    /// </summary>
    [JsonProperty("showAllSymbol", NullValueHandling = NullValueHandling.Ignore)]
    public string? ShowAllSymbol { get; set; }

    /// <summary>
    /// 是否启用图例 hover 时的联动高亮。
    /// </summary>
    [JsonProperty("legendHoverLink", NullValueHandling = NullValueHandling.Ignore)]
    public bool? LegendHoverLink { get; set; }

    /// <summary>
    /// 数据堆叠，同个类目轴上系列配置相同的 stack 值可以堆叠放置。
    /// 关于如何定制数值的堆叠方式，参见 stackStrategy
    /// </summary>
    [JsonProperty("stack", NullValueHandling = NullValueHandling.Ignore)]
    public string? Stack { get; set; }

    /// <summary>
    /// 堆积数值的策略，前提是stack属性已被设置
    /// </summary>
    [JsonProperty("stackStrategy", NullValueHandling = NullValueHandling.Ignore)]
    public ECharts.StackStrategy? StackStrategy { get; set; }

    /// <summary>
    /// 鼠标悬浮时在图形元素上时鼠标的样式是什么
    /// </summary>
    [JsonProperty("cursor", NullValueHandling = NullValueHandling.Ignore)]
    public string? Cursor { get; set; }

    /// <summary>
    /// 是否连接空数据
    /// </summary>
    [JsonProperty("connectNulls", NullValueHandling = NullValueHandling.Ignore)]
    public bool? ConnectNulls { get; set; }

    /// <summary>
    /// 是否裁剪超出坐标系部分的图形，具体裁剪效果根据系列决定：
    /// 散点图/带有涟漪特效动画的散点（气泡）图：忽略中心点超出坐标系的图形，但是不裁剪单个图形
    /// 柱状图：裁掉完全超出的柱子，但是不会裁剪只超出部分的柱子
    /// 折线图：裁掉所有超出坐标系的折线部分，拐点图形的逻辑按照散点图处理
    /// 路径图：裁掉所有超出坐标系的部分
    /// K 线图：忽略整体都超出坐标系的图形，但是不裁剪单个图形
    /// 自定义系列：裁掉所有超出坐标系的部分
    /// 除了自定义系列，其它系列的默认值都为 true，及开启裁剪，
    /// 如果你觉得不想要裁剪的话，可以设置成 false 关闭。
    /// </summary>
    [JsonProperty("clip", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Clip { get; set; }

    /// <summary>
    /// 线条和区域面积是否触发事件
    /// </summary>
    [JsonProperty("triggerLineEvent", NullValueHandling = NullValueHandling.Ignore)]
    public bool? TriggerLineEvent { get; set; }

    /// <summary>
    /// 是否是阶梯线图。可以设置为 true 显示成阶梯线图，
    /// 也支持设置成 'start', 'middle', 'end' 
    /// 分别配置在当前点，当前点与下个点的中间点，下个点拐弯。
    /// </summary>
    [JsonProperty("step", NullValueHandling = NullValueHandling.Ignore)]
    public string? Step { get; set; }

    /// <summary>
    /// 每一个柱条的背景样式。需要将 showBackground 设置为 true 时才有效。
    /// </summary>
    [JsonProperty("backgroundStyle", NullValueHandling = NullValueHandling.Ignore)]
    public GeneralStyle? BackgroundStyle { get; set; }

    /// <summary>
    /// 图形上的文本标签，可用于说明图形的一些数据信息，比如值，名称等。
    /// </summary>
    [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
    public Label? Label { get; set; }

    /// <summary>
    /// 折线端点的标签
    /// </summary>
    [JsonProperty("endLabel", NullValueHandling = NullValueHandling.Ignore)]
    public Label? EndLabel { get; set; }

    /// <summary>
    /// 标签的视觉引导线
    /// </summary>
    [JsonProperty("labelLine", NullValueHandling = NullValueHandling.Ignore)]
    public LabelLine? LabelLine { get; set; }

    /// <summary>
    /// 标签的统一布局配置
    /// </summary>
    [JsonProperty("labelLayout", NullValueHandling = NullValueHandling.Ignore)]
    public LabelLayout? LabelLayout { get; set; }

    [JsonProperty("itemStyle", NullValueHandling = NullValueHandling.Ignore)]
    public GeneralStyle? ItemStyle { get; set; }

    [JsonProperty("lineStyle", NullValueHandling = NullValueHandling.Ignore)]
    public LineStyle? LineStyle { get; set; }

    [JsonProperty("areaStyle", NullValueHandling = NullValueHandling.Ignore)]
    public AreaStyle? AreaStyle { get; set; }

    [JsonProperty("emphasis", NullValueHandling = NullValueHandling.Ignore)]
    public Emphasis? Emphasis { get; set; }

    [JsonProperty("blur", NullValueHandling = NullValueHandling.Ignore)]
    public Emphasis? Blur { get; set; }

    [JsonProperty("select", NullValueHandling = NullValueHandling.Ignore)]
    public Emphasis? Select { get; set; }

    [JsonProperty("selectedMode", NullValueHandling = NullValueHandling.Ignore)]
    public object? SelectedMode { get; set; }

    [JsonProperty("smooth", NullValueHandling = NullValueHandling.Ignore)]
    public object? Smooth { get; set; }

    [JsonProperty("smoothMonotone", NullValueHandling = NullValueHandling.Ignore)]
    public string? SmoothMonotone { get; set; }

    [JsonProperty("sampling", NullValueHandling = NullValueHandling.Ignore)]
    public string? Sampling { get; set; }

    [JsonProperty("dimensions", NullValueHandling = NullValueHandling.Ignore)]
    public object? Dimensions { get; set; }

    [JsonProperty("encode", NullValueHandling = NullValueHandling.Ignore)]
    public object? Encode { get; set; }

    [JsonProperty("seriesLayoutBy", NullValueHandling = NullValueHandling.Ignore)]
    public ECharts.LayoutBy? SeriesLayoutBy { get; set; }

    [JsonProperty("datasetIndex", NullValueHandling = NullValueHandling.Ignore)]
    public int? DataSetIndex { get; set; }

    [JsonProperty("dataGroupId", NullValueHandling = NullValueHandling.Ignore)]
    public string? DataGroupId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
    public object? Data { get; set; }

    [JsonProperty("markPoint", NullValueHandling = NullValueHandling.Ignore)]
    public Mark? MarkPoint { get; set; }

    [JsonProperty("markLine", NullValueHandling = NullValueHandling.Ignore)]
    public Mark? MarkLine { get; set; }


    [JsonProperty("markArea", NullValueHandling = NullValueHandling.Ignore)]
    public Mark? MarkArea { get; set; }

    [JsonProperty("universalTransition", NullValueHandling = NullValueHandling.Ignore)]
    public Transition? UniversalTransition { get; set; }

    [JsonProperty("tooltip", NullValueHandling = NullValueHandling.Ignore)]
    public Tooltip? Tooltip { get; set; }

    [JsonProperty("levels", NullValueHandling = NullValueHandling.Ignore)]
    public List<TreemapLevel>? Levels { get; set; }

    /// <summary>
    /// It indicates the range of saturation (color alpha) for nodes of the series.
    /// The range of values is 0 ~ 1.
    /// For example, colorSaturation can be [0.3, 1].
    /// </summary>
    [JsonProperty("colorSaturation", NullValueHandling = NullValueHandling.Ignore)]
    public object? ColorSaturation { get; set; }
}