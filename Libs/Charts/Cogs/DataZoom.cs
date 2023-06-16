//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @            2022/10/16 11:51
//  function:	        用于区域缩放，从而能自由关注细节的数据信息，或者概览数据整体，或者去除离群点的影响
//  reference:	https://echarts.apache.org/zh/option.html#dataZoom
//  ————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Charts.Elements;
using  Ban3.Infrastructures.Charts.Styles;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ECharts =  Ban3.Infrastructures.Charts.Enums;

namespace  Ban3.Infrastructures.Charts.Cogs;

/// <summary>
/// 数据区域缩放。目前只支持直角坐标系的缩放。
/// </summary>
public class DataZoom : GeneralComponent
{
    public DataZoom()
    {
    }

    [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public ECharts.DataZoomType? Type { get; set; }

    /// <summary>
    /// 缩放和还原的标题文本
    /// </summary>
    [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
    public DataZoomTitle? Title { get; set; }

    /// <summary>
    /// 缩放和还原的 icon path
    /// </summary>
    [JsonProperty("icon", NullValueHandling = NullValueHandling.Ignore)]
    public DataZoomTitle? Icon { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("iconStyle", NullValueHandling = NullValueHandling.Ignore)]
    public GeneralStyle? IconStyle { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("emphasis", NullValueHandling = NullValueHandling.Ignore)]
    public IconEmphasis? Emphasis { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("filterMode", NullValueHandling = NullValueHandling.Ignore)]
    public string? FilterMode { get; set; }

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
    /// 刷选框样式
    /// </summary>
    [JsonProperty("brushStyle", NullValueHandling = NullValueHandling.Ignore)]
    public GeneralStyle? BrushStyle { get; set; }
}