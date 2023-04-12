//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @        2022/10/16 11:50
//  function:	    
//  reference:
//  ————————————————————————————————————————————————————————————————————————————

using  Ban3.Infrastructures.Charts.Elements;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ECharts =  Ban3.Infrastructures.Charts.Enums;

namespace  Ban3.Infrastructures.Charts.Styles
{
    /// <summary>
    /// 文本样式
    /// </summary>
    public class TextStyle
        : IHasFont, IHasTextBorder, IHasTextShadow
    {
        #region IHasFont

        /// 
        public string? Color { get; set; }

        /// 
        public ECharts.FontStyle? FontStyle { get; set; }

        /// 
        public ECharts.FontWeight? FontWeight { get; set; }

        ///
        public string? FontFamily { get; set; } = "sans-serif";

        /// 
        public int? FontSize { get; set; } = 12;

        /// 
        public ECharts.Align? Align { get; set; }

        /// 
        public ECharts.VerticalAlign? VerticalAlign { get; set; }

        /// 
        public int? LineHeight { get; set; }

        #endregion

        /// <summary>
        /// Width of legend component. Adaptive by default.
        /// </summary>
        [JsonProperty("width", NullValueHandling = NullValueHandling.Ignore)]
        public object Width { get; set; } = "auto";

        /// <summary>
        /// Height of legend component. Adaptive by default.
        /// </summary>
        [JsonProperty("height", NullValueHandling = NullValueHandling.Ignore)]
        public object Height { get; set; } = "auto";

        #region IHasTextBorder

        /// 
        public string? TextBorderColor { get; set; }

        /// 
        public int? TextBorderWidth { get; set; }

        /// 
        public ECharts.BorderType? TextBorderType { get; set; }

        /// 
        public int? TextBorderDashOffset { get; set; }

        #endregion

        #region IHasTextShadow

        /// 
        public int? TextShadowBlur { get; set; }

        /// 
        public string? TextShadowColor { get; set; }

        /// 
        public int? TextShadowOffsetX { get; set; }

        /// 
        public int? TextShadowOffsetY { get; set; }

        #endregion

        /// <summary>
        /// 文字超出宽度是否截断或者换行。
        /// </summary>
        [JsonProperty("overflow", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public ECharts.Overflow Overflow { get; set; }

        /// <summary>
        /// Ellipsis to be displayed when overflow is set to truncate.
        /// 'truncate' Truncate the overflow lines.
        /// </summary>
        [JsonProperty("ellipsis", NullValueHandling = NullValueHandling.Ignore)]
        public string? Ellipsis { get; set; }

        /// <summary>
        /// "Rich text styles" can be defined in this rich property. 
        /// </summary>
        [JsonProperty("rich", NullValueHandling = NullValueHandling.Ignore)]
        public object? Rich { get; set; }
    }
}
