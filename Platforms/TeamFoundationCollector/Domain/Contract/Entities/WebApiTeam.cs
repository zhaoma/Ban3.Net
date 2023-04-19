using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/core/teams/get?view=azure-devops-rest-7.0#webapiteam
/// </summary>
public class WebApiTeam
{
    [JsonProperty("description")]
    public string Description { get; set; } = string.Empty;

    [JsonProperty("id")]
    public string Id { get; set; } = string.Empty;


}