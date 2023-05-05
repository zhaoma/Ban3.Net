using System.Collections.Generic;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// Represents an entry in a build's timeline.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/timeline/get?view=azure-devops-rest-7.0#timelinerecord
/// </summary>
public class TimelineRecord
{

    [JsonProperty("_links")]
    public ReferenceLinks? Links { get; set; }

    /// <summary>
    /// Gets or sets the attempt of the record.
    /// </summary>
    [JsonProperty("attempt")]
    public int Attempt { get; set; }

    /// <summary>
    /// The change ID.
    /// </summary>
    [JsonProperty("changeId")]
    public int ChangeId { get; set; }

    /// <summary>
    /// A string that indicates the current operation.
    /// </summary>
    [JsonProperty("currentOperation")]
    public string CurrentOperation { get; set; } = string.Empty;

    /// <summary>
    /// A reference to a sub-timeline.
    /// </summary>
    [JsonProperty("details")]
    public TimelineReference? Details { get; set; }

    /// <summary>
    /// The number of errors produced by this operation.
    /// </summary>
    [JsonProperty("errorCount")]
    public int ErrorCount { get; set; }

    /// <summary>
    /// The finish time.
    /// </summary>
    [JsonProperty("finishTime")]
    public string FinishTime { get; set; } = string.Empty;

    /// <summary>
    /// The ID of the record.
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// String identifier that is consistent across attempts.
    /// </summary>
    [JsonProperty("identifier")]
    public string Identifier { get; set; } = string.Empty;

    /// <summary>
    /// Represents an issue (error, warning) associated with a build.
    /// </summary>
    [JsonProperty("issues")]
    public List<Issue>? Issues { get; set; }

    /// <summary>
    /// The time the record was last modified.
    /// </summary>
    [JsonProperty("lastModified")]
    public string LastModified { get; set; } = string.Empty;

    /// <summary>
    /// A reference to the log produced by this operation.
    /// </summary>
    [JsonProperty("log")]
    public BuildLogReference? Log { get; set; }

    /// <summary>
    /// The name.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// An ordinal value relative to other records.
    /// </summary>
    [JsonProperty("order")]
    public int Order { get; set; }

    /// <summary>
    /// The ID of the record's parent.
    /// </summary>
    [JsonProperty("parentId")]
    public string ParentId { get; set; } = string.Empty;

    /// <summary>
    /// The current completion percentage.
    /// </summary>
    [JsonProperty("percentComplete")]
    public int PercentComplete { get; set; }

    [JsonProperty("previousAttempts")]
    public List<TimelineAttempt>? PreviousAttempts { get; set; }

    /// <summary>
    /// The queue ID of the queue that the operation ran on.
    /// </summary>
    [JsonProperty("queueId")]
    public int QueueId { get; set; }

    /// <summary>
    /// The result.
    /// </summary>
    [JsonProperty("result")]
    public TaskResult Result { get; set; }

    /// <summary>
    /// The result code.
    /// </summary>
    [JsonProperty("resultCode")]
    public string ResultCode { get; set; } = string.Empty;

    /// <summary>
    /// The start time.
    /// </summary>
    [JsonProperty("startTime")]
    public string StartTime { get; set; } = string.Empty;

    /// <summary>
    /// The state of the record.
    /// </summary>
    [JsonProperty("state")]
    public TimelineRecordState State { get; set; }

    /// <summary>
    /// A reference to the task represented by this timeline record.
    /// </summary>
    [JsonProperty("task")]
    public  TaskReference? Task { get; set; }

    /// <summary>
    /// The type of the record.
    /// </summary>
    [JsonProperty("type")]
    public string Type { get; set; } = string.Empty;

    /// <summary>
    /// The REST URL of the timeline record.
    /// </summary>
    [JsonProperty("url")]
    public string Url { get; set; } = string.Empty;

    /// <summary>
    /// The number of warnings produced by this operation.
    /// </summary>
    [JsonProperty("warningCount")]
    public int WarningCount { get; set; }

    /// <summary>
    /// The name of the agent running the operation.
    /// </summary>
    [JsonProperty("workerName")] 
    public string WorkerName { get; set; } = string.Empty;

}