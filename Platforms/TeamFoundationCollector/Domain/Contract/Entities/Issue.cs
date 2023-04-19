using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// Represents an issue (error, warning) associated with a build.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/timeline/get?view=azure-devops-rest-7.0#issue
/// </summary>
public class Issue
{
    /// <summary>
    /// The category.
    /// </summary>
    [JsonProperty("category")]
    public string Category { get; set; } = string.Empty;

    [JsonProperty("data")]
    public object? Data { get; set; }

    /// <summary>
    /// A description of the issue.
    /// </summary>
    [JsonProperty("message")]
    public string Message { get; set; } = string.Empty;

    /// <summary>
    /// The type (error, warning) of the issue.
    /// </summary>
    [JsonProperty("type")]
    public IssueType Type { get; set; }
}