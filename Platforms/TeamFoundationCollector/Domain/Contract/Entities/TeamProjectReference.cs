using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// Represents a shallow reference to a TeamProject.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/get?view=azure-devops-rest-7.0#teamprojectreference
/// </summary>
public class TeamProjectReference
{
    /// <summary>
    /// Project abbreviation.
    /// </summary>
    [JsonProperty("abbreviation")]
    public string Abbreviation { get; set; } = string.Empty;

    /// <summary>
    /// Url to default team identity image.
    /// </summary>
    [JsonProperty("defaultTeamImageUrl")]
    public string DefaultTeamImageUrl { get; set; } = string.Empty;

    /// <summary>
    /// The project's description (if any).
    /// </summary>
    [JsonProperty("description")]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Project identifier.
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Project last update time.
    /// </summary>
    [JsonProperty("lastUpdateTime")]
    public string LastUpdateTime { get; set; } = string.Empty;

    /// <summary>
    /// Project name.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Project revision.
    /// </summary>
    [JsonProperty("revision")]
    public long Revision { get; set; }

    /// <summary>
    /// Project state.
    /// </summary>
    [JsonProperty("state")]
    [JsonConverter(typeof(StringEnumConverter))]
    public ProjectState State { get; set; }

    /// <summary>
    /// Url to the full version of the object.
    /// </summary>
    [JsonProperty("url")]
    public string Url { get; set; } = string.Empty;

    /// <summary>
    /// Project visibility.
    /// </summary>
    [JsonProperty("visibility")]
    [JsonConverter(typeof(StringEnumConverter))]
    public ProjectVisibility Visibility { get; set; }
}