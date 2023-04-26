using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Pipelines
{
    /// <summary>
    /// Get a specific log from a pipeline run
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/pipelines/logs/get?view=azure-devops-rest-7.0
    /// </summary>
    public class GetLog
        : PresetRequest, IRequest
    {
        public string Method { get; set; } = "Get";

        [JsonProperty("logId")] public int LogId { get; set; }

        [JsonProperty("pipelineId")] public int PipelineId { get; set; }

        [JsonProperty("runId")] public int RunId { get; set; }

        [JsonProperty("expand")] public GetLogExpandOptions? Expand { get; set; }

        public string RequestPath() =>
            $"{Instance}/{Organization}/{Project}/_apis/pipelines/{PipelineId}/runs/{RunId}/logs/{LogId}";

        public string RequestQuery() =>
            Expand != null
                ? $"?$expand={Expand}"
                : string.Empty;//$"?api-version={ApiVersion}";

        public string RequestBody() => string.Empty;
    }
}

