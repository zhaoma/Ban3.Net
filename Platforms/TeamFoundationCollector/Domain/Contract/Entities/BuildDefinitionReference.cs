using System.Collections.Generic;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// Represents a reference to a build definition.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/definitions/list?view=azure-devops-rest-7.0#builddefinitionreference
/// </summary>
public class BuildDefinitionReference
{
    /// <summary>
    /// The class to represent a collection of REST reference links.
    /// </summary>
    [JsonProperty("_links")]
    public ReferenceLinks? Links { get; set; }

    /// <summary>
    /// The author of the definition.
    /// </summary>
    [JsonProperty("authoredBy")]
    public IdentityRef? AuthoredBy { get; set; }

    /// <summary>
    /// The date this version of the definition was created.
    /// </summary>
    [JsonProperty("createdDate")]
    public string CreatedDate { get; set; } = string.Empty;

    /// <summary>
    /// A reference to the definition that this definition is a draft of, if this is a draft definition.
    /// </summary>
    [JsonProperty("draftOf")]
    public DefinitionReference? DraftOf { get; set; }

    /// <summary>
    /// The list of drafts associated with this definition, if this is not a draft definition.
    /// </summary>
    [JsonProperty("drafts")]
    public List<DefinitionReference>? Drafts { get; set; }

    /// <summary>
    /// The ID of the referenced definition.
    /// </summary>
    [JsonProperty("id")]
    public int Id { get; set; }

    /// <summary>
    /// Data representation of a build.
    /// </summary>
    [JsonProperty("latestBuild")]
    public Build? LatestBuild { get; set; }

    /// <summary>
    /// Data representation of a build.
    /// </summary>
    [JsonProperty("latestCompletedBuild")]
    public Build? LatestCompletedBuild { get; set; }

    /// <summary>
    /// Represents metadata about builds in the system.
    /// </summary>
    [JsonProperty("metrics")]
    public List<BuildMetric>? Metrics { get; set; }

    /// <summary>
    /// The name of the referenced definition.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The folder path of the definition.
    /// </summary>
    [JsonProperty("path")]
    public string Path { get; set; } = string.Empty;

    /// <summary>
    /// A reference to the project.
    /// </summary>
    [JsonProperty("project")]
    public TeamProjectReference? Project { get; set; }

    /// <summary>
    /// The quality of the definition document (draft, etc.)
    /// </summary>
    [JsonProperty("quality")]
    [JsonConverter(typeof(StringEnumConverter))]
    public DefinitionQuality? Quality { get; set; }

    /// <summary>
    /// The default queue for builds run against this definition.
    /// </summary>
    [JsonProperty("queue")]
    public AgentPoolQueue? Queue { get; set; }

    /// <summary>
    /// A value that indicates whether builds can be queued against this definition.
    /// </summary>
    [JsonProperty("queueStatus")]
    [JsonConverter(typeof(StringEnumConverter))]
    public DefinitionQueueStatus? QueueStatus { get; set; }

    /// <summary>
    /// The definition revision number.
    /// </summary>
    [JsonProperty("revision")]
    public int Revision { get; set; }

    /// <summary>
    /// The type of the definition.
    /// </summary>
    [JsonProperty("type")]
    [JsonConverter(typeof(StringEnumConverter))]
    public DefinitionType? Type { get; set; }


    /// <summary>
    /// The definition's URI.
    /// </summary>
    [JsonProperty("uri")]
    public string Uri { get; set; } = string.Empty;

    /// <summary>
    /// The REST URL of the definition.
    /// </summary>
    [JsonProperty("url")]
    public string Url { get; set; } = string.Empty;

}