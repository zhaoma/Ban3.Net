using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/core/teams/get?view=azure-devops-rest-7.0#webapiteam
/// </summary>
public class WebApiTeam
{
    /// <summary>
    /// Team (Identity) Guid. A Team Foundation ID.
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Team name
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Team REST API Url
    /// </summary>
    [JsonProperty("url")]
    public string Url { get; set; } = string.Empty;

    /// <summary>
    /// Team description
    /// </summary>
    [JsonProperty("description")]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Identity REST API Url to this team
    /// </summary>
    [JsonProperty("identityUrl")]
    public string IdentityUrl { get; set; } = string.Empty;

    [JsonProperty("projectName")]
    public string ProjectName { get; set; } = string.Empty;
    
    [JsonProperty("projectId")]
    public string ProjectId { get; set; } = string.Empty;

    /// <summary>
    /// Team identity.
    /// </summary>
    [JsonProperty("identity")]
    public Identity? Identity { get; set; }

    [JsonProperty("members")]
    public List<TeamMember>? Members { get; set; }
}