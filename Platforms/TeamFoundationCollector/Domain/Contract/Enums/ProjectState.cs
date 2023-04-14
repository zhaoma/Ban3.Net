namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;

/// <summary>
/// Project state.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/get?view=azure-devops-rest-7.0#projectstate
/// </summary>
public enum ProjectState
{
    /// <summary>
    /// All projects regardless of state except Deleted.
    /// </summary>
    All,

    /// <summary>
    /// Project has been queued for creation, but the process has not yet started.
    /// </summary>
    CreatePending,

    /// <summary>
    /// Project has been deleted.
    /// </summary>
    Deleted,

    /// <summary>
    /// Project is in the process of being deleted.
    /// </summary>
    Deleting,

    /// <summary>
    /// Project is in the process of being created.
    /// </summary>
    New,

    /// <summary>
    /// Project has not been changed.
    /// </summary>
    Unchanged,

    /// <summary>
    /// Project is completely created and ready to use.
    /// </summary>
    WellFormed
}