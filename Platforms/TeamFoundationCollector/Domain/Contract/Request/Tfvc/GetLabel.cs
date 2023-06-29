using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Tfvc;

/// <summary>
/// Get a single deep label.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/tfvc/labels/get?view=azure-devops-rest-7.0
/// </summary>
public class GetLabel
    : PresetRequest, IRequest
{
    /// <summary>
    /// Unique identifier of label
    /// </summary>
    public string LabelId { get; set; } = string.Empty;

    [JsonProperty("requestData")]
    public SubCondition.GetLabelRequestData? RequestData { get; set; }


    public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/tfvc/labels/{LabelId}";

    /*
    public string RequestQuery()
    {
        var sb = new StringBuilder();

        sb.Append("?");
        
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
    */
    
}