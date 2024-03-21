// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
//  WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

namespace Ban3.Infrastructures.Charts.Cogs;

/// <summary>
/// 
/// </summary>
public class RadarIndicator
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string? Name { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("max", NullValueHandling = NullValueHandling.Ignore)]
    public int? Max { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("min", NullValueHandling = NullValueHandling.Ignore)]
    public int? Min { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("color", NullValueHandling = NullValueHandling.Ignore)]
    public string? Color { get; set; }
}