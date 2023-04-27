namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;

/// <summary>
/// Indicates the order in which definitions should be returned.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/definitions/list?view=azure-devops-rest-7.0#definitionqueryorder
/// </summary>
public enum DefinitionQueryOrder
{
    /// <summary>
    /// Order by definition name ascending.
    /// </summary>
    DefinitionNameAscending,

    /// <summary>
    /// Order by definition name descending.
    /// </summary>
    DefinitionNameDescending,

    /// <summary>
    /// Order by created on/last modified time ascending.
    /// </summary>
    LastModifiedAscending,

    /// <summary>
    /// Order by created on/last modified time descending.
    /// </summary>
    LastModifiedDescending,

    /// <summary>
    /// No order
    /// </summary>
    None
}