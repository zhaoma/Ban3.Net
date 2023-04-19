﻿using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Build;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Core
{
    /// <summary>
    /// Create a team in a team project.
    /// Possible failure scenarios
    /// Invalid project name/ID (project doesn't exist)     404
    /// Invalid team name or description                                    400
    /// Team already exists                                                                  400
    /// Insufficient privileges                                                             400
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/core/teams/create?view=azure-devops-rest-7.0&tabs=HTTP
    /// </summary>
    public class CreateTeam
        : PresetRequest, IRequest
    {
        public string Method { get; set; } = "Post";

        /// <summary>
        /// The name or ID (GUID) of the team project in which to create the team.
        /// </summary>
        [JsonProperty("projectId")]
        public string ProjectId { get; set; } = string.Empty;

        public CreateTeamBody? Body { get; set; }

        public string RequestPath() => $"{Instance}/{Organization}/_apis/projects/{ProjectId}/teams";

        public string RequestQuery() => $"?api-version={ApiVersion}";
        
        public string RequestBody() => JsonConvert.SerializeObject(Body);
    }
}

