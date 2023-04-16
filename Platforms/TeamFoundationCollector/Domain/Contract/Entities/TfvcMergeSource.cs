using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/tfvc/changesets/get?view=azure-devops-rest-7.0&tabs=HTTP#tfvcmergesource
/// </summary>
public class TfvcMergeSource
{

    /// <summary>
    /// Indicates if this a rename source. If false, it is a merge source.
    /// </summary>
    [JsonProperty("isRename")]
    public bool IsRename { get; set; }

    /// <summary>
    /// The server item of the merge source
    /// </summary>
    [JsonProperty("serverItem")]
    public string ServerItem { get; set; } = string.Empty;

    /// <summary>
    /// Start of the version range
    /// </summary>
    [JsonProperty("versionFrom")]
    public int VersionFrom { get; set; }

    /// <summary>
    /// End of the version range
    /// </summary>
    [JsonProperty("versionTo")]
    public int VersionTo { get; set; }
}