namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// This is the shallow branchref class.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/tfvc/branches/get?view=azure-devops-server-rest-6.0&tabs=HTTP#tfvcshallowbranchref
/// </summary>
public class TfvcShallowBranchRef
{
    /// <summary>
    /// Path for the branch.
    /// </summary>
    public string Path { get; set; }
}