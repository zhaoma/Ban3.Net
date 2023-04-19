using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// Parameters to create a pipeline.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/pipelines/pipelines/create?view=azure-devops-rest-7.0#createpipelineparameters
/// </summary>
public class CreatePipelineParameters
{
    /// <summary>
    /// Configuration parameters of the pipeline.
    /// </summary>
    [JsonProperty("configuration")]
    public CreatePipelineConfigurationParameters? Configuration { get; set; }

    /// <summary>
    /// Folder of the pipeline.
    /// </summary>
    [JsonProperty("folder")]
    public string Folder { get; set; } = string.Empty;

    /// <summary>
    /// Name of the pipeline.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;
}