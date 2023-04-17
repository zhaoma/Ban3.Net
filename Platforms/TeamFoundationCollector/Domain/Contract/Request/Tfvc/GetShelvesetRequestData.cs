using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Tfvc;

public class GetShelvesetRequestData
{
    /// <summary>
    /// Whether to include policyOverride and notes Only applies when requesting a single deep shelveset
    /// </summary>
    [JsonProperty("includeDetails")]
    public bool IncludeDetails { get; set; }

    /// <summary>
    /// Whether to include the _links field on the shallow references.
    /// Does not apply when requesting a single deep shelveset object.
    /// Links will always be included in the deep shelveset.
    /// </summary>
    [JsonProperty("includeLinks")]
    public bool IncludeLinks { get; set; }

    /// <summary>
    /// Whether to include workItems
    /// </summary>
    [JsonProperty("includeWorkItems")]
    public bool IncludeWorkItems { get; set; }

    /// <summary>
    /// Max number of changes to include
    /// </summary>
    [JsonProperty("maxChangeCount")]
    public int MaxChangeCount { get; set; }

    /// <summary>
    /// Max length of comment
    /// </summary>
    [JsonProperty("maxCommentLength")]
    public int MaxCommentLength { get; set; }

    /// <summary>
    /// Shelveset name
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// Owner's ID. Could be a name or a guid.
    /// </summary>
    [JsonProperty("owner")]
    public string Owner { get; set; }
}