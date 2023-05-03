using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Pipelines;

/// <summary>
/// Runs a pipeline.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/pipelines/runs/run-pipeline?view=azure-devops-rest-7.0
/// </summary>
public class RunPipeline
    : PresetRequest, IRequest
{
    public RunPipeline() { Method = "Post"; }

    public int PipelineId { get; set; }

    [JsonProperty("pipelineVersion")]
    public int? PipelineVersion { get; set; }

    public RunPipelineBody? Body { get; set; }
    
    public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/pipelines/{PipelineId}/runs";

    public override string RequestBody() => JsonConvert.SerializeObject(Body);
}

