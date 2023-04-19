using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// Metadata for a branchref.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/tfvc/branches/get-branch-refs?view=azure-devops-rest-7.0#tfvcbranchref
/// </summary>
public class TfvcBranchRef
{

    /// <summary>
    /// A collection of REST reference links.
    /// </summary>
    [JsonProperty("_links")]
    public ReferenceLinks? Links { get; set; }

    /// <summary>
    /// Creation date of the branch.
    /// </summary>
    [JsonProperty("createdDate")]
    public string CreatedDate { get; set; } = string.Empty;

    /// <summary>
    /// Branch description.
    /// </summary>
    [JsonProperty("description")]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Is the branch deleted?
    /// </summary>
    [JsonProperty("isDeleted")]
    public bool IsDeleted { get; set; }

    /// <summary>
    /// Alias or display name of user
    /// </summary>
    [JsonProperty("owner")]
    public IdentityRef? Owner { get; set; }

    /// <summary>
    /// Path for the branch.
    /// </summary>
    [JsonProperty("path")]
    public string Path { get; set; } = string.Empty;

    /// <summary>
    /// URL to retrieve the item.
    /// </summary>
    [JsonProperty("url")]
    public string Url { get; set; } = string.Empty;

}