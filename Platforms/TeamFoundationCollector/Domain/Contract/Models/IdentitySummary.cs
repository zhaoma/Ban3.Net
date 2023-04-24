using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models;

public class IdentitySummary
{
    [JsonProperty("id")]
    public string Id { get; set; } = string.Empty;



    [JsonProperty("changesetIds")]
    public List<int>? ChangesetIds { get; set; }

    [JsonProperty("shelvesetIds")]
    public List<string>? ShelvesetIds { get; set; }
}