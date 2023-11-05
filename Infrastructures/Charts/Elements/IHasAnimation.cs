// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ECharts = Ban3.Infrastructures.Charts.Enums;

namespace Ban3.Infrastructures.Charts.Elements;

/// <summary>
/// 
/// </summary>
public interface IHasAnimation
{
    [JsonProperty("animation", NullValueHandling = NullValueHandling.Ignore)]
    bool? Animation { get; set; }

    [JsonProperty("animationThreshold", NullValueHandling = NullValueHandling.Ignore)]
    int? AnimationThreshold { get; set; }

    [JsonProperty("animationDuration", NullValueHandling = NullValueHandling.Ignore)]
    object? AnimationDuration { get; set; }

    [JsonProperty("animationEasing", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    ECharts.EasingEffect? AnimationEasing { get; set; }

    [JsonProperty("animationDelay", NullValueHandling = NullValueHandling.Ignore)]
    object? AnimationDelay { get; set; }

    [JsonProperty("animationDurationUpdate", NullValueHandling = NullValueHandling.Ignore)]
    object? AnimationDurationUpdate { get; set; }

    [JsonProperty("animationEasingUpdate", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    ECharts.EasingEffect? AnimationEasingUpdate { get; set; }

    [JsonProperty("animationDelayUpdate", NullValueHandling = NullValueHandling.Ignore)]
    object? AnimationDelayUpdate { get; set; }
}
