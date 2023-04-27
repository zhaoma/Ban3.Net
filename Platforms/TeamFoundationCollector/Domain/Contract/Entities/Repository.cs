using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/pipelines/runs/get?view=azure-devops-rest-7.0#repository
/// </summary>
public class Repository
{
    [JsonProperty("type")]
    [JsonConverter(typeof(StringEnumConverter))]
    public RepositoryType Type { get; set; }
}
