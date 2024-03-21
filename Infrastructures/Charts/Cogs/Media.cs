// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
//  WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

namespace Ban3.Infrastructures.Charts.Cogs;

/// <summary>
/// 
/// </summary>
public class Media
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("query")]
    public MediaQuery? Query { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("option")]
    public object? Option { get; set; }
}