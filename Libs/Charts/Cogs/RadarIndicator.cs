//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @        2022/10/16 11:50
//  function:	    
//  reference:
//  ————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

namespace  Ban3.Infrastructures.Charts.Cogs;

public class RadarIndicator
{
    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string? Name { get; set; }

    [JsonProperty("max", NullValueHandling = NullValueHandling.Ignore)]
    public int? Max { get; set; }

    [JsonProperty("min", NullValueHandling = NullValueHandling.Ignore)]
    public int? Min { get; set; }

    [JsonProperty("color", NullValueHandling = NullValueHandling.Ignore)]
    public string? Color { get; set; }
}