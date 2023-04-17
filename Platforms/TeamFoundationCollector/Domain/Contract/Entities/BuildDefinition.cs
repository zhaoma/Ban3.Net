using Newtonsoft.Json;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// Represents a build definition.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/templates/get?view=azure-devops-rest-7.0#builddefinition
/// </summary>
public class BuildDefinition
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
    /// Indicates whether badges are enabled for this definition.
    /// </summary>
    [JsonProperty("badgeEnabled")]
    public bool BadgeEnabled { get; set; }

    /// <summary>
    /// The build number format.
    /// </summary>
    [JsonProperty("buildNumberFormat")]
    public string BuildNumberFormat { get; set; } = string.Empty;

    /// <summary>
    /// A save-time comment for the definition.
    /// </summary>
    [JsonProperty("comment")]
    public string Comment { get; set; } = string.Empty;

    /// <summary>
    /// The date this version of the definition was created.
    /// </summary>
    [JsonProperty("createdDate")] 
    public string CreatedDate { get; set; } = string.Empty;

    /// <summary>
    /// Represents a demand used by a definition or build.
    /// </summary>
    [JsonProperty("demands")]
    public List<Demand>? Demands { get; set; }

    /// <summary>
    /// The description.
    /// </summary>
    [JsonProperty("description")] 
    public string Description { get; set; } = string.Empty;

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
    /// The drop location for the definition.
    /// </summary>
    [JsonProperty("dropLocation")]
    public string DropLocation { get; set; }=string.Empty;

    /// <summary>
    /// The ID of the referenced definition.
    /// </summary>
    [JsonProperty("id")]
    public int Id { get; set; }

    /// <summary>
    /// The job authorization scope for builds queued against this definition.
    /// </summary>
    [JsonProperty("jobAuthorizationScope")]
    public BuildAuthorizationScope JobAuthorizationScope { get; set; }

    /// <summary>
    /// The job cancel timeout (in minutes) for builds cancelled by user for this definition.
    /// </summary>
    [JsonProperty("jobCancelTimeoutInMinutes")]
    public int JobCancelTimeoutInMinutes { get; set; }

    /// <summary>
    /// The job execution timeout (in minutes) for builds queued against this definition.
    /// </summary>
    [JsonProperty("jobTimeoutInMinutes")]
    public int JobTimeoutInMinutes { get; set; }

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
    /// Represents the application of an optional behavior to a build definition.
    /// </summary>
    [JsonProperty("options")]
    public List<BuildOption>? Options { get; set; }

    /// <summary>
    /// The folder path of the definition.
    /// </summary>
    [JsonProperty("path")] 
    public string Path { get; set; } = string.Empty;

    /// <summary>
    /// The build process.
    /// </summary>
    [JsonProperty("process")]
    public BuildProcess? Process { get; set; }

    /// <summary>
    /// The process parameters for this definition.
    /// </summary>
    [JsonProperty("processParameters")]
    public ProcessParameters? ProcessParameters { get; set; }

    /// <summary>
    /// A reference to the project.
    /// </summary>
    [JsonProperty("project")]
    public TeamProjectReference? Project { get; set; }

    /// <summary>
    /// The class represents a property bag as a collection of key-value pairs.
    /// Values of all primitive types (any type with a TypeCode != TypeCode.Object) except for DBNull are accepted.
    /// Values of type Byte[], Int32, Double, DateType and String preserve their type, other primitives are retuned as a String. Byte[] expected as base64 encoded string.
    /// </summary>
    [JsonProperty("properties")]
    public PropertiesCollection? Properties { get; set; }

    /// <summary>
    /// The quality of the definition document (draft, etc.)
    /// </summary>
    [JsonProperty("quality")]
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
    public DefinitionQueueStatus? QueueStatus { get; set; }

    /// <summary>
    /// The repository.
    /// </summary>
    [JsonProperty("repository")]
    public BuildRepository? Repository { get; set; }

    /// <summary>
    /// Represents a retention policy for a build definition.
    /// </summary>
    [JsonProperty("retentionRules")]
    public List<RetentionPolicy>? RetentionRules { get; set; }

    /// <summary>
    /// The definition revision number.
    /// </summary>
    [JsonProperty("revision")]
    public int Revision { get; set; }

    [JsonProperty("tags")]
    public List<string>? Tags { get; set; }

    /// <summary>
    /// Represents a trigger for a buld definition.
    /// </summary>
    [JsonProperty("triggers")]
    public List<BuildTrigger>? Triggers { get; set; }

    /// <summary>
    /// The type of the definition.
    /// </summary>
    [JsonProperty("type")]
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

    /// <summary>
    /// Represents a variable group.
    /// </summary>
    [JsonProperty("variableGroups")]
    public List<VariableGroup>? VariableGroups { get; set; }
    
    [JsonProperty("variables")]
    public Dictionary<string, BuildDefinitionVariable>? Variables { get; set; }
}