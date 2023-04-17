using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// Represents the application of an optional behavior to a build definition.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/templates/get?view=azure-devops-rest-7.0#buildoption
/// </summary>
public class BuildOption
{
    /// <summary>
    /// A reference to the build option.
    /// </summary>
    [JsonProperty("definition")]
    public BuildOptionDefinitionReference? Definition { get; set; }

    /// <summary>
    /// Indicates whether the behavior is enabled.
    /// </summary>
    [JsonProperty("enabled")]
    public bool Enabled { get; set; }

    [JsonProperty("inputs")]
    public object? Inputs { get; set; }
}