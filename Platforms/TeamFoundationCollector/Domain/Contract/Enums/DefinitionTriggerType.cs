namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;

/// <summary>
/// The type of the trigger.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/templates/get?view=azure-devops-rest-7.0#definitiontriggertype
/// </summary>
public enum DefinitionTriggerType
{
    /// <summary>
    /// All types.
    /// </summary>
    All,

    /// <summary>
    /// A build should be started for multiple changesets at a time at a specified interval.
    /// </summary>
    BatchedContinuousIntegration	,

    /// <summary>
    /// A validation build should be started for each batch of check-ins.
    /// </summary>
    BatchedGatedCheckIn,
    
    /// <summary>
    /// A build should be triggered when another build completes.
    /// </summary>
    BuildCompletion,
   
    /// <summary>
    /// A build should be started for each changeset.
    /// </summary>
    ContinuousIntegration,

    /// <summary>
    /// A validation build should be started for each check-in.
    /// </summary>
    GatedCheckIn,

    /// <summary>
    /// Manual builds only.
    /// </summary>
    None	,

    /// <summary>
    /// A build should be triggered when a GitHub pull request is created or updated. Added in resource version 3
    /// </summary>
    PullRequest,

    /// <summary>
    /// A build should be started on a specified schedule whether or not changesets exist.
    /// </summary>
    Schedule
}