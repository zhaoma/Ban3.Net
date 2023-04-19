namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;

/// <summary>
/// The type (error, warning) of the issue.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/timeline/get?view=azure-devops-rest-7.0#issuetype
/// </summary>
public enum IssueType
{
    Error,

    Warning
}