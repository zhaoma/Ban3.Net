namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;

/// <summary>
/// The order in which builds should be returned.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/list?view=azure-devops-rest-7.0#buildqueryorder
/// </summary>
public enum BuildQueryOrder
{
    /// <summary>
    /// Order by finish time ascending.
    /// </summary>
    FinishTimeAscending,

    /// <summary>
    /// Order by finish time descending.
    /// </summary>
    FinishTimeDescending,

    /// <summary>
    /// Order by queue time ascending.
    /// </summary>
    QueueTimeAscending,

    /// <summary>
    /// Order by queue time descending.
    /// </summary>
    QueueTimeDescending,

    /// <summary>
    /// Order by start time ascending.
    /// </summary>
    StartTimeAscending,

    /// <summary>
    /// Order by start time descending.
    /// </summary>
    StartTimeDescending
}