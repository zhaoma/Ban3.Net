using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// Reference to a field in a work item
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/wit/wiql/query-by-wiql?view=azure-devops-server-rest-6.0&tabs=HTTP#workitemfieldreference
/// </summary>
public class WorkItemFieldReference
{
    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("referenceName")]
    public string? ReferenceName { get; set; }

    [JsonProperty("url")]
    public string? Url { get; set; }
}