using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// Represents a reference to a build log.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/get?view=azure-devops-rest-7.0#buildlogreference
/// </summary>
public class BuildLogReference
{
    /// <summary>
    /// The ID of the log.
    /// </summary>
    [JsonProperty("id")]
    public int Id { get; set; }

    /// <summary>
    /// The type of the log location.
    /// </summary>
    [JsonProperty("type")]
    public int Type { get; set; }

    /// <summary>
    /// A full link to the log resource.
    /// </summary>
    [JsonProperty("url")]
    public string Url { get; set; }
}