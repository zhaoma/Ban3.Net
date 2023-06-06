//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2022/10/16 12:08
//  function:	区域选择组件
//  reference:	https://echarts.apache.org/en/option.html#brush
//  ————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Charts.Styles;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ECharts =  Ban3.Infrastructures.Charts.Enums;

namespace  Ban3.Infrastructures.Charts.Cogs;

/// <summary>
/// 区域选择组件，用户可以选择图中一部分数据，从而便于向用户展示被选中数据，或者他们的一些统计计算结果。
/// 目前 brush 组件支持的图表类型：scatter、bar、candlestick（parallel 本身自带刷选功能，但并非由 brush 组件来提供）。
/// 点击 toolbox 中的按钮，能够进行『区域选择』、『清除选择』等操作。
/// </summary>
public class Brush
{
    public Brush()
    {
    }

    /// 
    [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
    public string? Id { get; set; }


    /// 
    [JsonProperty("toolbox", NullValueHandling = NullValueHandling.Ignore)]
    public object? ToolBox { get; set; }


    [JsonProperty("brushLink", NullValueHandling = NullValueHandling.Ignore)]
    public object? BrushLink { get; set; }


    [JsonProperty("seriesIndex", NullValueHandling = NullValueHandling.Ignore)]
    public object? SeriesIndex { get; set; }

    [JsonProperty("geoIndex", NullValueHandling = NullValueHandling.Ignore)]
    public object? GeoIndex { get; set; }

    /// <summary>
    /// Assigns which of the xAxisIndex can use brush selecting.
    /// </summary>
    [JsonProperty("xAxisIndex", NullValueHandling = NullValueHandling.Ignore)]
    public object? XAxisIndex { get; set; }

    /// <summary>
    /// Assigns which of the yAxisIndex can use brush selecting.
    /// </summary>
    [JsonProperty("yAxisIndex", NullValueHandling = NullValueHandling.Ignore)]
    public object? YAxisIndex { get; set; }

    /// Default type of brush.
    [JsonProperty("brushType", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public ECharts.BrushType? BrushType { get; set; }

    /// Default brush mode, whose value can be:'single' or 'multiple'
    [JsonProperty("brushMode", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public ECharts.BrushMode? BrushMode { get; set; }

    /// <summary>
    /// Determines whether a selected box can be changed in shape or translated.
    /// </summary>
    [JsonProperty("transformable", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Transformable { get; set; }

    /// <summary>
    /// Default brush style
    /// </summary>
    [JsonProperty("brushStyle", NullValueHandling = NullValueHandling.Ignore)]
    public SelectStyle? BrushStyle { get; set; }

    /// 
    [JsonProperty("throttleType", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public ECharts.ThrottleType? ThrottleType { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("throttleDelay", NullValueHandling = NullValueHandling.Ignore)]
    public int? ThrottleDelay { get; set; }

    /// <summary>
    /// Defined whether clearing all select-boxes on click is enabled when brush.brushMode is 'single'.
    /// </summary>
    [JsonProperty("removeOnClick", NullValueHandling = NullValueHandling.Ignore)]
    public bool? RemoveOnClick { get; set; }

    /// <summary>
    /// Defines visual effects of items in selection.
    /// </summary>
    [JsonProperty("inBrush", NullValueHandling = NullValueHandling.Ignore)]
    public object? InBrush { get; set; }

    /// <summary>
    /// Defines visual effects of items out of selection.
    /// </summary>
    [JsonProperty("outBrush", NullValueHandling = NullValueHandling.Ignore)]
    public object? OutBrush { get; set; }

    /// <summary>
    /// icon path for each icon.
    /// </summary>
    [JsonProperty("z", NullValueHandling = NullValueHandling.Ignore)]
    public int? Z { get; set; }
}
