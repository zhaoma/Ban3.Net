// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Charts.Elements;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ECharts = Ban3.Infrastructures.Charts.Enums;

namespace Ban3.Infrastructures.Charts.Components;

/// <summary>
/// 平行坐标系
/// https://echarts.apache.org/en/option.html#parallel
/// </summary>
public class Parallel
    : GeneralComponent
{
    /// <summary>
    /// 布局方式
    /// </summary>
    [JsonProperty("layout", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public ECharts.Layout? Layout { get; set; }

    /// <summary>
    /// 维度比较多时，比如有 50+ 的维度，那么就会有 50+ 个轴。那么可能会页面显示不下。
    /// 可以通过 parallel.axisExpandable 来改善显示效果。
    /// 是否允许点击展开折叠 axis。
    /// </summary>
    [JsonProperty("axisExpandable", NullValueHandling = NullValueHandling.Ignore)]
    public bool? AxisExpandable { get; set; }

    /// <summary>
    /// 初始时，以哪个轴为中心展开，这里给出轴的 index。没有默认值，需要手动指定。
    /// </summary>
    [JsonProperty("axisExpandCenter", NullValueHandling = NullValueHandling.Ignore)]
    public int? AxisExpandCenter { get; set; }

    /// <summary>
    /// 初始时，有多少个轴会处于展开状态。建议根据你的维度个数而手动指定。
    /// </summary>
    [JsonProperty("axisExpandCount", NullValueHandling = NullValueHandling.Ignore)]
    public int? AxisExpandCount { get; set; }

    /// <summary>
    /// 在展开状态，轴的间距是多少，单位为像素。
    /// </summary>
    [JsonProperty("axisExpandWidth", NullValueHandling = NullValueHandling.Ignore)]
    public int? AxisExpandWidth { get; set; }

    /// <summary>
    /// 触发展开状态
    /// 'click'：鼠标点击的时候 expand。
    /// 'mousemove'：鼠标悬浮的时候 expand。
    /// </summary>
    [JsonProperty("axisExpandTriggerOn", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public ECharts.TriggerOn? AxisExpandTriggerOn { get; set; }

    /// <summary>
    /// 配置多个 parallelAxis 时，有些值一样的属性，如果书写多遍则比较繁琐，那么可以放置在 parallel.parallelAxisDefault 里。
    /// 在坐标轴初始化前，parallel.parallelAxisDefault 里的配置项，会分别融合进 parallelAxis，形成最终的坐标轴的配置。
    /// </summary>
    [JsonProperty("parallelAxisDefault", NullValueHandling = NullValueHandling.Ignore)]
    public Axes.ParallelAxis? ParallelAxisDefault { get; set; }
}
