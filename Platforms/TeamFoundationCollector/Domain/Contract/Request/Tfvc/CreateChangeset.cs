using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Tfvc;

/// <summary>
/// Create a new changeset.
/// Accepts TfvcChangeset as JSON body
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/tfvc/changesets/create?view=azure-devops-rest-7.0&tabs=HTTP
/// </summary>
public class CreateChangeset
    : PresetRequest, IRequest
{
    public string Method { get; set; } = "Post";

    /// <summary>
    /// Version of the API to use. This should be set to '7.0' to use this version of the api.
    /// </summary>
    public string ApiVersion { get; set; } = "7.0";

    public CreateChangesetBody? Body { get; set; }

    public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/tfvc/changesets";

    public string RequestQuery() => $"?api-version={ApiVersion}";

    public string RequestBody() => JsonConvert.SerializeObject(Body);

}