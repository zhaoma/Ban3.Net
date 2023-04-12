//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2022/10/16 12:06
//  function:	Toolbox.cs
//  reference:	https://echarts.apache.org/en/option.html#toolbox
//  ————————————————————————————————————————————————————————————————————————————

using  Ban3.Infrastructures.Charts.Elements;
using  Ban3.Infrastructures.Charts.Styles;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using ECharts =  Ban3.Infrastructures.Charts.Enums;

namespace  Ban3.Infrastructures.Charts.Cogs
{
    public class Toolbox
        :IHasIdentity,IHasPosition
    {
        public Toolbox()
        {
        }

        #region IHasIdentity

        /// 
        public string? Id { get; set; }

        /// 
        public bool? Show { get; set; }

        /// 
        public int? ZLevel { get; set; }

        /// 
        public int? Z { get; set; }

        #endregion

        #region IHasPosition

        /// 
        public object? Left { get; set; } = "auto";

        /// 
        public object? Top { get; set; } = "auto";

        /// 
        public object? Right { get; set; } = "auto";

        /// 
        public object? Bottom { get; set; } = "auto";

        ///
        public object? Width { get; set; } = "auto";

        /// 
        public object? Height { get; set; } = "auto";

        #endregion

        /// <summary>
        /// 布局方式是横还是竖。
        /// 不仅是布局方式，对于直角坐标系而言，也决定了，缺省情况控制横向数轴还是纵向数轴。
        /// </summary>
        [JsonProperty("orient", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public ECharts.Orient? Orient { get; set; }

        /// <summary>
        /// 工具栏 icon 的大小
        /// </summary>
        [JsonProperty("itemSize", NullValueHandling = NullValueHandling.Ignore)]
        public int? ItemSize { get; set; } = 15;

        /// <summary>
        /// The distance between each legend, 
        /// horizontal distance in horizontal layout, 
        /// and vertical distance in vertical layout.
        /// </summary>
        [JsonProperty("itemGap", NullValueHandling = NullValueHandling.Ignore)]
        public int ItemGap { get; set; } = 8;

        /// <summary>
        /// 是否在鼠标 hover 的时候显示每个工具 icon 的标题
        /// </summary>
        [JsonProperty("showTitle", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ShowTitle { get; set; } = true;

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("iconStyle", NullValueHandling = NullValueHandling.Ignore)]
        public GeneralStyle IconStyle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("emphasis", NullValueHandling = NullValueHandling.Ignore)]
        public IconEmphasis Emphasis { get; set; }

        /// <summary>
        /// 工具箱的 tooltip 配置，配置项同 tooltip。
        /// 默认不显示，可以在需要特殊定制文字样式（尤其是想用自定义 CSS 控制文字样式）的时候开启 tooltip
        /// </summary>
        [JsonProperty("tooltip", NullValueHandling = NullValueHandling.Ignore)]
        public Tooltip? Tooltip { get; set; }
    }
}

