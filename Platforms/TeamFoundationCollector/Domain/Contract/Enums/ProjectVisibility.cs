namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;

/// <summary>
/// Project visibility.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/get?view=azure-devops-rest-7.0#projectvisibility
/// </summary>
public enum ProjectVisibility
{
    /// <summary>
    /// The project is only visible to users with explicit access.
    /// </summary>
    Private,

    /// <summary>
    /// The project is visible to all.
    /// </summary>
    Public
}