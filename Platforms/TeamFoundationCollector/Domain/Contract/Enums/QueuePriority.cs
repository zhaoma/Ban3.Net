namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;

/// <summary>
/// The build's priority.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/get?view=azure-devops-rest-7.0#queuepriority
/// </summary>
public enum QueuePriority
{
    /// <summary>
    /// Above normal priority.
    /// </summary>
    AboveNormal,

    /// <summary>
    /// Below normal priority.
    /// </summary>
    BelowNormal,

    /// <summary>
    /// High priority.
    /// </summary>
    High,

    /// <summary>
    /// Low priority.
    /// </summary>
    Low,

    /// <summary>
    /// Normal priority.
    /// </summary>
    Normal
}