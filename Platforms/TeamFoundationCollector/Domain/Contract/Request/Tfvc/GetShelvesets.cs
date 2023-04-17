using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Tfvc;

/// <summary>
/// Return a collection of shallow shelveset references.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/tfvc/shelvesets/list?view=azure-devops-rest-7.0&tabs=HTTP
/// </summary>
public class GetShelvesets
    : PresetRequest, IRequest
{
    public string Method { get; set; } = "Get";

    /// <summary>
    /// Version of the API to use. This should be set to '7.0' to use this version of the api.
    /// </summary>
    public string ApiVersion { get; set; } = "7.0";

    /// <summary>
    /// Number of results to skip.
    /// Default: null
    /// </summary>
    [JsonProperty("skip")]
    public int? Skip { get; set; }

    /// <summary>
    /// The maximum number of results to return.
    /// Default: null
    /// </summary>
    [JsonProperty("top")]
    public int? Top { get; set; }

    [JsonProperty("requestData")]
    public GetShelvesetRequestData? RequestData { get; set; }


    public string RequestPath() => $"{Instance}/{Organization}/_apis/tfvc/shelvesets";

    public string RequestQuery()
    {
        var sb = new StringBuilder();

        sb.Append($"?");

        if (Skip != null)
            sb.Append($"$skip={Skip}&");
        if (Top != null)
            sb.Append($"$top={Top}&");

        if (RequestData != null)
        {
            sb.Append($"requestData.includeDetails={RequestData.IncludeDetails}&");
            sb.Append($"requestData.includeLinks={RequestData.IncludeLinks}&");
            sb.Append($"requestData.includeWorkItems={RequestData.IncludeWorkItems}&");
            sb.Append($"requestData.maxChangeCount={RequestData.MaxChangeCount}&");
            sb.Append($"requestData.maxCommentLength={RequestData.MaxCommentLength}&");
            sb.Append($"requestData.name={RequestData.Name}&");
            sb.Append($"requestData.owner={RequestData.Owner}&");
        }

        sb.Append($"api-version={ApiVersion}");
        return sb.ToString();
    }

    public string RequestBody() => string.Empty;


}