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
    /// 线条样式
    /// </summary>
    public class LineStyle
        : IHasShadow
    {
        /// <summary>
        /// main title text color.
        /// </summary>
        [JsonProperty("color", NullValueHandling = NullValueHandling.Ignore)]
        public string? Color { get; set; }

        /// <summary>
        /// Stroke line width of the text.
        /// </summary>
        [JsonProperty("width", NullValueHandling = NullValueHandling.Ignore)]
        public int? Width { get; set; } = 1;

        /// <summary>
        /// border type.
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(StringEnumConverter))]
        public ECharts.BorderType? Type { get; set; }

        /// <summary>
        /// To set the line dash offset. With borderType , 
        /// we can make the line style more flexible.
        /// </summary>
        [JsonProperty("dashOffset", NullValueHandling = NullValueHandling.Ignore)]
        public int? DashOffset { get; set; }

        /// <summary>
        /// To specify how to draw the end points of the line.
        /// </summary>
        [JsonProperty("cap", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(StringEnumConverter))]
        public ECharts.BorderCap? Cap { get; set; }

        /// <summary>
        /// To determine the shape used to join two line segments where they meet.
        /// </summary>
        [JsonProperty("join", NullValueHandling = NullValueHandling.Ignore), JsonConverter(typeof(StringEnumConverter))]
        public ECharts.BorderJoin? Join { get; set; }

        /// <summary>
        /// To set the miter limit ratio. Only works when borderJoin is set as miter.
        /// Default value is 10. Negative、0、Infinity and NaN values are ignored.
        /// </summary>
        [JsonProperty("miterLimit", NullValueHandling = NullValueHandling.Ignore)]
        public int? MiterLimit { get; set; }

        #region IHasShadow

        /// 
        public int? ShadowBlur { get; set; }

        /// 
        public string? ShadowColor { get; set; }

        /// 
        public int? ShadowOffsetX { get; set; }

        /// 
        public int? ShadowOffsetY { get; set; }

        ///
        public decimal? Opacity { get; set; }

        #endregion

    }
}
