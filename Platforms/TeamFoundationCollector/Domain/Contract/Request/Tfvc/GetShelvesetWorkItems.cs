using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using System.Text;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Tfvc;

public class GetShelvesetWorkItems
    : PresetRequest, IRequest
{
    public string Method { get; set; } = "Get";
    
    /// <summary>
    /// Unique identifier of label
    /// </summary>
    public string ShelvesetId { get; set; } = string.Empty;
    
    public string RequestPath() => $"{Instance}/{Organization}/_apis/tfvc/shelvesets/workitems";

    public string RequestQuery()
    {
        var sb = new StringBuilder();

        sb.Append($"?shelvesetId={ShelvesetId}&");

        sb.Append($"api-version={ApiVersion}");
        return sb.ToString();
    }

    public string RequestBody() => string.Empty;
}