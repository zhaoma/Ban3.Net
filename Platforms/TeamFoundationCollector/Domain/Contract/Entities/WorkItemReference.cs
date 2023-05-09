using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// Contains reference to a work item.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/wit/wiql/query-by-wiql?view=azure-devops-server-rest-6.0&tabs=HTTP#workitemreference
/// </summary>
public class WorkItemReference
{
    [JsonProperty("id")]
    public int? Id { get; set; }

    [JsonProperty("url")]
    public string? Url { get; set; }
}