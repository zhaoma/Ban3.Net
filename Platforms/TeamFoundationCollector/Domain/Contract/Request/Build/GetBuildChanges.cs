using Newtonsoft.Json;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using System.Text;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Build;

/// <summary>
/// Gets the changes associated with a build
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/get-build-changes?view=azure-devops-rest-7.0
/// </summary>
public class GetBuildChanges
    : PresetRequest, IRequest
{
    public int BuildId { get; set; }

    [JsonProperty("$top")]
    public int? Top { get; set; }

    [JsonProperty("continuationToken")] 
    public string ContinuationToken { get; set; } = string.Empty;
    
    [JsonProperty("includeSourceChange")]
    public bool IncludeSourceChange { get; set; }
    
    public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/build/builds/{BuildId}/changes";
}

