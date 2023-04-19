using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Pipelines
{
    /// <summary>
    /// Gets a pipeline, optionally at the specified version
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/pipelines/pipelines/get?view=azure-devops-rest-7.0
    /// </summary>
    public class GetPipeline
        : PresetRequest, IRequest
    {
        public string Method { get; set; } = "Get";

        [JsonProperty("pipelineId")] 
        public int PipelineId { get; set; }

        [JsonProperty("pipelineVersion")] 
        public int? PipelineVersion { get; set; }

        public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/pipelines/{PipelineId}";

        public string RequestQuery() =>
            PipelineVersion != null
                ? $"?pipelineVersion={PipelineVersion}&api-version={ApiVersion}"
                : $"?api-version={ApiVersion}";

        public string RequestBody() => string.Empty;
    }
}

