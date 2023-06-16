//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2022/10/16 11:51
//  function:	VisualMap.cs
//  reference:	https://echarts.apache.org/zh/option.html#visualMap-continuous
//              https://echarts.apache.org/zh/option.html#visualMap-piecewise
//  ————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using ECharts =  Ban3.Infrastructures.Charts.Enums;
using  Ban3.Infrastructures.Charts.Elements;
using  Ban3.Infrastructures.Charts.Styles;

namespace  Ban3.Infrastructures.Charts.Components;

/// <summary>
/// 视觉映射组件
/// </summary>
public class VisualMap
    : GeneralComponent
{
    public VisualMap()
    {
    }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public ECharts.VisualMapType? Type { get; set; }

    /// <summary>
    /// 指定 visualMapContinuous 组件的允许的最小值。'min' 必须用户指定。
    /// [visualMap.min, visualMax.max] 形成了视觉映射的『定义域』。
    /// </summary>
    [JsonProperty("min", NullValueHandling = NullValueHandling.Ignore)]
    public int? Min { get; set; }

    /// <summary>
    /// 指定 visualMapContinuous 组件的允许的最大值。'max' 必须用户指定。
    /// [visualMap.min, visualMax.max] 形成了视觉映射的『定义域』。
    /// </summary>
    [JsonProperty("max", NullValueHandling = NullValueHandling.Ignore)]
    public int? Max { get; set; }

    /// <summary>
    /// 指定手柄对应数值的位置。range 应在 min max 范围内。
    /// </summary>
    [JsonProperty("range", NullValueHandling = NullValueHandling.Ignore)]
    public int[]? Range { get; set; }

    /// <summary>
    /// 是否显示拖拽用的手柄（手柄能拖拽调整选中范围）
    /// </summary>
    [JsonProperty("calculable", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Calculable { get; set; }

    /// <summary>
    /// 拖动时，是否实时更新系列的视图。
    /// 如果为true则拖拽手柄过程中实时更新图表视图。
    /// 如果设置为 false，则只在拖拽结束的时候更新。
    /// </summary>
    [JsonProperty("realtime", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Realtime { get; set; }

    /// <summary>
    /// 是否反转 visualMap 组件
    /// 当inverse为false时，数据大小的位置规则，和直角坐标系相同，即：
    /// 当 visualMap.orient 为'vertical'时，数据上大下小。
    /// 当 visualMap.orient 为'horizontal'时，数据右大左小。
    /// </summary>
    [JsonProperty("inverse", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public bool? Inverse { get; set; }

    /// <summary>
    /// 数据展示的小数精度，默认为0，无小数点。
    /// </summary>
    [JsonProperty("precision", NullValueHandling = NullValueHandling.Ignore)]
    public int? Precision { get; set; }

    /// <summary>
    /// Image width of legend symbol.
    /// </summary>
    [JsonProperty("itemWidth", NullValueHandling = NullValueHandling.Ignore)]
    public int? ItemWidth { get; set; } = 25;

    /// <summary>
    /// Image height of legend symbol.
    /// </summary>
    [JsonProperty("itemHeight", NullValueHandling = NullValueHandling.Ignore)]
    public int? ItemHeight { get; set; } = 14;

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("align", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public ECharts.Align? Align { get; set; }

    /// <summary>
    /// 两端的文本，如 ['High', 'Low']。
    /// </summary>
    [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
    public string[]? Text { get; set; }

    /// <summary>
    /// 两端文字主体之间的距离，单位为px。
    /// </summary>
    [JsonProperty("textGap", NullValueHandling = NullValueHandling.Ignore)]
    public int? TextGap { get; set; } = 10;

    /// <summary>
    /// 指定用数据的『哪个维度』，映射到视觉元素上。『数据』即 series.data。 
    /// </summary>
    [JsonProperty("dimension", NullValueHandling = NullValueHandling.Ignore)]
    public int? Dimension { get; set; }

    /// <summary>
    /// 指定取哪个系列的数据，即哪个系列的 series.data。
    /// 默认取所有系列。
    /// </summary>
    [JsonProperty("seriesIndex", NullValueHandling = NullValueHandling.Ignore)]
    public object? SeriesIndex { get; set; }

    /// <summary>
    /// 打开 hoverLink 功能时，鼠标悬浮到 visualMap 组件上时，
    /// 鼠标位置对应的数值 在 图表中对应的图形元素，会高亮。
    /// 反之，鼠标悬浮到图表中的图形元素上时，
    /// 在 visualMap 组件的相应位置会有三角提示其所对应的数值。
    /// </summary>
    [JsonProperty("hoverLink", NullValueHandling = NullValueHandling.Ignore)]
    public bool? HoverLink { get; set; }

    /// <summary>
    /// 边框颜色。
    /// </summary>
    [JsonProperty("borderColor", NullValueHandling = NullValueHandling.Ignore)]
    public string? BorderColor { get; set; }

    /// <summary>
    /// 边框线宽，单位px。
    /// </summary>
    [JsonProperty("borderWidth", NullValueHandling = NullValueHandling.Ignore)]
    public int? BorderWidth { get; set; }

    /// <summary>
    /// 这个配置项，是为了兼容 ECharts2 而存在，ECharts3 中已经不推荐使用。
    /// 它的功能已经移到了 visualMap-continuous.inRange 和 visualMap-continuous.outOfRange 中。
    /// </summary>
    [JsonProperty("color", NullValueHandling = NullValueHandling.Ignore)]
    public string[]? Color { get; set; }


    /// <summary>
    /// 如何放置 visualMap 组件，水平（'horizontal'）或者竖直（'vertical'）。
    /// </summary>
    [JsonProperty("orient"), JsonConverter(typeof(StringEnumConverter))]
    public ECharts.Orient? Orient { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("textStyle", NullValueHandling = NullValueHandling.Ignore)]
    public TextStyle? TextStyle { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("formatter", NullValueHandling = NullValueHandling.Ignore)]
    public object? Formatter { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("handleIcon", NullValueHandling = NullValueHandling.Ignore)]
    public object? HandleIcon { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("handleSize", NullValueHandling = NullValueHandling.Ignore)]
    public object? HandleSize { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("handleStyle", NullValueHandling = NullValueHandling.Ignore)]
    public GeneralStyle? HandleStyle { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("indicatorIcon", NullValueHandling = NullValueHandling.Ignore)]
    public string? IndicatorIcon { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("indicatorSize", NullValueHandling = NullValueHandling.Ignore)]
    public object? IndicatorSize { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("indicatorStyle", NullValueHandling = NullValueHandling.Ignore)]
    public GeneralStyle? IndicatorStyle { get; set; }
}
