using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Core;

/// <summary>
/// Get a list of members for a specific team.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/core/teams/get-team-members-with-extended-properties?view=azure-devops-rest-7.0
/// </summary>
public class GetTeamMembers
    : PresetRequest, IRequest
{
    /// <summary>
    /// The name or ID (GUID) of the team project the team belongs to.
    /// </summary>
    public string ProjectId { get; set; } = string.Empty;

    /// <summary>
    /// The name or ID (GUID) of the team .
    /// </summary>
    public string TeamId { get; set; } = string.Empty;

    [JsonProperty("$skip")]
    public int? Skip { get; set; }

    [JsonProperty("$top")]
    public int? Top { get; set; }

    public string RequestPath() => $"{Instance}/{Organization}/_apis/projects/{ProjectId}/teams/{TeamId}/members";
}

