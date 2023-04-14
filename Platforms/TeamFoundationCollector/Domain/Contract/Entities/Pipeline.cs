using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// Definition of a pipeline.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/pipelines/pipelines/get?view=azure-devops-rest-7.0#pipelineconfiguration
/// </summary>
public class Pipeline
{
    /// <summary>
    /// The class to represent a collection of REST reference links.
    /// </summary>
    [JsonProperty("_links")]
    public ReferenceLinks? Links { get; set; }

    /// 
    [JsonProperty("configuration")]
    public PipelineConfiguration? Configuration { get; set; }

    /// <summary>
    /// Pipeline folder
    /// </summary>
    [JsonProperty("folder")]
    public string Folder { get; set; } = string.Empty;

    /// <summary>
    /// Pipeline ID
    /// </summary>
    [JsonProperty("id")]
    public int Id { get; set; }

    /// <summary>
    /// Pipeline name
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Revision number
    /// </summary>
    [JsonProperty("revision")]
    public int Revision { get; set; }

    /// <summary>
    /// URL of the pipeline
    /// </summary>
    [JsonProperty("url")]
    public string Url { get; set; } = string.Empty;
}