using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// Represents metadata about builds in the system.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/templates/get?view=azure-devops-rest-7.0#buildmetric
/// </summary>
public class BuildMetric
{
    /// <summary>
    /// The date for the scope.
    /// </summary>
    [JsonProperty("date")]
    public string Date { get; set; } = string.Empty;

    /// <summary>
    /// The value.
    /// </summary>
    [JsonProperty("intValue")]
    public int IntValue { get; set; }

    /// <summary>
    /// The name of the metric.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The scope.
    /// </summary>
    [JsonProperty("scope")]
    public string Scope { get; set; } = string.Empty;
}