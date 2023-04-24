using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

public class TfvcChangeItem
{
    [JsonProperty("version")]
    public int Version { get; set; }

    [JsonProperty("size")]
    public int Size { get; set; }

    [JsonProperty("hashValue")]
    public string HashValue { get; set; } = string.Empty;

    [JsonProperty("path")]
    public string Path { get; set; } = string.Empty;

    /// <summary>
    /// URL to retrieve the item.
    /// </summary>
    [JsonProperty("url")]
    public string Url { get; set; } = string.Empty;
}