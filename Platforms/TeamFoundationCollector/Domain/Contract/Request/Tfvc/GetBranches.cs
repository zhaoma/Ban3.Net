using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Tfvc;

/// <summary>
/// Get a collection of branch roots -- first-level children, branches with no parents.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/tfvc/branches/get-branches?view=azure-devops-rest-7.0
/// </summary>
public class GetBranches
    : PresetRequest, IRequest
{
    /// <summary>
    /// Return child branches, if there are any.
    /// Default: False
    /// </summary>
    [JsonProperty("includeChildren")]
    public bool IncludeChildren { get; set; } = false;

    /// <summary>
    /// Return the parent branch, if there is one.
    /// Default: False
    /// </summary>
    [JsonProperty("includeParent")]
    public bool IncludeParent { get; set; } = false;

    /// <summary>
    /// Return deleted branches.
    /// Default: False
    /// </summary>
    [JsonProperty("includeDeleted")]
    public bool IncludeDeleted { get; set; } = false;

    /// <summary>
    /// Return links.
    /// Default: False
    /// </summary>
    [JsonProperty("includeLinks")]
    public bool IncludeLinks { get; set; } = false;
    
    public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/tfvc/branches";
}