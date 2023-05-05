using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// Represents a variable group.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/templates/get?view=azure-devops-rest-7.0#variablegroup
/// </summary>
public class VariableGroup
{
    /// <summary>
    /// The Name of the variable group.
    /// </summary>
    [JsonProperty("alias")]
    public string Alias { get; set; } = string.Empty;

    /// <summary>
    /// The description.
    /// </summary>
    [JsonProperty("description")]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// The ID of the variable group.
    /// </summary>
    [JsonProperty("id")]
    public int Id { get; set; }

    /// <summary>
    /// The name of the variable group.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The type of the variable group.
    /// </summary>
    [JsonProperty("type")] 
    public string Type { get; set; } = string.Empty;
    
    [JsonProperty("variables")]
    public Dictionary<string,BuildDefinitionVariable>? Variables { get; set; }
}