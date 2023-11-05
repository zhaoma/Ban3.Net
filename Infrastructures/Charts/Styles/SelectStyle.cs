// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

namespace Ban3.Infrastructures.Charts.Styles;

public class SelectStyle
{
    /// <summary>
    /// Width of selecting box.
    /// </summary>
    [JsonProperty("width", NullValueHandling = NullValueHandling.Ignore)]
    public object? Width { get; set; } = "auto";

    /// <summary>
    /// Border width of the select box.
    /// </summary>
    [JsonProperty("borderWidth", NullValueHandling = NullValueHandling.Ignore)]
    public object? BorderWidth { get; set; } = "auto";

    /// <summary>
    /// Border fill color of the select box.
    /// </summary>
    [JsonProperty("color", NullValueHandling = NullValueHandling.Ignore)]
    public string? Color { get; set; }

    /// <summary>
    /// Border color of the select box.
    /// </summary>
    [JsonProperty("borderColor", NullValueHandling = NullValueHandling.Ignore)]
    public string? BorderColor { get; set; }

    /// <summary>
    /// Opacity of the component. Supports value from 0 to 1, 
    /// and the component will not be drawn when set to 0.
    /// </summary>
    [JsonProperty("opacity", NullValueHandling = NullValueHandling.Ignore)]
    public decimal Opacity { get; set; }
}