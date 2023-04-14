namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;

/// <summary>
/// The result.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/get?view=azure-devops-rest-7.0#validationresult
/// </summary>
public enum ValidationResult
{
    Error,

    Ok,

    Warning
}