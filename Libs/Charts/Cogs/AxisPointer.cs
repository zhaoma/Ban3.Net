//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma      2022/10/16 12:06
//  function:	坐标轴指示器
//  reference:	https://echarts.apache.org/en/option.html#axisPointer
//  ————————————————————————————————————————————————————————————————————————————

using  Ban3.Infrastructures.Charts.Styles;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ECharts =  Ban3.Infrastructures.Charts.Enums;

namespace  Ban3.Infrastructures.Charts.Cogs
{
    /// <summary>
    /// This is the global configurations of axisPointer.
    /// axisPointer is a tool for displaying reference line and axis value under mouse pointer.
    /// </summary>
    public class AxisPointer
    {
        public AxisPointer()
        {
        }

        /// <summary>
        /// Set this to false to prevent the title from showing
        /// </summary>
        [JsonProperty("show", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Show { get; set; }

        /// <summary>
        /// 指示器类型
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public ECharts.AxisPointerType? Type { get; set; }

        /// <summary>
        /// 坐标轴指示器是否自动吸附到点上。默认自动判断。
        /// 这个功能在数值轴和时间轴上比较有意义，可以自动寻找细小的数值点。
        /// </summary>
        [JsonProperty("snap", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Snap { get; set; }

        /// <summary>
        /// 坐标轴指示器的 z 值。控制图形的前后顺序。
        /// zlevel value of all graphical elements in .
        /// zlevel is used to make layers with Canvas. 
        /// Graphical elements with different zlevel values will be placed in different Canvases, 
        /// which is a common optimization technique. 
        /// We can put those frequently changed elements (like those with animations) to a separate zlevel.
        /// Notice that too many Canvases will increase memory cost, and should be used carefully on mobile phones to avoid crash.
        /// Canvases with bigger zlevel will be placed on Canvases with smaller zlevel.
        /// </summary>
        [JsonProperty("z", NullValueHandling = NullValueHandling.Ignore)]
        public int? Z { get; set; }

        /// <summary>
        /// 坐标轴指示器的文本标签
        /// </summary>
        [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
        public Labels.Label? Label { get; set; }

        /// <summary>
        /// axisPointer.type 为 'line' 时有效。
        /// </summary>
        [JsonProperty("lineStyle", NullValueHandling = NullValueHandling.Ignore)]
        public LineStyle? LineStyle { get; set; }

        /// <summary>
        /// axisPointer.type 为 'shadow' 时有效。
        /// </summary>
        [JsonProperty("shadowStyle", NullValueHandling = NullValueHandling.Ignore)]
        public ShadowStyle? ShadowStyle { get; set; }

        /// <summary>
        /// 是否触发 tooltip。如果不想触发 tooltip 可以关掉。
        /// </summary>
        [JsonProperty("triggerTooltip", NullValueHandling = NullValueHandling.Ignore)]
        public bool? TriggerTooltip { get; set; }

        /// <summary>
        /// 当前的 value。
        /// 在使用 axisPointer.handle 时，可以设置此值进行初始值设定，从而决定 axisPointer 的初始位置。
        /// </summary>
        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public int? Value { get; set; }

        /// <summary>
        /// 当前的状态，可取值为 'show' 和 'hide'。
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string? Status { get; set; }

        /// <summary>
        /// 拖拽手柄，适用于触屏的环境。
        /// </summary>
        [JsonProperty("handle", NullValueHandling = NullValueHandling.Ignore)]
        public Handle? Handle { get; set; }


    }
}