using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// A reference to a Pipeline.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/pipelines/runs/get?view=azure-devops-rest-7.0#pipelinereference
/// </summary>
public class PipelineReference
{
    /// <summary>
    /// Pipeline folder
    /// </summary>
    [JsonProperty("folder")]
    public string Folder { get; set; } = string.Empty;

    /// <summary>
    /// Pipeline ID
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Pipeline name
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Revision number
    /// </summary>
    [JsonProperty("revision")]
    public string Revision { get; set; } = string.Empty;

    [JsonProperty("url")] public string Url { get; set; } = string.Empty;
}
