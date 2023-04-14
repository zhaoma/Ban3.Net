namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;

/// <summary>
/// The build result.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/get?view=azure-devops-rest-7.0#buildresult
/// </summary>
public enum BuildResult
{
    /// <summary>
    /// The build was canceled before starting.
    /// </summary>
    Canceled,

    /// <summary>
    /// The build completed unsuccessfully.
    /// </summary>
    Failed,

    /// <summary>
    /// No result
    /// </summary>
    None,

    /// <summary>
    /// The build completed compilation successfully but had other errors.
    /// </summary>
    PartiallySucceeded,

    /// <summary>
    /// The build completed successfully.
    /// </summary>
    Succeeded
}