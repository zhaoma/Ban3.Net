using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// Represents a reference to a build option definition.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/templates/get?view=azure-devops-rest-7.0#buildoptiondefinitionreference
/// </summary>
public class BuildOptionDefinitionReference
{
    /// <summary>
    /// The ID of the referenced build option.
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; } = string.Empty;
}