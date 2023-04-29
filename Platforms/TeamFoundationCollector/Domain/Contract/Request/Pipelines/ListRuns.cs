using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Pipelines
{
    /// <summary>
    /// Gets top 10000 runs for a particular pipeline.
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/pipelines/runs/list?view=azure-devops-rest-7.0
    /// </summary>
    public class ListRuns
        : PresetRequest, IRequest
    {
public int PipelineId { get; set; }

        public string RequestPath() =>
            $"{Instance}/{Organization}/{Project}/_apis/pipelines/{PipelineId}/runs";

        public string RequestQuery() => string.Empty;//$"?api-version={ApiVersion}";

        
    }
}

