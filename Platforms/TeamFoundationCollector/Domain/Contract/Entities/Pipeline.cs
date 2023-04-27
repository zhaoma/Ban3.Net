using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// Definition of a pipeline.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/pipelines/pipelines/get?view=azure-devops-rest-7.0#pipelineconfiguration
/// </summary>
public class Pipeline
    : PipelineReference
{
    /// <summary>
    /// The class to represent a collection of REST reference links.
    /// </summary>
    [JsonProperty("_links")]
    public ReferenceLinks? Links { get; set; }

    /// 
    [JsonProperty("configuration")]
    [JsonConverter(typeof(StringEnumConverter))]
    public PipelineConfiguration? Configuration { get; set; }

}