using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Tfvc;

public class GetLabelRequestData
{
    [JsonProperty("includeLinks")] public bool IncludeLinks { get; set; }

    [JsonProperty("itemLabelFilter")] public string ItemLabelFilter { get; set; } = string.Empty;

    [JsonProperty("labelScope")] public string LabelScope { get; set; } = string.Empty;

    [JsonProperty("maxItemCount")] public int MaxItemCount { get; set; }

    [JsonProperty("name")] public string Name { get; set; } = string.Empty;

    [JsonProperty("owner")] public string Owner { get; set; } = string.Empty;
}