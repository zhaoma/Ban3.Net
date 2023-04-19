using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/tfvc/changesets/get?view=azure-devops-rest-7.0#tfvcchange
/// </summary>
public class TfvcChange
{

    /// <summary>
    /// The type of change that was made to the item.
    /// Enums/VersionControlChangeType
    /// </summary>
    [JsonProperty("changeType")]
    public VersionControlChangeType ChangeType { get; set; }

    /// <summary>
    /// Current version.
    /// </summary>
    [JsonProperty("item")]
    public string Item { get; set; } = string.Empty;

    /// <summary>
    /// List of merge sources in case of rename or branch creation.
    /// </summary>
    [JsonProperty("mergeSources")]
    public List<TfvcMergeSource>? MergeSources { get; set; }

    /// <summary>
    /// Content of the item after the change.
    /// </summary>
    [JsonProperty("newContent")]
    public ItemContent? NewContent { get; set; }

    /// <summary>
    /// Version at which a (shelved) change was pended against
    /// </summary>
    [JsonProperty("pendingVersion")]
    public int PendingVersion { get; set; }

    /// <summary>
    /// Path of the item on the server.
    /// </summary>
    [JsonProperty("sourceServerItem")]
    public string SourceServerItem { get; set; } = string.Empty;

    /// <summary>
    /// URL to retrieve the item.
    /// </summary>
    [JsonProperty("url")]
    public string Url { get; set; } = string.Empty;
}