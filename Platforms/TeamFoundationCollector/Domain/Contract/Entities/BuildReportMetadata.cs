using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// Represents information about a build report.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/report/get?view=azure-devops-rest-7.0#buildreportmetadata
/// </summary>
public class BuildReportMetadata
{
    /// <summary>
    /// The Id of the build.
    /// </summary>
    [JsonProperty("buildId")]
    public int BuildId { get; set; }

    /// <summary>
    /// The content of the report.
    /// </summary>
    [JsonProperty("content")]
    public string Content { get; set; } = string.Empty;

    /// <summary>
    /// The type of the report.
    /// </summary>
    [JsonProperty("type")]
    public string Type { get; set; } = string.Empty;
}