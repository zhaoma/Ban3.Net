using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/tfvc/items/get?view=azure-devops-server-rest-6.0&tabs=HTTP#filecontentmetadata
/// </summary>
public class FileContentMetadata
{
    [JsonProperty("contentType")]
    public string ContentType { get; set; } = string.Empty;

    [JsonProperty("encoding")]
    public int Encoding { get; set; }

    [JsonProperty("extension")]
    public string Extension { get; set; } = string.Empty;

    [JsonProperty("fileName")]
    public string FileName { get; set; } = string.Empty;

    [JsonProperty("isBinary")]
    public bool IsBinary { get; set; }

    [JsonProperty("isImage")]
    public bool IsImage { get; set; }

    [JsonProperty("vsLink")]
    public string VSLink { get; set; } = string.Empty;
}