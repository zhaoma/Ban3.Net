using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Tfvc;

/// <summary>
/// Retrieves the work items associated with a particular changeset.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/tfvc/changesets/get-changeset-work-items?view=azure-devops-rest-7.0&tabs=HTTP
/// </summary>
public class GetChangesetWorkItems
    : PresetRequest, IRequest
{
    public string Method { get; set; } = "Get";

    /// <summary>
    /// Version of the API to use. This should be set to '7.0' to use this version of the api.
    /// </summary>
    public string ApiVersion { get; set; } = "7.0";

    /// <summary>
    /// ID of the changeset. 
    /// </summary>
    [JsonProperty("id")]
    public int Id { get; set; }
    
    public string RequestPath() => $"{Instance}/{Organization}/_apis/tfvc/changesets/{Id}/changes";

    public string RequestQuery() => $"?api-version={ApiVersion}";

    public string RequestBody() => string.Empty;
}