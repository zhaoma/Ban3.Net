//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @        2022/10/16 11:50
//  function:	    
//  reference:
//  ————————————————————————————————————————————————————————————————————————————

using  Ban3.Infrastructures.Charts.Elements;
using Newtonsoft.Json;

namespace  Ban3.Infrastructures.Charts.Styles
{
    /// <summary>
    /// 分隔区域的样式设置
    /// </summary>
    public class AreaStyle
        : IHasShadow
    {
        /// <summary>
        /// text color. If set as 'inherit', the color will assigned as visual color, such as series color.
        /// </summary>
        [JsonProperty("color", NullValueHandling = NullValueHandling.Ignore)]
        public string? Color { get; set; }

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
