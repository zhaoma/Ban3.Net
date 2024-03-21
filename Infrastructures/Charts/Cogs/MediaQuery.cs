// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
//  WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

namespace Ban3.Infrastructures.Charts.Cogs;

/// <summary>
/// 
/// </summary>
public class MediaQuery
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("minWidth")]
    public int? MinWidth { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("maxHeight")]
    public int? MaxHeight { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("minAspectRatio")]
    public decimal? MinAspectRatio { get; set; }
}