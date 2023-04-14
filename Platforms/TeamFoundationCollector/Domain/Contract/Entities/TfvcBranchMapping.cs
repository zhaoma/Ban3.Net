using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// A branch mapping.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/tfvc/branches/get?view=azure-devops-server-rest-6.0&tabs=HTTP#tfvcbranchmapping
/// </summary>
public class TfvcBranchMapping
{
    /// <summary>
    /// Depth of the branch.
    /// </summary>
    [JsonProperty("depth")]
    public string Depth { get; set; }

    /// <summary>
    /// Server item for the branch.
    /// </summary>
    [JsonProperty("serverItem")]
    public string ServerItem { get; set; }

    /// <summary>
    /// Type of the branch.
    /// </summary>
    [JsonProperty("type")]
    public string Type { get; set; }
}