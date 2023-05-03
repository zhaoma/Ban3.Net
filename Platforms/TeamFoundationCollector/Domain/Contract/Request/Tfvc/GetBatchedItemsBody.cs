using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Tfvc;

public class GetBatchedItemsBody
{
    /// <summary>
    /// If true, include metadata about the file type
    /// </summary>
    [JsonProperty("includeContentMetadata")]
    public bool? IncludeContentMetadata { get; set; }

    /// <summary>
    /// Whether to include the _links field on the shallow references
    /// </summary>
    [JsonProperty("includeLinks")]
    public bool? IncludeLinks { get; set; }

    /// <summary>
    /// Item path and Version descriptor properties
    /// </summary>
    [JsonProperty("itemDescriptors")]
    public List<TfvcItemDescriptor>? ItemDescriptors { get; set; }
}