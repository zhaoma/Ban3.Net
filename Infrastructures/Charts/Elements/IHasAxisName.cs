// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
//  WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Charts.Styles;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using ECharts = Ban3.Infrastructures.Charts.Enums;

namespace Ban3.Infrastructures.Charts.Elements;

public interface IHasAxisName
{
    /// <summary>
    /// 名称
    /// </summary>
    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    string? Name { get; set; }

    /// <summary>
    /// Location of axis name.
    /// 'start';'middle' or 'center';'end'
    /// </summary>
    [JsonProperty("nameLocation", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    ECharts.Position? NameLocation { get; set; }

    /// <summary>
    /// Text style of axis name.
    /// </summary>
    [JsonProperty("nameTextStyle", NullValueHandling = NullValueHandling.Ignore)]
    TextStyle? NameTextStyle { get; set; }

    /// <summary>
    /// 指示器名称和指示器轴的距离。
    /// </summary>
    [JsonProperty("nameGap", NullValueHandling = NullValueHandling.Ignore)]
    int? NameGap { get; set; }

    /// <summary>
    /// 坐标轴名字旋转，角度值。
    /// </summary>
    [JsonProperty("nameRotate", NullValueHandling = NullValueHandling.Ignore)]
    int? NameRotate { get; set; }
}
