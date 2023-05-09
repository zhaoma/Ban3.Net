using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/wit/work-items/list?view=azure-devops-rest-7.0&tabs=HTTP#workitemrelation
/// </summary>
public class WorkItemRelation
{
    /// <summary>
    /// Collection of link attributes.
    /// </summary>
    [JsonProperty("attributes")]
    public object? Attributes { get; set; }

    /// <summary>
    /// Relation type.
    /// </summary>
    [JsonProperty("rel")]
    public string? Rel { get; set; }

    /// <summary>
    /// Link url.
    /// </summary>
    [JsonProperty("url")]
    public string? Url { get; set; }
}