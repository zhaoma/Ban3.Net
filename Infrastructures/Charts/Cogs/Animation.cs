// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ECharts = Ban3.Infrastructures.Charts.Enums;

namespace Ban3.Infrastructures.Charts.Cogs;

/// <summary>
/// 动画配置
/// https://echarts.apache.org/zh/option.html#graphic.elements-group.enterAnimation
/// </summary>
public class Animation
{
    /// <summary>
    /// 动画时长，单位 ms
    /// </summary>
    [JsonProperty("duration", NullValueHandling = NullValueHandling.Ignore)]
    public object? Duration { get; set; }

    /// <summary>
    /// 动画缓动。
    /// </summary>
    [JsonProperty("easing", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public ECharts.EasingEffect? Easing { get; set; }

    /// <summary>
    /// 动画延迟时长，单位 ms
    /// </summary>
    [JsonProperty("delay", NullValueHandling = NullValueHandling.Ignore)]
    public object? Delay { get; set; }
}