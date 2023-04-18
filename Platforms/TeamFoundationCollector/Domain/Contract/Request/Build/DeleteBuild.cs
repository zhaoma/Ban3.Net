using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.SubCondition;
using Newtonsoft.Json;
using System;
using System.Text;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Build
{
    /// <summary>
    /// Deletes a build.
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/delete?view=azure-devops-rest-7.0
    /// </summary>
    public class DeleteBuild
        : PresetRequest, IRequest
    {
        public string Method { get; set; } = "Delete";
        
        /// <summary>
        /// The ID of the build.
        /// </summary>
        [JsonProperty("buildId")]
        public int BuildId { get; set; }
        
        public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/build/builds/{BuildId}";

        public string RequestQuery() => $"?api-version={ApiVersion}";

        public string RequestBody() => string.Empty;
    }
}

