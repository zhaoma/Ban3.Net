// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
//  WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

namespace Ban3.Infrastructures.Charts.Cogs;

/// <summary>
/// 
/// </summary>
public class Transform
{
    /// 
    [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
    public string? Type { get; set; }

    /// 
    [JsonProperty("config", NullValueHandling = NullValueHandling.Ignore)]
    public object? Config { get; set; }

    /// 
    [JsonProperty("print", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Print { get; set; }
}