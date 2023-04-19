using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/timeline/get?view=azure-devops-rest-7.0#timelineattempt
/// </summary>
public class TimelineAttempt
{
    /// <summary>
    /// Gets or sets the attempt of the record.
    /// </summary>
    [JsonProperty("attempt")]
    public int Attempt { get; set; }

    /// <summary>
    /// Gets or sets the record identifier located within the specified timeline.
    /// </summary>
    [JsonProperty("recordId")]
    public string RecordId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the timeline identifier which owns the record representing this attempt.
    /// </summary>
    [JsonProperty("timelineId")]
    public string TimelineId { get; set; } = string.Empty;
}