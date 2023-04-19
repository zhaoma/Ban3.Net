using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/pipelines/runs/run-pipeline?view=azure-devops-rest-7.0#pipelineresourceparameters
/// </summary>
public class PipelineResourceParameters
{
    [JsonProperty("version")]
    public string Version { get; set; } = string.Empty;
}