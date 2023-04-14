using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/pipelines/pipelines/get?view=azure-devops-rest-7.0#pipelineconfiguration
/// </summary>
public class PipelineConfiguration
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("type")]
    public ConfigurationType Type { get; set; }
}