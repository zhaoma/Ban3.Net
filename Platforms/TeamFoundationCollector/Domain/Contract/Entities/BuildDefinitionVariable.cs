using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// Represents a variable used by a build definition.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/templates/get?view=azure-devops-rest-7.0#builddefinitionvariable
/// </summary>
public class BuildDefinitionVariable
{
    /// <summary>
    /// Indicates whether the value can be set at queue time.
    /// </summary>
    [JsonProperty("allowOverride")]
    public bool AllowOverride { get; set; }

    /// <summary>
    /// Indicates whether the variable's value is a secret.
    /// </summary>
    [JsonProperty("isSecret")]
    public bool IsSecret { get; set; }

    /// <summary>
    /// The value of the variable.
    /// </summary>
    [JsonProperty("value")]
    public string Value { get; set; } = string.Empty;
}