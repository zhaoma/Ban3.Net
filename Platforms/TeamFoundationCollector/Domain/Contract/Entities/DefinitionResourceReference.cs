using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/authorizedresources/authorize-project-resources?view=azure-devops-server-rest-6.0#definitionresourcereference
/// </summary>
public class DefinitionResourceReference
{
    /// <summary>
    /// Indicates whether the resource is authorized for use.
    /// </summary>
    [JsonProperty("authorized")]
    public bool Authorized { get; set; }

    /// <summary>
    /// The id of the resource.
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// A friendly name for the resource.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The type of the resource.
    /// </summary>
    [JsonProperty("type")]
    public string Type { get; set; } = string.Empty;
}
