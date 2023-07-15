//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @        2022/10/16 11:50
//  function:	    
//  reference:
//  ————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

namespace  Ban3.Infrastructures.Charts.Elements;

/// <summary>
/// 有阴影
/// </summary>
public interface IHasShadow
{
    /// <summary>
    /// Shadow blur of the text itself.
    /// </summary>
    [JsonProperty("shadowBlur", NullValueHandling = NullValueHandling.Ignore)]
    int? ShadowBlur { get; set; }

    /// <summary>
    /// Shadow color of the text itself.
    /// </summary>
    [JsonProperty("shadowColor", NullValueHandling = NullValueHandling.Ignore)]
    string? ShadowColor { get; set; }

    /// <summary>
    /// Shadow X offset of the text itself.
    /// </summary>
    [JsonProperty("shadowOffsetX", NullValueHandling = NullValueHandling.Ignore)]
    int? ShadowOffsetX { get; set; }

    /// <summary>
    /// Shadow Y offset of the text itself.
    /// </summary>
    [JsonProperty("shadowOffsetY", NullValueHandling = NullValueHandling.Ignore)]
    int? ShadowOffsetY { get; set; }

    /// <summary>
    /// Opacity of the component. Supports value from 0 to 1, 
    /// and the component will not be drawn when set to 0.
    /// </summary>
    [JsonProperty("opacity", NullValueHandling = NullValueHandling.Ignore)]
    decimal? Opacity { get; set; }
}