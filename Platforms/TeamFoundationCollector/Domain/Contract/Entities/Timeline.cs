using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// Represents the timeline of a build.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/timeline/get?view=azure-devops-rest-7.0#timeline
/// </summary>
public class Timeline
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
    /// The process or person that last changed the timeline.
    /// </summary>
    [JsonProperty("lastChangedBy")]
    public string LastChangdBy { get; set; } = string.Empty;

    /// <summary>
    /// The time the timeline was last changed.
    /// </summary>
    [JsonProperty("lastChangedOn")]
    public string LastChangedOn { get; set; } = string.Empty;

    /// <summary>
    /// Represents an entry in a build's timeline.
    /// </summary>
    [JsonProperty("records")]
    public List<TimelineRecord>? Records { get; set; }

    /// <summary>
    /// The REST URL of the timeline.
    /// </summary>
    [JsonProperty("url")]
    public string Url { get; set; } = string.Empty;
}