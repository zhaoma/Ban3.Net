// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
//  WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Charts.Elements;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ECharts = Ban3.Infrastructures.Charts.Enums;

namespace Ban3.Infrastructures.Charts.Labels;

/// <summary>
/// 坐标轴刻度标签
/// https://echarts.apache.org/zh/option.html#angleAxis.axisLabel
/// </summary>
public class AxisName
    : GeneralLabel
{
    /// <summary>
    /// 刻度标签的内容格式器，支持字符串模板和回调函数两种形式。
    /// </summary>
    [JsonProperty("formatter", NullValueHandling = NullValueHandling.Ignore)]
    public object? Formatter { get; set; }

    /// <summary>
    /// 文字超出宽度是否截断或者换行。
    /// </summary>
    [JsonProperty("overflow", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public ECharts.Overflow? Overflow { get; set; }

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
