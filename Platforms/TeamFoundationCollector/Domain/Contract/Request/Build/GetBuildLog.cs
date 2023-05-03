using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Build;

/// <summary>
/// Gets an individual log file for a build.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/get-build-log?view=azure-devops-rest-7.0
/// </summary>
public class GetBuildLog
    : PresetRequest, IRequest
{
    /// <summary>
    /// The ID of the build.
    /// </summary>
    public int BuildId { get; set; }

    /// <summary>
    /// The ID of the log file.
    /// </summary>
    public int LogId { get; set; }

    [JsonProperty("endLine")]
    public long? EndLine { get; set; }

    [JsonProperty("startLine")]
    public long? StartLine { get; set; }
    
    public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/build/builds/{BuildId}/logs/{LogId}";
}

