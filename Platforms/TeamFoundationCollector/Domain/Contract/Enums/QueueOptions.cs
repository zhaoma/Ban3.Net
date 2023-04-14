namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;

/// <summary>
/// Additional options for queueing the build.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/get?view=azure-devops-rest-7.0#queueoptions
/// </summary>
public enum QueueOptions
{
    /// <summary>
    /// Create a plan Id for the build, do not run it
    /// </summary>
    DoNotRun,

    /// <summary>
    /// No queue options
    /// </summary>
    None
}