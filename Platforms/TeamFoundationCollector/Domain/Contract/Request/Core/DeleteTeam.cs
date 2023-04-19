using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Core
{
    /// <summary>
    /// Delete a team.
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/core/teams/delete?view=azure-devops-rest-7.0
    /// </summary>
    public class DeleteTeam
        : PresetRequest, IRequest
    {
        public string Method { get; set; } = "Delete";

        [JsonProperty("projectId")]
        public string ProjectId { get; set; } = string.Empty;
        
        [JsonProperty("teamId")]
        public string TeamId { get; set; } = string.Empty;
        
        public string RequestPath() => $"{Instance}/{Organization}/_apis/projects/{ProjectId}/teams/{TeamId}";

        public string RequestQuery() => $"?api-version={ApiVersion}";

        public string RequestBody() => string.Empty;
    }
}

