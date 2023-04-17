namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// Represents a build process.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/templates/get?view=azure-devops-rest-7.0#buildprocess
/// </summary>
public class BuildProcess
{
    /// <summary>
    /// The type of the process.
    /// </summary>
    public int Type { get; set; }
}