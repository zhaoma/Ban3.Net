namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;

/// <summary>
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/timeline/get?view=azure-devops-rest-7.0#taskresult
/// </summary>
public enum TaskResult
{
    Abandoned,

    Canceled,

    Failed,

    Skipped,

    Succeeded,

    SucceededWithIssues
}