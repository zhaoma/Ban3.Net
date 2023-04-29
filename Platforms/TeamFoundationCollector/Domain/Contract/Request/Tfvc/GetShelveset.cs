using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Tfvc;

/// <summary>
/// Get a single deep shelveset.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/tfvc/shelvesets/get?view=azure-devops-rest-7.0
/// </summary>
public class GetShelveset
    : PresetRequest, IRequest
{
    [JsonProperty("shelvesetId")]
    public string ShelvesetId { get; set; } = string.Empty;

    [JsonProperty("requestData")]
    public SubCondition.RequestData? RequestData { get; set; }
    
    public string RequestPath() => $"{Instance}/{Organization}/_apis/tfvc/shelvesets";

    public string RequestQuery()
    {
        var sb = new StringBuilder();

        sb.Append($"?shelvesetId={ShelvesetId}&");
        
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

    

}