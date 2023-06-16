//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @        2022/10/16 11:50
//  function:	    graphic.elements-group.enterAnimation/updateAnimation 动画配置
//  reference:https://echarts.apache.org/zh/option.html#graphic.elements-group.enterAnimation
//  ————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ECharts =  Ban3.Infrastructures.Charts.Enums;

namespace  Ban3.Infrastructures.Charts.Cogs;

/// <summary>
/// 动画配置
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