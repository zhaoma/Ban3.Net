using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;
using System;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using System.Text;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Build
{
    /// <summary>
    /// Gets a list of builds.
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/list?view=azure-devops-rest-7.0
    /// </summary>
    public class ListBuilds
        : PresetRequest, IRequest
    {
        public string Method { get; set; } = "Get";

        /// <summary>
        /// The maximum number of changes to return.
        /// </summary>
        [JsonProperty("top")]
        public int? Top { get; set; }

        public string BranchName { get; set; } = string.Empty;

        public string BuildIds { get; set; } = string.Empty;

        public string BuildNumber { get; set; } = string.Empty;

        public string ContinuationToken { get; set; } = string.Empty;

        public string Definitions { get; set; } = string.Empty;

        public QueryDeletedOption DeletedFilter { get; set; } 

        public int MaxBuildsPerDefinition { get; set; } 

        public string MaxTime { get; set; } = string.Empty;

        public string MinTime { get; set; } = string.Empty;

        public string Properties { get; set; } = string.Empty;

        public BuildQueryOrder QueryOrder { get; set; } 

        public string Queues { get; set; } = string.Empty;

        public BuildReason ReasonFilter { get; set; } 

        public string RepositoryId { get; set; } = string.Empty;

        public string RepositoryType { get; set; } = string.Empty;

        public string RequestedFor { get; set; } = string.Empty;

        public BuildResult ResultFilter { get; set; } 

        public BuildStatus StatusFilter { get; set; } 

        public string TagFilters { get; set; } = string.Empty;


        public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/build/builds";

        public string RequestQuery()
        {
            /*TODO :  need check*/
            var sb = new StringBuilder();

            sb.Append("?");
            
            if (Top != null)
                sb.Append($"$top={Top}&");

            sb.Append($"api-version={ApiVersion}");
            return sb.ToString();
        }

        public string RequestBody() => string.Empty;
    }
}

