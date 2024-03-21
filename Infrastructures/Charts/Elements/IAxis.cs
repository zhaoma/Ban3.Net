// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
//  WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Ban3.Infrastructures.Charts.Cogs;
using Ban3.Infrastructures.Charts.Labels;
using Ban3.Infrastructures.Charts.Lines;
using ECharts = Ban3.Infrastructures.Charts.Enums;

namespace Ban3.Infrastructures.Charts.Elements;

public interface IAxis
{
    /// <summary>
    /// 坐标轴类型。
    /// </summary>
    [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    ECharts.AxisType? Type { get; set; }

    /// <summary>
    /// 坐标轴两边留白策略，类目轴和非类目轴的设置和表现不一样。
    /// 默认为 true，这时候刻度只是作为分隔线，标签和数据点都会在两个刻度之间的带(band)中间。
    /// 非类目轴，包括时间，数值，对数轴，boundaryGap是一个两个值的数组，分别表示数据最小值和最大值的延伸范围，可以直接设置数值或者相对的百分比，在设置 min 和 max 后无效。
    /// 示例：boundaryGap: ['20%', '20%']
    /// </summary>
    [JsonProperty("boundaryGap", NullValueHandling = NullValueHandling.Ignore)]
    object? BoundaryGap { get; set; }

    /// <summary>
    /// 坐标轴刻度最小值。
    /// 可以设置成特殊值 'dataMin'，此时取数据在该轴上的最小值作为最小刻度。
    /// 不设置时会自动计算最小值保证坐标轴刻度的均匀分布。
    /// 在类目轴中，也可以设置为类目的序数（如类目轴 data: ['类A', '类B', '类C'] 中，序数 2 表示 '类C'。也可以设置为负数，如 -3）。
    /// 当设置成 function 形式时，可以根据计算得出的数据最大最小值设定坐标轴的最小值。
    /// min: function (value) {return value.min - 20;}
    /// 其中 value 是一个包含 min 和 max 的对象，分别表示数据的最大最小值，这个函数可返回坐标轴的最大值，
    /// 也可返回 null/undefined 来表示“自动计算最大值”（返回 null/undefined 从 v4.8.0 开始支持）。
    /// </summary>
    [JsonProperty("min", NullValueHandling = NullValueHandling.Ignore)]
    object? Min { get; set; }

    /// <summary>
    /// 坐标轴刻度最大值。
    /// 可以设置成特殊值 'dataMax'，此时取数据在该轴上的最大值作为最大刻度。
    /// 不设置时会自动计算最大值保证坐标轴刻度的均匀分布。
    /// 在类目轴中，也可以设置为类目的序数（如类目轴 data: ['类A', '类B', '类C'] 中，序数 2 表示 '类C'。也可以设置为负数，如 -3）。
    /// 当设置成 function 形式时，可以根据计算得出的数据最大最小值设定坐标轴的最小值。
    /// max: function (value) {return value.max - 20;}
    /// 其中 value 是一个包含 min 和 max 的对象，分别表示数据的最大最小值，这个函数可返回坐标轴的最大值，
    /// 也可返回 null/undefined 来表示“自动计算最大值”（返回 null/undefined 从 v4.8.0 开始支持）。
    /// </summary>
    [JsonProperty("max", NullValueHandling = NullValueHandling.Ignore)]
    object? Max { get; set; }

    /// <summary>
    /// 是否是脱离 0 值比例。设置成 true 后坐标刻度不会强制包含零刻度。在双数值轴的散点图中比较有用。
    /// 只在数值轴中（type: 'value'）有效。
    /// 在设置 min 和 max 之后该配置项无效。
    /// </summary>
    [JsonProperty("scale", NullValueHandling = NullValueHandling.Ignore)]
    bool? Scale { get; set; }

    /// <summary>
    /// 坐标轴的分割段数，需要注意的是这个分割段数只是个预估值，最后实际显示的段数会在这个基础上根据分割后坐标轴刻度显示的易读程度作调整。
    /// 在类目轴中无效。
    /// </summary>
    [JsonProperty("splitNumber", NullValueHandling = NullValueHandling.Ignore)]
    int? SplitNumber { get; set; }

    /// <summary>
    /// 自动计算的坐标轴最小间隔大小。
    /// 只在数值轴或时间轴中（type: 'value' 或 'time'）有效。
    /// </summary>
    [JsonProperty("minInterval", NullValueHandling = NullValueHandling.Ignore)]
    int? MinInterval { get; set; }

    /// <summary>
    /// 自动计算的坐标轴最大间隔大小。
    /// 只在数值轴或时间轴中（type: 'value' 或 'time'）有效。
    /// </summary>
    [JsonProperty("maxInterval", NullValueHandling = NullValueHandling.Ignore)]
    int? MaxInterval { get; set; }

    /// <summary>
    /// 强制设置坐标轴分割间隔。
    /// 因为 splitNumber 是预估的值，实际根据策略计算出来的刻度可能无法达到想要的效果，这时候可以使用 interval 配合 min、max 强制设定刻度划分，一般不建议使用。
    /// 无法在类目轴中使用。在时间轴（type: 'time'）中需要传时间戳，在对数轴（type: 'log'）中需要传指数值。
    /// </summary>
    [JsonProperty("interval", NullValueHandling = NullValueHandling.Ignore)]
    object? Interval { get; set; }

    /// <summary>
    /// 对数轴的底数，只在对数轴中（type: 'log'）有效。
    /// </summary>
    [JsonProperty("logBase", NullValueHandling = NullValueHandling.Ignore)]
    int? LogBase { get; set; }

    /// <summary>
    /// 坐标轴是否是静态无法交互。
    /// </summary>
    [JsonProperty("silent", NullValueHandling = NullValueHandling.Ignore)]
    bool? Silent { get; set; }

    /// <summary>
    /// 坐标轴的标签是否响应和触发鼠标事件，默认不响应。
    /// 事件参数如下：
    /// {
    /// // 组件类型，xAxis, yAxis, radiusAxis, angleAxis
    /// // 对应组件类型都会有一个属性表示组件的 index，例如 xAxis 就是 xAxisIndex
    /// componentType: string,
    /// // 未格式化过的刻度值, 点击刻度标签有效
    /// value: '',
    /// // 坐标轴名称, 点击坐标轴名称有效
    /// name: ''
    /// }
    /// </summary>
    [JsonProperty("triggerEvent", NullValueHandling = NullValueHandling.Ignore)]
    bool? TriggerEvent { get; set; }

    /// <summary>
    /// 坐标轴轴线相关设置
    /// </summary>
    [JsonProperty("axisLine", NullValueHandling = NullValueHandling.Ignore)]
    Lines.AxisLine? AxisLine { get; set; }

    /// <summary>
    /// 坐标轴刻度相关设置
    /// </summary>
    [JsonProperty("axisTick", NullValueHandling = NullValueHandling.Ignore)]
    Lines.AxisTick? AxisTick { get; set; }

    /// <summary>
    /// 坐标轴次刻度线相关设置
    /// </summary>
    [JsonProperty("minorTick", NullValueHandling = NullValueHandling.Ignore)]
    Lines.MinorTick? MinorTick { get; set; }

    /// <summary>
    /// 坐标轴刻度标签的相关设置。
    /// </summary>
    [JsonProperty("axisLabel", NullValueHandling = NullValueHandling.Ignore)]
    AxisLabel? AxisLabel { get; set; }

    /// <summary>
    /// 坐标轴在 grid 区域中的分隔线。
    /// </summary>
    [JsonProperty("splitLine", NullValueHandling = NullValueHandling.Ignore)]
    SplitLine? SplitLine { get; set; }

    /// <summary>
    /// 坐标轴在 grid 区域中的次分隔线。次分割线会对齐次刻度线 minorTick
    /// </summary>
    [JsonProperty("minorSplitLine", NullValueHandling = NullValueHandling.Ignore)]
    MinorSplitLine? MinorSplitLine { get; set; }

    /// <summary>
    /// 坐标轴在 grid 区域中的分隔区域，默认不显示。
    /// </summary>
    [JsonProperty("splitArea", NullValueHandling = NullValueHandling.Ignore)]
    SplitArea? SplitArea { get; set; }

    /// <summary>
    /// 类目数据
    /// </summary>
    [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
    object? Data { get; set; }

    /// <summary>
    /// 坐标轴指示器配置项。
    /// </summary>
    [JsonProperty("axisPointer", NullValueHandling = NullValueHandling.Ignore)]
    Cogs.AxisPointer? AxisPointer { get; set; }

    /// <summary>
    /// 是否是反向坐标轴。
    /// </summary>
    [JsonProperty("inverse", NullValueHandling = NullValueHandling.Ignore)]
    bool? Inverse { get; set; }
}