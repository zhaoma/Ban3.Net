//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @        2022/10/16 11:50
//  function:	    滑动条型数据区域缩放组件
//  reference:https://echarts.apache.org/zh/option.html#dataZoom-slider
//  ————————————————————————————————————————————————————————————————————————————

using System;
using  Ban3.Infrastructures.Charts.Elements;
using  Ban3.Infrastructures.Charts.Styles;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ECharts =  Ban3.Infrastructures.Charts.Enums;

namespace  Ban3.Infrastructures.Charts.Cogs
{
    /// 
    public class DataZoomSlider
        : DataZoom
    {
        public DataZoomSlider()
        {
            Type = ECharts.DataZoomType.Slider;
        }

        /// <summary>
        /// Background color of title, which is transparent by default.
        /// Color can be represented in RGB, for example 'rgb(128, 128, 128)'. 
        /// RGBA can be used when you need alpha channel, for example 'rgba(128, 128, 128, 0.5)'. 
        /// You may also use hexadecimal format, for example '#ccc'.
        /// </summary>
        [JsonProperty("backgroundColor", NullValueHandling = NullValueHandling.Ignore)]
        public string? BackgroundColor { get; set; }

        /// <summary>
        /// 数据阴影
        /// </summary>
        [JsonProperty("dataBackground", NullValueHandling = NullValueHandling.Ignore)]
        public DataBackground? DataBackground { get; set; }

        /// <summary>
        /// 选中部分数据阴影
        /// </summary>
        [JsonProperty("selectedDataBackground", NullValueHandling = NullValueHandling.Ignore)]
        public DataBackground? SelectedDataBackground { get; set; }

        /// <summary>
        /// 选中范围的填充颜色。
        /// </summary>
        [JsonProperty("fillerColor", NullValueHandling = NullValueHandling.Ignore)]
        public string? FillerColor { get; set; }

        /// <summary>
        /// Stroke color of the text.
        /// </summary>
        [JsonProperty("borderColor", NullValueHandling = NullValueHandling.Ignore)]
        public string? BorderColor { get; set; }

        /// <summary>
        /// 两侧缩放手柄的 icon 形状，支持路径字符串
        /// 默认为：'M-9.35,34.56V42m0-40V9.5m-2,0h4a2,2,0,0,1,2,2v21a2,2,0,0,1-2,2h-4a2,2,0,0,1-2-2v-21A2,2,0,0,1-11.35,9.5Z'
        /// 可以通过 'image://url' 设置为图片，其中 URL 为图片的链接，或者 dataURI。
        /// 可以通过 'path://' 将图标设置为任意的矢量路径。这种方式相比于使用图片的方式，不用担心因为缩放而产生锯齿或模糊，而且可以设置为任意颜色。
        /// </summary>
        [JsonProperty("handleIcon", NullValueHandling = NullValueHandling.Ignore)]
        public string? HandleIcon { get; set; }

        /// <summary>
        /// 控制手柄的尺寸，可以是像素大小，也可以是相对于 dataZoom 组件宽度的百分比，默认跟 dataZoom 宽度相同。
        /// </summary>
        [JsonProperty("handleSize", NullValueHandling = NullValueHandling.Ignore)]
        public object? HandleSize { get; set; }

        /// <summary>
        /// 两侧缩放手柄的样式配置。
        /// </summary>
        [JsonProperty("handleStyle", NullValueHandling = NullValueHandling.Ignore)]
        public GeneralStyle? HandleStyle { get; set; }

        /// <summary>
        /// 移动手柄中间的 icon
        /// </summary>
        [JsonProperty("moveHandleIcon", NullValueHandling = NullValueHandling.Ignore)]
        public string? MoveHandleIcon { get; set; }

        /// <summary>
        /// 移动手柄的尺寸高度
        /// </summary>
        [JsonProperty("moveHandleSize", NullValueHandling = NullValueHandling.Ignore)]
        public object? MoveHandleSize { get; set; }

        /// <summary>
        /// 移动手柄的样式配置
        /// </summary>
        [JsonProperty("moveHandleStyle", NullValueHandling = NullValueHandling.Ignore)]
        public GeneralStyle? MoveHandleStyle { get; set; }

        /// <summary>
        /// 显示label的小数精度。默认根据数据自动决定。
        /// </summary>
        [JsonProperty("labelPrecision", NullValueHandling = NullValueHandling.Ignore)]
        public object? LabelPrecision { get; set; }

        /// <summary>
        /// 显示的label的格式化器。
        /// 如果为 string，表示模板，例如：aaaa{value}bbbb，其中{value}会被替换为实际的数值。
        /// 如果为 Function，表示回调函数，例如：
        /// labelFormatter: function (value) { return 'aaa' + value + 'bbb';}
        /// </summary>
        [JsonProperty("labelFormatter", NullValueHandling = NullValueHandling.Ignore)]
        public object? LabelFormatter { get; set; }

        /// <summary>
        /// 是否显示detail，即拖拽时候显示详细数值信息。
        /// </summary>
        [JsonProperty("showDetail", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ShowDetail { get; set; }

        /// <summary>
        /// 是否在 dataZoom-silder 组件中显示数据阴影。数据阴影可以简单地反应数据走势。
        /// </summary>
        [JsonProperty("showDataShadow", NullValueHandling = NullValueHandling.Ignore)]
        public string? ShowDataShadow { get; set; }

        /// <summary>
        /// 拖动时，是否实时更新系列的视图。
        /// 如果为true则拖拽手柄过程中实时更新图表视图。
        /// 如果设置为 false，则只在拖拽结束的时候更新。
        /// </summary>
        [JsonProperty("realtime", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Realtime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("textStyle", NullValueHandling = NullValueHandling.Ignore)]
        public TextStyle? TextStyle { get; set; }
        
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
        public int? Throttle { get; set; } = 100;

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
        /// 是否开启刷选功能
        /// </summary>
        [JsonProperty("brushSelect", NullValueHandling = NullValueHandling.Ignore)]
        public bool? BrushSelect { get; set; } = true;
    }
}
