using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.SubCondition;

/// <summary>
/// MappingFilter can be used to include or exclude specific paths.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/tfvc/changesets/get?view=azure-devops-rest-7.0#tfvcmappingfilter
/// </summary>
public class TfvcMappingFilter
{
    /// <summary>
    /// True if ServerPath should be excluded.
    /// </summary>
    [JsonProperty("exclude")]
    public bool? Exclude { get; set; }

    /// <summary>
    /// Path to be included or excluded.
    /// </summary>
    [JsonProperty("serverPath")] 
    public string? ServerPath { get; set; } 
}