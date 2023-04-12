//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @        2022/10/16 11:50
//  function:	    
//  reference:
//  ————————————————————————————————————————————————————————————————————————————

using  Ban3.Infrastructures.Charts.Styles;
using  Ban3.Infrastructures.Charts.Labels;
using  Ban3.Infrastructures.Charts.Lines;
using Newtonsoft.Json;
using ECharts =  Ban3.Infrastructures.Charts.Enums;

namespace  Ban3.Infrastructures.Charts.Cogs
{
    /// <summary>
    /// 强调
    /// </summary>
    public class Emphasis
    {
        /// <summary>
        /// 是否关闭高亮状态。
        /// 关闭高亮状态可以在鼠标移到图形上，tooltip 触发，或者图例联动的时候不再触发高亮效果。
        /// 在图形非常多的时候可以关闭以提升交互流畅性。
        /// </summary>
        [JsonProperty("disabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Disabled { get; set; }

        /// <summary>
        /// 是否开启 hover 在拐点标志上的放大效果。
        /// 从 5.3.2 版本开始支持 number，用以设置高亮放大倍数，默认放大 1.1 倍。
        /// </summary>
        [JsonProperty("scale", NullValueHandling = NullValueHandling.Ignore)]
        public object? Scale { get; set; }

        /// <summary>
        /// 在高亮图形时，是否淡出其它数据的图形已达到聚焦的效果
        /// </summary>
        [JsonProperty("focus", NullValueHandling = NullValueHandling.Ignore)]
        public ECharts.Focus? Focus { get; set; }

        /// <summary>
        /// 在开启focus的时候，可以通过blurScope配置淡出的范围。
        /// </summary>
        [JsonProperty("blurScope", NullValueHandling = NullValueHandling.Ignore)]
        public ECharts.BlurScope? BlurScope { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
        public Label? Label { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("labelLine", NullValueHandling = NullValueHandling.Ignore)]
        public LabelLine? LabelLine { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("selectorLabel", NullValueHandling = NullValueHandling.Ignore)]
        public Label? SelectorLabel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("itemStyle", NullValueHandling = NullValueHandling.Ignore)]
        public GeneralStyle? ItemStyle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("lineStyle", NullValueHandling = NullValueHandling.Ignore)]
        public LineStyle? LineStyle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("areaStyle", NullValueHandling = NullValueHandling.Ignore)]
        public AreaStyle? AreaStyle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("endLabel", NullValueHandling = NullValueHandling.Ignore)]
        public Label? EndLabel { get; set; }

        /// <summary>
        /// Style of the selected item (checkpoint).
        /// </summary>
        [JsonProperty("checkpointStyle", NullValueHandling = NullValueHandling.Ignore)]
        public CheckpointStyle? CheckpointStyle { get; set; }

        /// <summary>
        /// The style of control button, which includes: play button, previous button, and next button.
        /// </summary>
        [JsonProperty("controlStyle", NullValueHandling = NullValueHandling.Ignore)]
        public ControlStyle? ControlStyle { get; set; }

    }
}
