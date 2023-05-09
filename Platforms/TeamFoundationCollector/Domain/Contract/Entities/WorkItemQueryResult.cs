using System.Collections.Generic;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// The result of a work item query.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/wit/wiql/query-by-wiql?view=azure-devops-server-rest-6.0&tabs=HTTP#workitemqueryresult
/// </summary>
public class WorkItemQueryResult
{
    /// <summary>
    /// The date the query was run in the context of.
    /// </summary>
    [JsonProperty("asOf")]
    public string? AsOf { get; set; }

    /// <summary>
    /// The columns of the query.
    /// </summary>
    [JsonProperty("columns")]
    public List<WorkItemFieldReference>? Columns { get; set; }

    /// <summary>
    /// The result type
    /// </summary>
    [JsonProperty("queryResultType")]
    [JsonConverter(typeof(StringEnumConverter))]
    public QueryResultType? QueryResultType { get; set; }

    /// <summary>
    /// The type of the query
    /// </summary>
    [JsonProperty("queryType")]
    [JsonConverter(typeof(StringEnumConverter))]
    public QueryType? QueryType { get; set; }

    /// <summary>
    /// The sort columns of the query.
    /// </summary>
    [JsonProperty("sortColumns")]
    public List<WorkItemQuerySortColumn>? SortColumns { get; set; }

    /// <summary>
    /// The work item links returned by the query.
    /// </summary>
    [JsonProperty("workItemRelations")]
    public List<WorkItemLink>? WorkItemRelations { get; set; }

    /// <summary>
    /// The work items returned by the query.
    /// </summary>
    [JsonProperty("workItems")]
    public List<WorkItemReference>? WorkItems { get; set; }
}