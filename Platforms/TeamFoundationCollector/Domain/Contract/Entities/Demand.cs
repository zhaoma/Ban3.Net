using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// Represents a demand used by a definition or build.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/get?view=azure-devops-rest-7.0#demand
/// </summary>
public class Demand
{
    /// <summary>
    /// The name of the capability referenced by the demand.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// The demanded value.
    /// </summary>
    [JsonProperty("value")]
    public string Value { get; set; }
}