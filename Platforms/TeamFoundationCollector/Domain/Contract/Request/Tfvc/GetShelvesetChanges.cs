using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Tfvc;

/// <summary>
/// Get changes included in a shelveset.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/tfvc/shelvesets/get-shelveset-changes?view=azure-devops-rest-7.0
/// </summary>
public class GetShelvesetChanges
    : PresetRequest, IRequest
{
    public string Method { get; set; } = "Get";
    
    /// <summary>
    /// Unique identifier of label
    /// </summary>
    public string ShelvesetId { get; set; } = string.Empty;

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

    public string RequestPath() => $"{Instance}/{Organization}/_apis/tfvc/shelvesets/changes";

    public string RequestQuery()
    {
        var sb = new StringBuilder();

        sb.Append($"?shelvesetId={ShelvesetId}&");

        if (Skip != null)
            sb.Append($"$skip={Skip}&");
        if (Top != null)
            sb.Append($"$top={Top}&");

        sb.Append($"api-version={ApiVersion}");
        return sb.ToString();
    }

    public string RequestBody() => string.Empty;
}