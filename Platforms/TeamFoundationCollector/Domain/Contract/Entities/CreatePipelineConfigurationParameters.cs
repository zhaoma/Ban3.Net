using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// Configuration parameters of the pipeline.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/pipelines/pipelines/create?view=azure-devops-rest-7.0#createpipelineconfigurationparameters
/// </summary>
public class CreatePipelineConfigurationParameters
{
    [JsonProperty("type")]
    public ConfigurationType Type { get; set; }
}