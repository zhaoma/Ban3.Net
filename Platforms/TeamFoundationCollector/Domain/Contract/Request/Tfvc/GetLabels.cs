using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Tfvc;

/// <summary>
/// Get a collection of shallow label references.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/tfvc/labels/list?view=azure-devops-rest-7.0&tabs=HTTP
/// </summary>
public class GetLabels
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
    public GetLabelRequestData? RequestData { get; set; }


    public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/tfvc/labels";

    public string RequestQuery()
    {
        var sb = new StringBuilder();

        sb.Append("?");
        
        if (Skip != null)
            sb.Append($"$skip={Skip}&");
        if (Top != null)
            sb.Append($"$top={Top}&");
        
        if (RequestData != null)
        {
            sb.Append($"requestData.includeLinks={RequestData.IncludeLinks}&");
            sb.Append($"requestData.itemLabelFilter={RequestData.ItemLabelFilter}&");
            sb.Append($"requestData.labelScope={RequestData.LabelScope}&");
            sb.Append($"requestData.maxItemCount={RequestData.MaxItemCount}&");
            sb.Append($"requestData.name={RequestData.Name}&");
            sb.Append($"requestData.owner={RequestData.Owner}&");
        }

        sb.Append($"api-version={ApiVersion}");
        return sb.ToString();
    }

    public string RequestBody() => string.Empty;
}