using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// A sort column.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/wit/wiql/query-by-wiql?view=azure-devops-server-rest-6.0&tabs=HTTP#workitemquerysortcolumn
/// </summary>
public class WorkItemQuerySortColumn
{
    /// <summary>
    /// The direction to sort by.
    /// </summary>
    [JsonProperty("descending")]
    public bool? Descending { get; set; }

    [JsonProperty("field")]
    public WorkItemFieldReference? Field { get; set; }
}