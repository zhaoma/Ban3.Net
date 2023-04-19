using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// Represents a reference to a task.
/// </summary>
public class TaskReference
{
    /// <summary>
    /// The ID of the task definition.
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// The name of the task definition.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The version of the task definition.
    /// </summary>
    [JsonProperty("version")]
    public string Version { get; set; } = string.Empty;
}