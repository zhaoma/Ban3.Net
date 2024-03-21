// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
//  WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.Charts.Entries;

/// <summary>
/// Treemap data define
/// </summary>
public class TreemapRecord
{
    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string? Name { get; set; }
    
    [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
    public int? Value { get; set; }
    
    [JsonProperty("children", NullValueHandling = NullValueHandling.Ignore)]
    public List<TreemapRecord>? Children { get; set; }
}