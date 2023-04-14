namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;

/// <summary>
/// The build status.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/get?view=azure-devops-rest-7.0#buildstatus
/// </summary>
public enum BuildStatus
{
    /// <summary>
    /// All status.
    /// </summary>
    All,

    /// <summary>
    /// The build is cancelling
    /// </summary>
    Canceling,

    /// <summary>
    /// The build has completed.
    /// </summary>
    Completed,

    /// <summary>
    /// The build is currently in progress.
    /// </summary>
    InProgress,

    /// <summary>
    /// No status.
    /// </summary>
    None,

    /// <summary>
    /// The build has not yet started.
    /// </summary>
    NotStarted,

    /// <summary>
    /// The build is inactive in the queue.
    /// </summary>
    PostPoned
}