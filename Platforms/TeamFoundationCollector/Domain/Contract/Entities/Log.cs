using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// Log for a pipeline.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/pipelines/logs/list?view=azure-devops-rest-7.0#log
/// </summary>
public class Log
{
    /// <summary>
    /// The date and time the log was created.
    /// </summary>
    [JsonProperty("createdOn")]
    public string CreatedOn { get; set; } = string.Empty;

    /// <summary>
    /// The ID of the log.
    /// </summary>
    [JsonProperty("id")]
    public int Id { get; set; }

    /// <summary>
    /// The date and time the log was last changed.
    /// </summary>
    [JsonProperty("lastChangedOn")]
    public string LastChangedOn { get; set; } = string.Empty;

    /// <summary>
    /// The number of lines in the log.
    /// </summary>
    [JsonProperty("lineCount")]
    public int LineCount { get; set; }

    /// <summary>
    /// A signed url allowing limited-time anonymous access to private resources.
    /// </summary>
    [JsonProperty("signedContent")]
    public SignedUrl? SignedContent { get; set; }

    [JsonProperty("url")] public string Url { get; set; } = string.Empty;
}

