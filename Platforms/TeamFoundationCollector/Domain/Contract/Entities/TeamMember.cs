using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/core/teams/get-team-members-with-extended-properties?view=azure-devops-rest-7.0#teammember
/// </summary>
public class TeamMember
{
    [JsonProperty("identity")]
    public IdentityRef? Identity { get; set; }

    [JsonProperty("isTeamAdmin")]
    public bool IsTeamAdmin { get; set; }
}