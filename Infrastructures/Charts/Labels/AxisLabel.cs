// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Charts.Elements;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ECharts = Ban3.Infrastructures.Charts.Enums;

namespace Ban3.Infrastructures.Charts.Labels;

/// <summary>
/// 坐标轴刻度标签的相关设置
/// https://echarts.apache.org/zh/option.html#angleAxis.axisLabel
/// </summary>
public class AxisLabel
    : GeneralLabel
{
    /// <summary>
    /// 坐标轴刻度标签的显示间隔，在类目轴中有效。默认同 axisLabel.interval 一样。
    /// 默认会采用标签不重叠的策略间隔显示标签。
    /// 可以设置成 0 强制显示所有标签。
    /// 如果设置为 1，表示『隔一个标签显示一个标签』，如果值为 2，表示隔两个标签显示一个标签，以此类推。
    /// 可以用数值表示间隔的数据，也可以通过回调函数控制。回调函数格式如下：
    /// (index:number, value: string) => boolean
    /// 第一个参数是类目的 index，第二个值是类目名称，如果跳过则返回 false。
    /// </summary>
    [JsonProperty("interval", NullValueHandling = NullValueHandling.Ignore)]
    public object? Interval { get; set; }

    /// <summary>
    /// 坐标轴刻度标签是否朝内，默认朝外。
    /// </summary>
    [JsonProperty("inside", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Inside { get; set; }

    /// <summary>
    /// 刻度标签与轴线之间的距离。
    /// </summary>
    public int? Margin { get; set; } = 8;

    /// <summary>
    /// 刻度标签的内容格式器，支持字符串模板和回调函数两种形式。
    /// </summary>
    [JsonProperty("formatter", NullValueHandling = NullValueHandling.Ignore)]
    public object? Formatter { get; set; }

    /// <summary>
    /// 是否显示最小 tick 的 label。可取值 true, false, null。
    /// 默认自动判定（即如果标签重叠，不会显示最小 tick 的 label）。
    /// </summary>
    [JsonProperty("showMinLabel", NullValueHandling = NullValueHandling.Ignore)]
    public bool? ShowMinLabel { get; set; }

    /// <summary>
    /// 是否显示最大 tick 的 label。可取值 true, false, null。
    /// 默认自动判定（即如果标签重叠，不会显示最大 tick 的 label）。
    /// </summary>
    [JsonProperty("showMaxLabel", NullValueHandling = NullValueHandling.Ignore)]
    public bool? ShowMaxLabel { get; set; }

    /// <summary>
    /// 是否隐藏重叠的标签。
    /// </summary>
    [JsonProperty("hideOverlap", NullValueHandling = NullValueHandling.Ignore)]
    public bool? HideOverlap { get; set; }

    /// <summary>
    /// 文字超出宽度是否截断或者换行。
    /// </summary>
    [JsonProperty("overflow", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public ECharts.Overflow Overflow { get; set; }

    /// <summary>
    /// 在overflow配置为'truncate'的时候，可以通过该属性配置末尾显示的文本。
    /// </summary>
    [JsonProperty("ellipsis", NullValueHandling = NullValueHandling.Ignore)]
    public string? Ellipsis { get; set; }

    /// <summary>
    /// 在 rich 里面，可以自定义富文本样式。利用富文本样式，可以在标签中做出非常丰富的效果。
    /// </summary>
    [JsonProperty("rich", NullValueHandling = NullValueHandling.Ignore)]
    public object? Rich { get; set; }
}