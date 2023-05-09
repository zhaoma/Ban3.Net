namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;

/// <summary>
/// The result type
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/wit/wiql/query-by-wiql?view=azure-devops-server-rest-6.0&tabs=HTTP#queryresulttype
/// </summary>
public enum QueryResultType
{
    /// <summary>
    /// A list of work items (for flat queries).
    /// </summary>
    WorkItem,

    /// <summary>
    /// A list of work item links (for OneHop and Tree queries).
    /// </summary>
    WorkItemLink
}