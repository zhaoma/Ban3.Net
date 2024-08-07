﻿// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
//  WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Charts.Styles;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.Charts.Cogs;

/// <summary>
/// 坐标轴在 grid 区域中的分隔区域，默认不显示。
/// https://echarts.apache.org/zh/option.html#angleAxis.splitArea
/// </summary>
public class SplitArea
{
    /// <summary>
    /// 坐标轴分隔线的显示间隔，在类目轴中有效。默认同 axisLabel.interval 一样。
    /// 默认会采用标签不重叠的策略间隔显示标签。
    /// 如果设置为 1，表示『隔一个标签显示一个标签』，如果值为 2，表示隔两个标签显示一个标签，以此类推。
    /// 可以用数值表示间隔的数据，也可以通过回调函数控制。回调函数格式如下：
    /// (index:number, value: string) => boolean
    /// 第一个参数是类目的 index，第二个值是类目名称，如果跳过则返回 false。
    /// </summary>
    [JsonProperty("interval", NullValueHandling = NullValueHandling.Ignore)]
    public object? Interval { get; set; }

    /// <summary>
    /// Whether to show label.
    /// </summary>
    [JsonProperty("show", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Show { get; set; } = true;

    /// <summary>
    /// 分隔区域的样式
    /// </summary>
    [JsonProperty("areaStyle", NullValueHandling = NullValueHandling.Ignore)]
    public AreaStyle? AreaStyle { get; set; }
}