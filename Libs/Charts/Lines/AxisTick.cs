/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022-09-01 08:00
 * function:            坐标轴刻度
 * reference:https://echarts.apache.org/zh/option.html#angleAxis.axisTick
 * —————————————————————————————————————————————————————————————————————————————
 */

using  Ban3.Infrastructures.Charts.Styles;
using Newtonsoft.Json;

namespace  Ban3.Infrastructures.Charts.Lines;

/// <summary>
/// 坐标轴刻度
/// </summary>
public class AxisTick
{
    /// <summary>
    /// Whether to show label.
    /// </summary>
    [JsonProperty("show", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Show { get; set; } = true;

    /// <summary>
    /// 类目轴中在 boundaryGap 为 true 的时候有效，可以保证刻度线和标签对齐。
    /// </summary>
    [JsonProperty("alignWithLabel", NullValueHandling = NullValueHandling.Ignore)]
    public bool? AlignWithLabel { get; set; }

    /// <summary>
    /// 坐标轴刻度的显示间隔，在类目轴中有效。默认同 axisLabel.interval 一样。
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
    /// 坐标轴刻度是否朝内，默认朝外。
    /// </summary>
    [JsonProperty("inside", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Inside { get; set; }

    /// <summary>
    /// 坐标轴刻度的长度。
    /// </summary>
    [JsonProperty("length", NullValueHandling = NullValueHandling.Ignore)]
    public int Length { get; set; } = 5;

    /// <summary>
    /// 刻度线样式
    /// </summary>
    [JsonProperty("lineStyle", NullValueHandling = NullValueHandling.Ignore)]
    public GeneralStyle? LineStyle { get; set; }
}