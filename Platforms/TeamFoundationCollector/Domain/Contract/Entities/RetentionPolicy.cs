using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// Represents a retention policy for a build definition.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/templates/get?view=azure-devops-rest-7.0#retentionpolicy
/// </summary>
public class RetentionPolicy
{
    [JsonProperty("artifactTypesToDelete")]
    public List<string>? ArtifactTypesToDelete { get; set; }

    [JsonProperty("artifacts")]
    public List<string>? Artifacts { get; set; }

    [JsonProperty("branches")]
    public List<string>? Branches { get; set; }

    /// <summary>
    /// The number of days to keep builds.
    /// </summary>
    [JsonProperty("daysToKeep")]
    public int DaysToKeep { get; set; }

    /// <summary>
    /// Indicates whether the build record itself should be deleted.
    /// </summary>
    [JsonProperty("deleteBuildRecord")]
    public bool DeleteBuildRecord { get; set; }

    /// <summary>
    /// Indicates whether to delete test results associated with the build.
    /// </summary>
    [JsonProperty("deleteTestResults")]
    public bool DeleteTestResults { get; set; }

    /// <summary>
    /// The minimum number of builds to keep.
    /// </summary>
    [JsonProperty("minimumToKeep")]
    public int MinimumToKeep { get; set; }
}