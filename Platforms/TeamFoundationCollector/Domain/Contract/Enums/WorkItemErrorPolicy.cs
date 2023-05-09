namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;

/// <summary>
/// The flag to control error policy in a bulk get work items request. Possible options are {Fail, Omit}.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/wit/work-items/list?view=azure-devops-rest-7.0&tabs=HTTP#workitemerrorpolicy
/// </summary>
public enum WorkItemErrorPolicy
{
    /// <summary>
    /// Fail work error policy.
    /// </summary>
    Fail,

    /// <summary>
    /// Omit work error policy.
    /// </summary>
    Omit
}