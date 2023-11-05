// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

namespace Ban3.Infrastructures.Charts.Cogs;

/// <summary>
/// 
/// </summary>
public class Limit
{
    [JsonProperty("min")]
    public decimal? Min { get; set; }

    [JsonProperty("max")]
    public decimal? Max { get; set; }
}