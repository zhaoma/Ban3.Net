using Newtonsoft.Json;
using System.Text;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Pipelines;

/// <summary>
/// Get a list of pipelines.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/pipelines/pipelines/list?view=azure-devops-rest-7.0
/// </summary>
public class ListPipelines
    : PresetRequest, IRequest
{

    [JsonProperty("$top")] public int? Top { get; set; }

    [JsonProperty("continuationToken")] public string ContinuationToken { get; set; } = string.Empty;

    [JsonProperty("$orderby")] public string OrderBy { get; set; } = string.Empty;

    public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/pipelines";
}

