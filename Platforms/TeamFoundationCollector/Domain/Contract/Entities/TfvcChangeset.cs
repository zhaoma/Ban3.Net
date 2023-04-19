using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// A collection of changes.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/tfvc/changesets/get?view=azure-devops-rest-7.0#tfvcchangeset
/// </summary>
public class TfvcChangeset
    : TfvcChangesetRef
{
    /// <summary>
    /// Account Id of the changeset.
    /// </summary>
    [JsonProperty("accountId")]
    public string AccountId { get; set; } = string.Empty;

    /// <summary>
    /// List of associated changes.
    /// </summary>
    [JsonProperty("changes")]
    public List<TfvcChange>? Changes { get; set; }

    /// <summary>
    /// Checkin Notes for the changeset.
    /// </summary>
    [JsonProperty("checkinNotes")]
    public List<CheckinNote>? CheckinNotes { get; set; }

    /// <summary>
    /// Collection Id of the changeset.
    /// </summary>
    [JsonProperty("collectionId")]
    public string CollectionId { get; set; } = string.Empty;

    /// <summary>
    /// Are more changes available.
    /// </summary>
    [JsonProperty("hasMoreChanges")]
    public bool HasMoreChanges { get; set; }

    /// <summary>
    /// Policy Override for the changeset.
    /// </summary>
    [JsonProperty("policyOverride")]
    public TfvcPolicyOverrideInfo? PolicyOverride { get; set; }

    /// <summary>
    /// Team Project Ids for the changeset.
    /// </summary>
    [JsonProperty("teamProjectIds")]
    public List<string>? TeamProjectIds { get; set; }

    /// <summary>
    /// List of work items associated with the changeset.
    /// </summary>
    [JsonProperty("workItems")]
    public List<AssociatedWorkItem>? WorkItems { get; set; }

}