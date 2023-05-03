using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Tfvc;

/// <summary>
/// Get a single branch hierarchy at the given path with parents or children as specified.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/tfvc/branches/get?view=azure-devops-rest-7.0
/// </summary>
public class GetBranch
    : PresetRequest,IRequest
{
    /// <summary>
    /// Full path to the branch.
    /// Default: $/
    /// Examples: $/, $/MyProject, $/MyProject/SomeFolder.
    /// </summary>
    public string Path { get; set; } = "$/";

    /// <summary>
    /// Return child branches, if there are any.
    /// Default: False
    /// </summary>
    [JsonProperty("includeChildren")]
    public bool IncludeChildren { get; set; } = true;

    /// <summary>
    /// Return the parent branch, if there is one.
    /// Default: False
    /// </summary>
    [JsonProperty("includeParent")]
    public bool IncludeParent { get; set; } = true;
    
    public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/tfvc/branches";

}
