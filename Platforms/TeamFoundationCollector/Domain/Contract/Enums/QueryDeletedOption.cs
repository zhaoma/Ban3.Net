namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;

/// <summary>
/// Indicates whether to exclude, include, or only return deleted builds.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/list?view=azure-devops-rest-7.0#querydeletedoption
/// </summary>
public enum QueryDeletedOption
{
    /// <summary>
    /// Include only non-deleted builds.
    /// </summary>
    ExcludeDeleted,

    /// <summary>
    /// Include deleted and non-deleted builds.
    /// </summary>
    IncludeDeleted,

    /// <summary>
    /// Include only deleted builds.
    /// </summary>
    OnlyDeleted
}