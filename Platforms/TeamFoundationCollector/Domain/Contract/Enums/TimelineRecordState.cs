namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;

/// <summary>
/// The state of the record.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/timeline/get?view=azure-devops-rest-7.0#timelinerecordstate
/// </summary>
public enum TimelineRecordState
{
    Completed,

    InProgress,

    Pending
}