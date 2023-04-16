using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// Represents a change associated with a build.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/get-build-changes?view=azure-devops-rest-7.0#change
/// </summary>
public class Change
{
    /// <summary>
    /// The author of the change.
    /// </summary>
    [JsonProperty("author")]
    public IdentityRef? Author { get; set; }

    /// <summary>
    /// The location of a user-friendly representation of the resource.
    /// </summary>
    [JsonProperty("displayUri")]
    public string DisplayUri { get; set; } = string.Empty;

    /// <summary>
    /// The identifier for the change. For a commit, this would be the SHA1.
    /// For a TFVC changeset, this would be the changeset ID.
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// The location of the full representation of the resource.
    /// </summary>
    [JsonProperty("location")]
    public string Location { get; set; } = string.Empty;

    /// <summary>
    /// The description of the change.
    /// This might be a commit message or changeset description.
    /// </summary>
    [JsonProperty("message")]
    public string Message { get; set; } = string.Empty;

    /// <summary>
    /// Indicates whether the message was truncated.
    /// </summary>
    [JsonProperty("messageTruncated")]
    public bool MessageTruncated { get; set; }

    /// <summary>
    /// The person or process that pushed the change.
    /// </summary>
    [JsonProperty("pusher")]
    public string Pusher { get; set; } = string.Empty;

    /// <summary>
    /// The timestamp for the change.
    /// </summary>
    [JsonProperty("timestamp")]
    public string Timestamp { get; set; } = string.Empty;

    /// <summary>
    /// The type of change. "commit", "changeset", etc.
    /// </summary>
    [JsonProperty("type")]
    public string Type { get; set; } = string.Empty;

}