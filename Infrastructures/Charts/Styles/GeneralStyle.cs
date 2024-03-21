// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
//  WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Charts.Elements;
using Newtonsoft.Json;
using ECharts = Ban3.Infrastructures.Charts.Enums;

namespace Ban3.Infrastructures.Charts.Styles
{
    /// <summary>
    /// 样式普通设置
    /// </summary>
    public class GeneralStyle
        : IHasBorder, IHasShadow
    {
        /// <summary>
        /// main title text color.
        /// </summary>
        [JsonProperty("color", NullValueHandling = NullValueHandling.Ignore)]
        public string? Color { get; set; }

        #region IHasBorder

        /// 
        public string? BackgroundColor { get; set; } 

        /// 
        public string? BorderColor { get; set; } 

        /// 
        public ECharts.BorderType? BorderType { get; set; }

        /// 
        public int? BorderWidth { get; set; } 

        /// 
        public object? BorderRadius { get; set; }

        ///
        public int? BorderDashOffset { get; set; }

        ///
        public ECharts.BorderCap? BorderCap { get; set; }

        ///
        public ECharts.BorderJoin? BorderJoin { get; set; }

        ///
        public int? BorderMiterLimit { get; set; }

        ///
        public object? Padding { get; set; } 

        #endregion

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

        /// <summary>
        /// The style of the decal pattern. 
        /// It works only if aria.enabled and aria.decal.show are both set to be true.
        /// If it is set to be 'none', no decal will be used.
        /// </summary>
        [JsonProperty("decal", NullValueHandling = NullValueHandling.Ignore)]
        public object? Decal { get; set; }
    }
}
