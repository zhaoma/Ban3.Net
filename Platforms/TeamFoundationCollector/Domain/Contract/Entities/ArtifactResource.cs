using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/artifacts/get-artifact?view=azure-devops-server-rest-6.0
/// </summary>
public class ArtifactResource
{
    /// <summary>
    /// The class to represent a collection of REST reference links.
    /// </summary>
    [JsonProperty("_links")]
    public ReferenceLinks? Links { get; set; }

    /// <summary>
    /// Type-specific data about the artifact.
    /// </summary>
    [JsonProperty("data")]
    public string Data { get; set; } = string.Empty;

    /// <summary>
    /// A link to download the resource.
    /// </summary>
    [JsonProperty("downloadUrl")]
    public string DownloadUrl { get; set; } = string.Empty;

    /// <summary>
    /// Type-specific properties of the artifact.
    /// </summary>
    [JsonProperty("properties")]
    public object? Properties { get; set; }

    /// <summary>
    /// The type of the resource: File container, version control folder, UNC path, etc.
    /// </summary>
    [JsonProperty("type")]
    public string Type { get; set; } = string.Empty;

    /// <summary>
    /// The full http link to the resource.
    /// </summary>
    [JsonProperty("url")]
    public string Url { get; set; } = string.Empty;
}
