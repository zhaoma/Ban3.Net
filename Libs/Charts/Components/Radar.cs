//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2022/10/16 11:51
//  function:	Radar.cs
//  reference:	https://echarts.apache.org/en/option.html#radar
//  ————————————————————————————————————————————————————————————————————————————

using  Ban3.Infrastructures.Charts.Axes;
using  Ban3.Infrastructures.Charts.Elements;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ECharts =  Ban3.Infrastructures.Charts.Enums;

namespace  Ban3.Infrastructures.Charts.Components
{
    /// <summary>
    /// 雷达图坐标系组件，只适用于雷达图。
    /// 该组件等同 ECharts 2 中的 polar 组件。
    /// 因为 3 中的 polar 被重构为标准的极坐标组件，为避免混淆，雷达图使用 radar 组件作为其坐标系。
    /// 雷达图坐标系与极坐标系不同的是它的每一个轴（indicator 指示器）都是一个单独的维度，
    /// 可以通过 name、axisLine、axisTick、axisLabel、splitLine、 splitArea 
    /// 几个配置项配置指示器坐标轴线的样式。
    /// </summary>
    public class Radar
		: GeneralComponent
    {
		public Radar()
		{
		}

        /// <summary>
        /// 中心（圆心）坐标，数组的第一项是横坐标，第二项是纵坐标。
        /// center: [400, 300]
        /// 支持设置成百分比，设置成百分比时第一项是相对于容器宽度，第二项是相对于容器高度。
        /// center: ['50%', '50%']
        /// </summary>
        [JsonProperty("center"), JsonConverter(typeof(StringEnumConverter))]
        public object? Center { get; set; }

        /// <summary>
        /// 半径。可以为如下类型：
        /// number：直接指定外半径值。
        /// string：例如，'20%'，表示外半径为可视区尺寸（容器高宽中较小一项）的 20% 长度。
        /// Array.number|string：数组的第一项是内半径，第二项是外半径。每一项遵从上述 number string 的描述。
        /// </summary>
        [JsonProperty("radius"), JsonConverter(typeof(StringEnumConverter))]
        public object? Radius { get; set; } = "75%";

        /// <summary>
        /// 坐标系起始角度，也就是第一个指示器轴的角度。
        /// </summary>
        [JsonProperty("startAngle"), JsonConverter(typeof(StringEnumConverter))]
        public int? StartAngle { get; set; } = 90;

        /// <summary>
        /// 雷达图每个指示器名称的配置项
        /// </summary>
        [JsonProperty("axisName"), JsonConverter(typeof(StringEnumConverter))]
        public Labels.AxisName? AxisName { get; set; }

        /// <summary>
        /// 指示器名称和指示器轴的距离。
        /// </summary>
        [JsonProperty("nameGap"), JsonConverter(typeof(StringEnumConverter))]
        public int? NameGap { get; set; } = 15;

        /// <summary>
        /// 指示器轴的分割段数。
        /// </summary>
        [JsonProperty("splitNumber"), JsonConverter(typeof(StringEnumConverter))]
        public int? SplitNumber { get; set; } = 5;

        /// <summary>
        /// 雷达图绘制类型，支持 'polygon' 和 'circle'。
        /// </summary>
        [JsonProperty("shape"), JsonConverter(typeof(StringEnumConverter))]
        public ECharts.Shape? Shape { get; set; } = ECharts.Shape.Polygon;

        /// <summary>
        /// 是否是脱离 0 值比例。设置成 true 后坐标刻度不会强制包含零刻度。在双数值轴的散点图中比较有用。
        /// </summary>
        [JsonProperty("scale", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Scale { get; set; }

        /// <summary>
        /// 坐标轴是否是静态无法交互。
        /// </summary>
        [JsonProperty("silent", NullValueHandling = NullValueHandling.Ignore)]
        public bool Silent { get; set; }

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
        public bool TriggerEvent { get; set; }

        /// <summary>
        /// 坐标轴轴线相关设置
        /// </summary>
        [JsonProperty("axisLine", NullValueHandling = NullValueHandling.Ignore)]
        public Lines.AxisLine? AxisLine { get; set; }

        /// <summary>
        /// 坐标轴刻度相关设置
        /// </summary>
        [JsonProperty("axisTick", NullValueHandling = NullValueHandling.Ignore)]
        public Lines.AxisTick? AxisTick { get; set; }

        /// <summary>
        /// 坐标轴刻度标签的相关设置。
        /// </summary>
        [JsonProperty("minorTick", NullValueHandling = NullValueHandling.Ignore)]
        public Labels.AxisLabel? AxisLabel { get; set; }

        /// <summary>
        /// 坐标轴在 grid 区域中的分隔线。
        /// </summary>
        [JsonProperty("splitLine", NullValueHandling = NullValueHandling.Ignore)]
        public Lines.SplitLine? SplitLine { get; set; }

        /// <summary>
        /// 坐标轴在 grid 区域中的分隔区域，默认不显示。
        /// </summary>
        [JsonProperty("splitArea", NullValueHandling = NullValueHandling.Ignore)]
        public SplitArea? SplitArea { get; set; }

        /// <summary>
        /// 雷达图的指示器，用来指定雷达图中的多个变量（维度）
        /// indicator: [
        /// { name: '销售（sales）', max: 6500},
        /// { name: '管理（Administration）', max: 16000, color: 'red'}, // 标签设置为红色
        /// { name: '信息技术（Information Techology）', max: 30000},
        /// { name: '客服（Customer Support）', max: 38000},
        /// { name: '研发（Development）', max: 52000},
        /// { name: '市场（Marketing）', max: 25000}
        /// ]
        /// </summary>
        [JsonProperty("indicator", NullValueHandling = NullValueHandling.Ignore)]

/* Unmerged change from project 'Common (net5.0)'
Before:
        public Data.RadarIndicator[] Indicator { get; set; }
After:
        public RadarIndicator[] Indicator { get; set; }
*/
        public Cogs.RadarIndicator[] Indicator { get; set; }
    }
}

