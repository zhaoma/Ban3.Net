namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;

/// <summary>
/// Defaults to OneLevel.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/tfvc/items/get?view=azure-devops-server-rest-6.0&tabs=HTTP#versioncontrolrecursiontype
/// </summary>
public enum VersionControlRecursionType
{
    /// <summary>
    /// Return specified item and all descendants
    /// </summary>
    Full,

    /// <summary>
    /// Only return the specified item.
    /// </summary>
    None,

    /// <summary>
    /// Return the specified item and its direct children.
    /// </summary>
    OneLevel,

    /// <summary>
    /// Return the specified item and its direct children,
    /// as well as recursive chains of nested child folders that only contain a single folder.
    /// </summary>
    OneLevelPlusNestedEmptyFolders
}