using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Tfvc;

/// <summary>
/// Retrieves the work items associated with a particular changeset.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/tfvc/changesets/get-changeset-work-items?view=azure-devops-rest-7.0
/// </summary>
public class GetChangesetWorkItems
    : PresetRequest, IRequest
{
    /// <summary>
    /// ID of the changeset. 
    /// </summary>
    public int Id { get; set; }
    
    public string RequestPath() => $"{Instance}/{Organization}/_apis/tfvc/changesets/{Id}/workItems";

    public string RequestQuery() => $"?api-version={ApiVersion}";

    
}