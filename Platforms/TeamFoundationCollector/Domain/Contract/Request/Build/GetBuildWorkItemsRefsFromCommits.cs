using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;
using System;
using System.Text;
using Ban3.Infrastructures.Common.Extensions;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Build
{
    /// <summary>
    /// Gets the work items associated with a build. Only work items in the same project are returned.
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/get-build-work-items-refs?view=azure-devops-rest-7.0
    /// </summary>
    public class GetBuildWorkItemsRefsFromCommits
        : PresetRequest, IRequest
    {
        public string Method { get; set; } = "Post";

        [JsonProperty("buildId")]
        public int BuildId { get; set; }

        [JsonProperty("top")]
        public int? Top { get; set; }

        [JsonProperty("body")]
        public List<string> Body { get; set; }

        public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/build/builds/{BuildId}/workitems";

        public string RequestQuery()
        {
            var sb = new StringBuilder();
            
            if (Top != null)
                sb.Append($"$top={Top}&");

            sb.Append($"api-version={ApiVersion}");
            return sb.ToString();
        }

        public string RequestBody() => Body.ObjToJson();
    }
}

