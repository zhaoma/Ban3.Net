using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Core
{
    /// <summary>
    /// Get a specific team.
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/core/teams/get?view=azure-devops-rest-7.0&tabs=HTTP
    /// </summary>
    public class GetTeam
        : PresetRequest, IRequest
    {
        public string Method { get; set; } = "Get";

        /// <summary>
        /// The name or ID (GUID) of the team project containing the team.
        /// </summary>
        [JsonProperty("projectId")]
        public string ProjectId { get; set; } = string.Empty;

        /// <summary>
        /// The name or ID (GUID) of the team.
        /// </summary>
        [JsonProperty("teamId")]
        public string TeamId { get; set; } = string.Empty;

        /// <summary>
        /// A value indicating whether or not to expand Identity information in the result WebApiTeam object.
        /// </summary>
        [JsonProperty("expandIdentity")]
        public bool? ExpandIdentity { get; set; }

        public string RequestPath() => $"{Instance}/{Organization}/_apis/projects/{ProjectId}/teams/{TeamId}";

        public string RequestQuery() =>
            ExpandIdentity != null
                ? $"?$expandIdentity={ExpandIdentity}&api-version={ApiVersion}"
                : $"?api-version={ApiVersion}";

        public string RequestBody() => string.Empty;
    }
}

