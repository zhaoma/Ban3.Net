namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;

/// <summary>
/// The type of query.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/wit/wiql/query-by-wiql?view=azure-devops-server-rest-6.0&tabs=HTTP#queryresulttype
/// </summary>
public enum QueryType
{
    /// <summary>
    /// Gets a flat list of work items.
    /// </summary>
    Flat,

    /// <summary>
    /// Gets a list of work items and their direct links.
    /// </summary>
    OneHop,

    /// <summary>
    /// Gets a tree of work items showing their link hierarchy.
    /// </summary>
    Tree
}