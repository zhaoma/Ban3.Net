using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// Represents a build log.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/get-build-logs?view=azure-devops-rest-7.0#buildlog
/// </summary>
public class BuildLog
    : BuildLogReference
{
    /// <summary>
    /// The date and time the log was created.
    /// </summary>
    [JsonProperty("createdOn")]
    public string CreatedOn { get; set; }

    /// <summary>
    /// The date and time the log was last changed.
    /// </summary>
    [JsonProperty("lastChangedOn")]
    public string LastChangedOn { get; set; }

    /// <summary>
    /// The number of lines in the log.
    /// </summary>
    [JsonProperty("lineCount")]
    public int LineCount { get; set; }

}