using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Core
{
    /// <summary>
    /// Update a team's name and/or description.
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/core/teams/update?view=azure-devops-rest-7.0
    /// </summary>
    public class UpdateTeam
        : PresetRequest, IRequest
    {
        public UpdateTeam() { Method = "Patch"; }
        
        public string ProjectId { get; set; } = string.Empty;

        public string TeamId { get; set; } = string.Empty;

        public UpdateTeamBody? Body { get; set; }

        public string RequestPath() => $"{Instance}/{Organization}/_apis/projects/{ProjectId}/teams/{TeamId}";

        public string RequestQuery() => $"?api-version={ApiVersion}";

        public override string RequestBody() => JsonConvert.SerializeObject(Body);
    }
}

