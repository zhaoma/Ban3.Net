namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;

/// <summary>
/// Defaults to Latest.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/tfvc/items/get?view=azure-devops-server-rest-6.0&tabs=HTTP#tfvcversiontype
/// </summary>
public enum TfvcVersionType
{
    /// <summary>
    /// Version is treated as a Change.
    /// </summary>
    Change,

    /// <summary>
    /// Version is treated as a ChangesetId.
    /// </summary>
    Changeset,

    /// <summary>
    /// Version is treated as a Date.
    /// </summary>
    Date,

    /// <summary>
    /// If Version is defined the Latest of that Version will be used,
    /// if no version is defined the latest ChangesetId will be used.
    /// </summary>
    Latest,

    /// <summary>
    /// Version will be treated as a MergeSource.
    /// </summary>
    MergeSource,

    /// <summary>
    /// Version is treated as a ChangesetId.
    /// </summary>
    None,

    /// <summary>
    /// Version is treated as a Shelveset name and owner.
    /// </summary>
    Shelveset,

    /// <summary>
    /// Version will be treated as a Tip, if no version is defined latest will be used.
    /// </summary>
    Tip
}