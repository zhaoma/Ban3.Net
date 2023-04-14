namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;

/// <summary>
/// A value that indicates whether builds can be queued against this definition.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/get?view=azure-devops-rest-7.0#definitionqueuestatus
/// </summary>
public enum DefinitionQueueStatus
{
    /// <summary>
    /// When disabled the definition queue will not allow builds to be queued by users and the system will not queue scheduled,
    /// gated or continuous integration builds. Builds already in the queue will not be started by the system.
    /// </summary>
    Disabled,

    /// <summary>
    /// When enabled the definition queue allows builds to be queued by users, the system will queue scheduled,
    /// gated and continuous integration builds, and the queued builds will be started by the system.
    /// </summary>
    Enabled,

    /// <summary>
    /// When paused the definition queue allows builds to be queued by users and the system will queue scheduled,
    /// gated and continuous integration builds. Builds in the queue will not be started by the system.
    /// </summary>
    Paused
}