using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Build
{
    /// <summary>
    /// Gets an individual log file for a build.
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/get-build-log?view=azure-devops-rest-7.0
    /// </summary>
    public class GetBuildLog
        : PresetRequest, IRequest
    {
        public string Method { get; set; } = "Get";
        
        /// <summary>
        /// The ID of the build.
        /// </summary>
        [JsonProperty("buildId")]
        public int BuildId { get; set; }

        /// <summary>
        /// The ID of the log file.
        /// </summary>
        [JsonProperty("logId")]
        public int LogId { get; set; }

        [JsonProperty("endLine")]
        public long? EndLine { get; set; }

        [JsonProperty("startLine")]
        public long? StartLine { get; set; }
        
        public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/build/builds/{BuildId}/logs/{LogId}";

        public string RequestQuery()
        {
            var sb = new StringBuilder();

            sb.Append($"?");
            
            if (EndLine != null)
                sb.Append($"endLine={EndLine}&");
            if (StartLine != null)
                sb.Append($"startLine={StartLine}&");

            sb.Append($"api-version={ApiVersion}");
            return sb.ToString();
        }

        public string RequestBody() => string.Empty;
    }
}

