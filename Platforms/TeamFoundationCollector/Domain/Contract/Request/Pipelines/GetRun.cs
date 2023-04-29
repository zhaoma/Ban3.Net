using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Pipelines
{
    /// <summary>
    /// Gets a run for a particular pipeline.
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/pipelines/runs/get?view=azure-devops-rest-7.0
    /// </summary>
    public class GetRun
        : PresetRequest, IRequest
    {
        public int PipelineId { get; set; }

        public int RunId { get; set; }

        public string RequestPath() =>
            $"{Instance}/{Organization}/{Project}/_apis/pipelines/{PipelineId}/runs/{RunId}";

        public string RequestQuery() => string.Empty;// $"?api-version={ApiVersion}";

        
    }
}
