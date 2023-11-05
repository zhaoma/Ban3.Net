// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

namespace Ban3.Infrastructures.Charts.Entries;

public class SankeyLink
{

    [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
    public object? Source { get; set; }


    [JsonProperty("target", NullValueHandling = NullValueHandling.Ignore)]
    public string? Target { get; set; }


    [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
    public int? Value { get; set; }
}
