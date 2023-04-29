using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Build
{
    /// <summary>
    /// Gets the logs for a build.
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/get-build-logs?view=azure-devops-rest-7.0
    /// </summary>
	public class GetBuildLogs
        : PresetRequest, IRequest
    { 
        /// <summary>
        /// The ID of the build.
        /// </summary>
        public int BuildId { get; set; }
        
        public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/build/builds/{BuildId}/logs";

        public string RequestQuery() => $"?api-version={ApiVersion}";

        
    }
}

