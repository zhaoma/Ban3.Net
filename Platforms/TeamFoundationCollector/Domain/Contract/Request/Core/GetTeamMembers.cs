using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Core
{
    /// <summary>
    /// Get a list of members for a specific team.
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/core/teams/get-team-members-with-extended-properties?view=azure-devops-rest-7.0
    /// </summary>
    public class GetTeamMembers
        : PresetRequest, IRequest
    {
        public string Method { get; set; } = "Get";

        /// <summary>
        /// The name or ID (GUID) of the team project the team belongs to.
        /// </summary>
        [JsonProperty("projectId")]
        public string ProjectId { get; set; } = string.Empty;

        /// <summary>
        /// The name or ID (GUID) of the team .
        /// </summary>
        [JsonProperty("teamId")]
        public string TeamId { get; set; } = string.Empty;

        [JsonProperty("skip")]
        public int? Skip { get; set; }

        [JsonProperty("top")]
        public int? Top { get; set; }

        public string RequestPath() => $"{Instance}/{Organization}/_apis/projects/{ProjectId}/teams/{TeamId}/members";

        public string RequestQuery()
        {
            var sb = new StringBuilder();

            sb.Append("?");

            if (Skip != null)
                sb.Append($"$skip={Skip}&");
            if (Top != null)
                sb.Append($"$top={Top}&");
            
            //sb.Append($"api-version={ApiVersion}");
            return sb.ToString();
        }

        public string RequestBody() => string.Empty;
    }
}

