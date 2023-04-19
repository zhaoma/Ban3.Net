using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// Represents a reference to a timeline.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/timeline/get?view=azure-devops-rest-7.0#timelinereference
/// </summary>
public class TimelineReference
{

    /// <summary>
    /// The change ID.
    /// </summary>
    [JsonProperty("changeId")]
    public int ChangeId { get; set; }

    /// <summary>
    /// The ID of the timeline.
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// The REST URL of the timeline.
    /// </summary>
    [JsonProperty("url")]
    public string Url { get; set; } = string.Empty;
}