using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Pipelines
{
    /// <summary>
    /// Get a list of logs from a pipeline run.
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/pipelines/logs/list?view=azure-devops-rest-7.0
    /// </summary>
    public class ListLogs
        : PresetRequest, IRequest
    {
        public string Method { get; set; } = "Get";

        [JsonProperty("pipelineId")] public int PipelineId { get; set; }

        [JsonProperty("runId")] public int RunId { get; set; }

        [JsonProperty("expand")] public GetLogExpandOptions? Expand { get; set; }
        
        public string RequestPath() =>
            $"{Instance}/{Organization}/{Project}/_apis/pipelines/{PipelineId}/runs/{RunId}/logs";
        
        public string RequestQuery() =>
            Expand != null
                ? $"?$expand={Expand}"
                : string.Empty;//$"?api-version={ApiVersion}";

        public string RequestBody() => string.Empty;

    }
}

