using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Build
{
    /// <summary>
    /// Gets details for a build
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/timeline/get?view=azure-devops-rest-7.0
    /// </summary>
    public class GetTimeline
        : PresetRequest, IRequest
    {
        public string Method { get; set; } = "Get";

        [JsonProperty("buildId")]
        public int BuildId { get; set; }

        [JsonProperty("timelineId")]
        public string TimelineId { get; set; } = string.Empty;
        
        [JsonProperty("changeId")]
        public int? ChangeId { get; set; } 
        
        [JsonProperty("planId")]
        public string PlanId { get; set; } = string.Empty;
        
        public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/build/builds/{BuildId}/timeline/{TimelineId}";

        public string RequestQuery()
        {
            var sb = new StringBuilder();

            sb.Append("?");

            if (ChangeId != null)
                sb.Append($"changeId={ChangeId}&");
            if (!string.IsNullOrEmpty(PlanId))
                sb.Append($"planId={PlanId}&");

            sb.Append($"api-version={ApiVersion}");
            return sb.ToString();
        }

        public string RequestBody() => string.Empty;
    }
}

