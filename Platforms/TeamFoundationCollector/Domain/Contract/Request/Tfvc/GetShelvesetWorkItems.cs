using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Tfvc;

public class GetShelvesetWorkItems
    : PresetRequest, IRequest
{
    /// <summary>
    /// Unique identifier of label
    /// </summary>
    [JsonProperty("shelvesetId")]
    public string ShelvesetId { get; set; } = string.Empty;

    public string RequestPath() => $"{Instance}/{Organization}/_apis/tfvc/shelvesets/workitems";

}