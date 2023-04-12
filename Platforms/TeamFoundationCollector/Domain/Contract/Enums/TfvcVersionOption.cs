namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;

/// <summary>
/// Defaults to None.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/tfvc/items/get?view=azure-devops-server-rest-6.0&tabs=HTTP#tfvcversionoption
/// </summary>
public enum TfvcVersionOption
{
    /// <summary>
    /// None.
    /// </summary>
    None,

    /// <summary>
    /// Return the previous version.
    /// </summary>
    Previous,

    /// <summary>
    /// Only usuable with versiontype MergeSource and integer versions,
    /// uses RenameSource identifier instead of Merge identifier.
    /// </summary>
    UseRename
}