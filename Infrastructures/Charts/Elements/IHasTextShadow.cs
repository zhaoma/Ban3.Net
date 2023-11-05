// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

namespace Ban3.Infrastructures.Charts.Elements;

/// <summary>
/// 文字阴影
/// </summary>
public interface IHasTextShadow
{
    /// <summary>
    /// Shadow blur of the text itself.
    /// </summary>
    [JsonProperty("textShadowBlur", NullValueHandling = NullValueHandling.Ignore)]
    int? TextShadowBlur { get; set; }

    /// <summary>
    /// Shadow color of the text itself.
    /// </summary>
    [JsonProperty("textShadowColor", NullValueHandling = NullValueHandling.Ignore)]
    string? TextShadowColor { get; set; }

    /// <summary>
    /// Shadow X offset of the text itself.
    /// </summary>
    [JsonProperty("textShadowOffsetX", NullValueHandling = NullValueHandling.Ignore)]
    int? TextShadowOffsetX { get; set; }

    /// <summary>
    /// Shadow Y offset of the text itself.
    /// </summary>
    [JsonProperty("textShadowOffsetY", NullValueHandling = NullValueHandling.Ignore)]
    int? TextShadowOffsetY { get; set; }
}