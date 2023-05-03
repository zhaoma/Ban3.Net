using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Tfvc;

/// <summary>
/// Get a collection of shallow label references.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/tfvc/labels/list?view=azure-devops-rest-7.0
/// </summary>
public class GetLabels
    : PresetRequest, IRequest
{
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
    public SubCondition.GetLabelRequestData? RequestData { get; set; }


    public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/tfvc/labels";
    
}