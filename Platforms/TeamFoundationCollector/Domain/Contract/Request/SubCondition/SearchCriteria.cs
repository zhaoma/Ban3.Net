using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.SubCondition;

public class SearchCriteria
{
    /// <summary>
    /// Alias or display name of user who made the changes
    /// </summary>
    [JsonProperty("author")]
    public string Author { get; set; } = string.Empty;

    /// <summary>
    /// Whether or not to follow renames for the given item being queried
    /// </summary>
    [JsonProperty("followRenames")]
    public bool FollowRenames { get; set; }

    /// <summary>
    /// If provided, only include changesets created after this date (string) Think of a better name for this.
    /// </summary>
    [JsonProperty("fromDate")]
    public string FromDate { get; set; } = string.Empty;

    /// <summary>
    /// If provided, only include changesets after this changesetID
    /// </summary>
    [JsonProperty("fromId")]
    public int FromId { get; set; }

    /// <summary>
    /// Whether to include the _links field on the shallow references
    /// </summary>
    [JsonProperty("includeLinks")]
    public bool IncludeLinks { get; set; }

    /// <summary>
    /// Path of item to search under
    /// </summary>
    [JsonProperty("itemPath")]
    public string ItemPath { get; set; } = string.Empty;

    /// <summary>
    /// If provided, only include changesets created before this date (string) Think of a better name for this.
    /// </summary>
    [JsonProperty("toDate")]
    public string ToDate { get; set; } = string.Empty;

    /// <summary>
    /// If provided, a version descriptor for the latest change list to include
    /// </summary>
    [JsonProperty("toId")]
    public int ToId { get; set; }
}