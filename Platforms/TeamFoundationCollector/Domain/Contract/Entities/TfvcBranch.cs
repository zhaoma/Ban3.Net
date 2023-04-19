using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// Class representing a branch object.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/tfvc/branches/get?view=azure-devops-rest-7.0#tfvcbranch
/// </summary>
public class TfvcBranch
    : TfvcBranchRef
{
    /// <summary>
    /// List of children for the branch.
    /// </summary>
    [JsonProperty("children")]
    public List<TfvcBranch>? Children { get; set; }

    /// <summary>
    /// List of branch mappings.
    /// </summary>
    [JsonProperty("mappings")]
    public List<TfvcBranchMapping>? Mappings { get; set; }

    /// <summary>
    /// Path of the branch's parent.
    /// </summary>
    [JsonProperty("parent")]
    public TfvcShallowBranchRef? Parent { get; set; }

    /// <summary>
    /// List of paths of the related branches.
    /// </summary>
    [JsonProperty("relatedBranches")]
    public List<TfvcShallowBranchRef>? RelatedBranches { get; set; }

}