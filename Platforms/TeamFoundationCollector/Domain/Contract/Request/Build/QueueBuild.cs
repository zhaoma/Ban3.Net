using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;
using System;
using System.Text;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Build;

/// <summary>
/// Queues a build
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/queue?view=azure-devops-rest-7.0
/// </summary>
public class QueueBuild
    : PresetRequest, IRequest
{
    public QueueBuild()
    {
        Method = "Post";
    }

    [JsonProperty("checkInTicket")] 
    public string? CheckInTicket { get; set; } 

    [JsonProperty("definitionId")]
    public int? DefinitionId { get; set; }

    [JsonProperty("ignoreWarnings")]
    public bool? IgnoreWarnings { get; set; }

    [JsonProperty("sourceBuildId")]
    public int? SourceBuildId { get; set; }

    public QueueBuildBody? Body { get; set; }

    public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/build/builds";

    public override string RequestBody() => JsonConvert.SerializeObject(Body);
}

