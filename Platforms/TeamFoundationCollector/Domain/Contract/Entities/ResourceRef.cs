using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/get-build-work-items-refs?view=azure-devops-rest-7.0#resourceref
/// </summary>
public class ResourceRef
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }
}