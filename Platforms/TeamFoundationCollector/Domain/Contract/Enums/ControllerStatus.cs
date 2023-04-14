namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;

/// <summary>
/// The status of the controller.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/get?view=azure-devops-rest-7.0#controllerstatus
/// </summary>
public enum ControllerStatus
{
    /// <summary>
    /// Indicates that the build controller is currently available.
    /// </summary>
    Available,

    /// <summary>
    /// Indicates that the build controller has taken itself offline.
    /// </summary>
    Offline,

    /// <summary>
    /// Indicates that the build controller cannot be contacted.
    /// </summary>
    Unavailable
}