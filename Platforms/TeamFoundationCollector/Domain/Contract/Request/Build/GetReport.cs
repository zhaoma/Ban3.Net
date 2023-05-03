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
    public int BuildId { get; set; }

    [JsonProperty("type")]
    public string? Type { get; set; } 
    
    public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/build/builds/{BuildId}/report";
}