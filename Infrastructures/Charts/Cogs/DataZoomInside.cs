﻿//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @        2022/10/16 11:50
//  function:	    内置型数据区域缩放组件
//  reference:https://echarts.apache.org/zh/option.html#dataZoom-inside
//  ————————————————————————————————————————————————————————————————————————————

using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ECharts =  Ban3.Infrastructures.Charts.Enums;

namespace  Ban3.Infrastructures.Charts.Cogs;

/// <summary>
/// 内置型数据区域缩放组件（dataZoomInside）
/// </summary>
public class DataZoomInside : DataZoom
{
    public DataZoomInside()
    {
        Type = ECharts.DataZoomType.Inside;
    }

    /// <summary>
    /// 是否停止组件的功能。
    /// </summary>
    [JsonProperty("disabled", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Disabled { get; set; }

    /// <summary>
    /// 指定哪些 xAxis 被控制。如果缺省则控制所有的x轴。如果设置为 false 则不控制任何x轴。
    /// 如果设置成 3 则控制 axisIndex 为 3 的x轴。
    /// 如果设置为 [0, 3] 则控制 axisIndex 为 0 和 3 的x轴。
    /// </summary>
    [JsonProperty("radiusAxisIndex", NullValueHandling = NullValueHandling.Ignore)]
    public object? RadiusAxisIndex { get; set; }

    /// <summary>
    /// 指定哪些 yAxis 被控制。如果缺省则控制所有的y轴。如果设置为 false 则不控制任何y轴。
    /// 如果设置成 3 则控制 axisIndex 为 3 的y轴。
    /// 如果设置为 [0, 3] 则控制 axisIndex 为 0 和 3 的y轴。
    /// </summary>
    [JsonProperty("angleAxisIndex", NullValueHandling = NullValueHandling.Ignore)]
    public object? AngleAxisIndex { get; set; }

    /// <summary>
    /// 数据窗口范围的起始百分比。范围是：0 ~ 100。表示 0% ~ 100%。
    /// dataZoom-inside.start 和 dataZoom-inside.end 共同用 百分比 的形式定义了数据窗口范围。
    /// 
    /// </summary>
    [JsonProperty("start", NullValueHandling = NullValueHandling.Ignore)]
    public int? Start { get; set; }

    /// <summary>
    /// 数据窗口范围的结束百分比。范围是：0 ~ 100。
    /// dataZoom-inside.start 和 dataZoom-inside.end 共同用 百分比 的形式定义了数据窗口范围。
    /// </summary>
    [JsonProperty("end", NullValueHandling = NullValueHandling.Ignore)]
    public int? End { get; set; }

    /// <summary>
    /// 数据窗口范围的起始数值。如果设置了 dataZoom-inside.start 则 startValue 失效。
    /// 注意，如果轴的类型为 category，则 startValue 既可以设置为 axis.data 数组的 index，
    /// 也可以设置为数组值本身。 
    /// 但是如果设置为数组值本身，会在内部自动转化为数组的 index。
    /// </summary>
    [JsonProperty("startValue", NullValueHandling = NullValueHandling.Ignore)]
    public object? StartValue { get; set; }

    /// <summary>
    /// 数据窗口范围的结束数值。如果设置了 dataZoom-inside.end 则 endValue 失效。
    /// 注意，如果轴的类型为 category，则 endValue 即可以设置为 axis.data 数组的 index，
    /// 也可以设置为数组值本身。 
    /// 但是如果设置为数组值本身，会在内部自动转化为数组的 index。
    /// </summary>
    [JsonProperty("endValue", NullValueHandling = NullValueHandling.Ignore)]
    public object? EndValue { get; set; }

    /// <summary>
    /// 用于限制窗口大小的最小值（百分比值），取值范围是 0 ~ 100。
    /// 如果设置了 dataZoom-inside.minValueSpan 则 minSpan 失效。
    /// </summary>
    [JsonProperty("minSpan", NullValueHandling = NullValueHandling.Ignore)]
    public int? MinSpan { get; set; }

    /// <summary>
    /// 用于限制窗口大小的最大值（百分比值），取值范围是 0 ~ 100。
    /// 如果设置了 dataZoom-inside.maxValueSpan 则 maxSpan 失效。
    /// </summary>
    [JsonProperty("maxSpan", NullValueHandling = NullValueHandling.Ignore)]
    public int? MaxSpan { get; set; }

    /// <summary>
    /// 用于限制窗口大小的最小值（实际数值）。
    /// 如在时间轴上可以设置为：3600 * 24 * 1000 * 5 表示 5 天。 在类目轴上可以设置为 5 表示 5 个类目。
    /// </summary>
    [JsonProperty("minValueSpan", NullValueHandling = NullValueHandling.Ignore)]
    public object? MinValueSpan { get; set; }

    /// <summary>
    /// 用于限制窗口大小的最大值（实际数值）。
    /// 如在时间轴上可以设置为：3600 * 24 * 1000 * 5 表示 5 天。 在类目轴上可以设置为 5 表示 5 个类目。
    /// </summary>
    [JsonProperty("maxValueSpan", NullValueHandling = NullValueHandling.Ignore)]
    public object? MaxValueSpan { get; set; }

    /// <summary>
    /// 布局方式是横还是竖。
    /// 不仅是布局方式，对于直角坐标系而言，也决定了，缺省情况控制横向数轴还是纵向数轴。
    /// </summary>
    [JsonProperty("orient", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public ECharts.Orient? Orient { get; set; }

    /// <summary>
    /// 是否锁定选择区域（或叫做数据窗口）的大小。
    /// 如果设置为 true 则锁定选择区域的大小，也就是说，只能平移，不能缩放。
    /// </summary>
    [JsonProperty("zoomLock", NullValueHandling = NullValueHandling.Ignore)]
    public bool? ZoomLock { get; set; }

    /// <summary>
    /// 设置触发视图刷新的频率。单位为毫秒（ms）。
    /// 如果 animation 设为 true 且 animationDurationUpdate 大于 0，
    /// 可以保持 throttle 为默认值 100（或者设置为大于 0 的值），
    /// 否则拖拽时有可能画面感觉卡顿。
    /// 如果 animation 设为 false 或者 animationDurationUpdate 设为 0，
    /// 且在数据量不大时，拖拽时画面感觉卡顿，可以把尝试把 throttle 设为 0 来改善。
    /// </summary>
    [JsonProperty("throttle", NullValueHandling = NullValueHandling.Ignore)]
    public int? Throttle { get; set; }

    /// <summary>
    /// 形式为：[rangeModeForStart, rangeModeForEnd]。
    /// 例如 rangeMode: ['value', 'percent']，表示 start 值取绝对数值，end 取百分比。
    /// 每项可选值为：'value', 'percent'
    /// 'value' 模式：处于此模式下，坐标轴范围（axis extent）总只会被dataZoom.startValue and dataZoom.endValue 决定，
    ///     而不管数据是多少，以及不管，axis.min 和 axis.max 怎么设置。
    /// 'percent' 模式：处于此模式下，100 代表 100% 的 [dMin, dMax]。
    ///     这里 dMin 表示，如果 axis.min 设置了就是 axis.min，否则是 data.extent[0]；
    ///     dMax 表示，如果 axis.max 设置了就是 axis.max，否则是 data.extent[1]。
    ///     [dMin, dMax] 乘以 percent 的结果得到坐标轴范围（axis extent）。
    /// 默认情况下，rangeMode 总是被自动设定。如果指定了 option.start/option.end 那么就设定为 'percent'，
    /// 如果指定了 option.startValue/option.endValue 那么就设定为 'value'。
    /// </summary>
    [JsonProperty("rangeMode", NullValueHandling = NullValueHandling.Ignore)]
    public Array? RangeMode { get; set; }

    /// <summary>
    /// 如何触发缩放。可选值为：
    /// true：表示不按任何功能键，鼠标滚轮能触发缩放。
    /// false：表示鼠标滚轮不能触发缩放。
    /// 'shift'：表示按住 shift 和鼠标滚轮能触发缩放。
    /// 'ctrl'：表示按住 ctrl 和鼠标滚轮能触发缩放。
    /// 'alt'：表示按住 alt 和鼠标滚轮能触发缩放。
    /// </summary>
    [JsonProperty("zoomOnMouseWheel", NullValueHandling = NullValueHandling.Ignore)]
    public object? ZoomOnMouseWheel { get; set; }

    /// <summary>
    /// 如何触发数据窗口平移。可选值为：
    /// true：表示不按任何功能键，鼠标移动能触发数据窗口平移。
    /// false：表示鼠标移动不能触发平移。
    /// 'shift'：表示按住 shift 和鼠标移动能触发数据窗口平移。
    /// 'ctrl'：表示按住 ctrl 和鼠标移动能触发数据窗口平移。
    /// 'alt'：表示按住 alt 和鼠标移动能触发数据窗口平移。
    /// </summary>
    [JsonProperty("moveOnMouseMove", NullValueHandling = NullValueHandling.Ignore)]
    public object? MoveOnMouseMove { get; set; }

    /// <summary>
    /// 如何触发数据窗口平移。可选值为：
    /// true：表示不按任何功能键，鼠标滚轮能触发缩放。
    /// false：表示鼠标滚轮不能触发缩放。
    /// 'shift'：表示按住 shift 和鼠标滚轮能触发缩放。
    /// 'ctrl'：表示按住 ctrl 和鼠标滚轮能触发缩放。
    /// 'alt'：表示按住 alt 和鼠标滚轮能触发缩放。
    /// </summary>
    [JsonProperty("moveOnMouseWheel", NullValueHandling = NullValueHandling.Ignore)]
    public object? MoveOnMouseWheel { get; set; }

    /// <summary>
    /// 是否阻止 mousemove 事件的默认行为。
    /// </summary>
    [JsonProperty("preventDefaultMouseMove", NullValueHandling = NullValueHandling.Ignore)]
    public bool? PreventDefaultMouseMove { get; set; }
}