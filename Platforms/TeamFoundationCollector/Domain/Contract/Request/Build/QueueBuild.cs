using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;
using System;
using System.Text;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Build
{
    /// <summary>
    /// Queues a build
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/queue?view=azure-devops-rest-7.0
    /// </summary>
    public class QueueBuild
        : PresetRequest, IRequest
    {
        public string Method { get; set; } = "Post";

        [JsonProperty("checkInTicket")] 
        public string CheckInTicket { get; set; } = string.Empty;

        [JsonProperty("definitionId")]
        public int? DefinitionId { get; set; }

        [JsonProperty("ignoreWarnings")]
        public bool? IgnoreWarnings { get; set; }

        [JsonProperty("sourceBuildId")]
        public int? SourceBuildId { get; set; }

        public QueueBuildBody? Body { get; set; }

        public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/build/builds";

        public string RequestQuery()
        {
            var sb = new StringBuilder();

            sb.Append("?");

            if(!string.IsNullOrEmpty(CheckInTicket))
                sb.Append($"checkInTicket={CheckInTicket}&");
            if (DefinitionId != null)
                sb.Append($"definitionId={DefinitionId}&");
            if (IgnoreWarnings != null)
                sb.Append($"ignoreWarnings={IgnoreWarnings}&");
            if (SourceBuildId != null)
                sb.Append($"sourceBuildId={SourceBuildId}&");

            sb.Append($"api-version={ApiVersion}");
            return sb.ToString();
        }

        public string RequestBody() => JsonConvert.SerializeObject(Body);
    }
}

