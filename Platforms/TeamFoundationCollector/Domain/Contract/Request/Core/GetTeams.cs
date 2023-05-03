using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Core;

/// <summary>
/// Get a list of all teams.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/core/teams/get-all-teams?view=azure-devops-rest-7.0
/// </summary>
public class GetTeams
    : PresetRequest, IRequest
{
    public string ProjectId { get; set; } = string.Empty;

    [JsonProperty("$expandIdentity")] 
    public bool? ExpandIdentity { get; set; }

    [JsonProperty("$mine")] 
    public bool? Mine { get; set; }

    [JsonProperty("$skip")] 
    public int? Skip { get; set; }

    [JsonProperty("$top")] 
    public int? Top { get; set; }

    public string RequestPath() =>
        string.IsNullOrEmpty(ProjectId)
            ? $"{Instance}/{Organization}/_apis/teams"
            : $"{Instance}/{Organization}/_apis/projects/{ProjectId}/teams";
}

