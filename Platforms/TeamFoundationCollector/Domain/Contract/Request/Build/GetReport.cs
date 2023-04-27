using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Build;

/// <summary>
/// Gets a build report.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/report/get?view=azure-devops-rest-7.0
/// </summary>
public class GetReport
    : PresetRequest, IRequest
{
    public string Method { get; set; } = "Get";

    /// <summary>
    /// The ID of the definition.
    /// </summary>
    [JsonProperty("buildId")]
    public int BuildId { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; } = string.Empty;
    
    public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/build/builds/{BuildId}/report";

    public string RequestQuery() => string.IsNullOrEmpty(Type)
        ? string.Empty
        : $"?type={Type}";

    public string RequestBody() => string.Empty;
}