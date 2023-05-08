namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;

/// <summary>
/// The order in which folders should be returned.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/folders/list?view=azure-devops-rest-7.0#folderqueryorder
/// </summary>
public enum FolderQueryOrder
{
    /// <summary>
    /// Order by folder name and path ascending.
    /// </summary>
    FolderAscending,

    /// <summary>
    /// Order by folder name and path descending.
    /// </summary>
    FolderDescending,

    /// <summary>
    /// No order
    /// </summary>
    None
}