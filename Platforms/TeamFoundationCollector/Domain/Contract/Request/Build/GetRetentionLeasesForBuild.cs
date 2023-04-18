using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;
using System;
using System.Text;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Build
{
    /// <summary>
    /// Gets all retention leases that apply to a specific build.
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/get-retention-leases-for-build?view=azure-devops-rest-7.0
    /// </summary>
    public class GetRetentionLeasesForBuild
        : PresetRequest, IRequest
    {
        public string Method { get; set; } = "Get";

        [JsonProperty("buildId")]
        public int BuildId { get; set; }
        
        public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/build/builds/{BuildId}/leases";

        public string RequestQuery() => $"api-version={ApiVersion}";

        public string RequestBody() => string.Empty;
    }
}

