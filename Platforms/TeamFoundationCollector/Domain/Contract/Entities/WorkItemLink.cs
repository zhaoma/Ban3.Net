using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// A link between two work items.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/wit/wiql/query-by-wiql?view=azure-devops-server-rest-6.0&tabs=HTTP#workitemlink
/// </summary>
public class WorkItemLink
{
    /// <summary>
    /// The type of link.
    /// </summary>
    [JsonProperty("rel")]
    public string? Rel { get; set; }

    /// <summary>
    /// The source work item.
    /// </summary>
    [JsonProperty("source")]
    public WorkItemReference? Source { get; set; }

    /// <summary>
    /// The target work item.
    /// </summary>
    [JsonProperty("target")]
    public WorkItemReference? Target { get; set; }
}