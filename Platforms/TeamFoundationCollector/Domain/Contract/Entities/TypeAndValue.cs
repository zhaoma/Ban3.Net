using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

public class TypeAndValue
{
    [JsonProperty("$type")]
    public object? Type { get; set; }

    [JsonProperty("$value")]
    public object? Value { get; set; }
}