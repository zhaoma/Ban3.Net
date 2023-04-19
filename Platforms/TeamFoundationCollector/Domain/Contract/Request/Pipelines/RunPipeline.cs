using Ban3.Infrastructures.NetHttp.Request;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;
using System;
namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Pipelines
{
    /// <summary>
    /// Runs a pipeline.
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/pipelines/runs/run-pipeline?view=azure-devops-rest-7.0
    /// </summary>
    public class RunPipeline
        : PresetRequest, IRequest
    {
        public string Method { get; set; } = "Post";

        [JsonProperty("pipelineId")]
        public int PipelineId { get; set; }

        [JsonProperty("pipelineVersion")]
        public int? PipelineVersion { get; set; }

        public RunPipelineBody? Body { get; set; }
        
        public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/pipelines/{PipelineId}/runs";

        public string RequestQuery() =>
            PipelineVersion != null
                ? $"?pipelineVersion={PipelineVersion}&api-version={ApiVersion}"
                : $"?api-version={ApiVersion}";

        public string RequestBody() => JsonConvert.SerializeObject(Body);
    }
}

