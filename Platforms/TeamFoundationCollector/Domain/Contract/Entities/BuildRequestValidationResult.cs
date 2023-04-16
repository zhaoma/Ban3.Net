using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// Represents the result of validating a build request.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/get?view=azure-devops-rest-7.0#buildrequestvalidationresult
/// </summary>
public class BuildRequestValidationResult
{
    /// <summary>
    /// The message associated with the result.
    /// </summary>
    public string Message { get; set; } = string.Empty;

    /// <summary>
    /// The result.
    /// </summary>
    public ValidationResult Result { get; set; }
}