using System.Collections.Generic;
using Newtonsoft.Json;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Newtonsoft.Json.Converters;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// Represents a build definition.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/templates/get?view=azure-devops-rest-7.0#builddefinition
/// </summary>
public class BuildDefinition
: BuildDefinitionReference
{
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
    /// The drop location for the definition.
    /// </summary>
    [JsonProperty("dropLocation")]
    public string DropLocation { get; set; }=string.Empty;
    
    /// <summary>
    /// The job authorization scope for builds queued against this definition.
    /// </summary>
    [JsonProperty("jobAuthorizationScope")]
    [JsonConverter(typeof(StringEnumConverter))]
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
    /// Represents the application of an optional behavior to a build definition.
    /// </summary>
    [JsonProperty("options")]
    public List<BuildOption>? Options { get; set; }
    
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
    /// The class represents a property bag as a collection of key-value pairs.
    /// Values of all primitive types (any type with a TypeCode != TypeCode.Object) except for DBNull are accepted.
    /// Values of type Byte[], Int32, Double, DateType and String preserve their type, other primitives are retuned as a String. Byte[] expected as base64 encoded string.
    /// </summary>
    [JsonProperty("properties")]
    public PropertiesCollection? Properties { get; set; }
    
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
    
    [JsonProperty("tags")]
    public List<string>? Tags { get; set; }

    /// <summary>
    /// Represents a trigger for a buld definition.
    /// </summary>
    [JsonProperty("triggers")]
    public List<BuildTrigger>? Triggers { get; set; }
    
    /// <summary>
    /// Represents a variable group.
    /// </summary>
    [JsonProperty("variableGroups")]
    public List<VariableGroup>? VariableGroups { get; set; }
    
    [JsonProperty("variables")]
    public Dictionary<string, BuildDefinitionVariable>? Variables { get; set; }
}