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

}