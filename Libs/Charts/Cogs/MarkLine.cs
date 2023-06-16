using Newtonsoft.Json;

namespace Ban3.Infrastructures.Charts.Cogs;

public class MarkLine
{
    [JsonProperty("yAxis", NullValueHandling = NullValueHandling.Ignore)]
    public object? YAxis { get; set; }
}