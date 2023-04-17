using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Tfvc;

public class GetLabelRequestData
{
    [JsonProperty("includeLinks")]
    public bool IncludeLinks { get; set; }

    [JsonProperty("itemLabelFilter")]
    public string ItemLabelFilter { get; set; }

    [JsonProperty("labelScope")]
    public string LabelScope { get; set; }

    [JsonProperty("maxItemCount")]
    public int MaxItemCount { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("owner")]
    public string Owner { get; set; }
}