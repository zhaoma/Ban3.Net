using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;
using System;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using System.Text;
using Ban3.Infrastructures.Common.Extensions;

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

        public QueryDeletedOption? DeletedFilter { get; set; } 

        public int? MaxBuildsPerDefinition { get; set; } 

        public string MaxTime { get; set; } = string.Empty;

        public string MinTime { get; set; } = string.Empty;

        public string Properties { get; set; } = string.Empty;

        public BuildQueryOrder? QueryOrder { get; set; } 

        public string Queues { get; set; } = string.Empty;

        public BuildReason? ReasonFilter { get; set; } 

        public string RepositoryId { get; set; } = string.Empty;

        public string RepositoryType { get; set; } = string.Empty;

        public string RequestedFor { get; set; } = string.Empty;

        public BuildResult? ResultFilter { get; set; } 

        public BuildStatus? StatusFilter { get; set; } 

        public string TagFilters { get; set; } = string.Empty;


        public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/build/builds";

        public string RequestQuery()
        {
            var sb = new StringBuilder();

            sb.Append("?");
            
            sb.AppendQuery("$top", Top);
            sb.AppendQuery("BranchName", BranchName);
            sb.AppendQuery("BuildIds", BuildIds);
            sb.AppendQuery("BuildNumber", BuildNumber);
            sb.AppendQuery("ContinuationToken", ContinuationToken);
            sb.AppendQuery("Definitions", Definitions);
            sb.AppendQuery("DeletedFilter", DeletedFilter);
            sb.AppendQuery("MaxBuildsPerDefinition", MaxBuildsPerDefinition);
            sb.AppendQuery("MaxTime", MaxTime);
            sb.AppendQuery("MinTime", MinTime);
            sb.AppendQuery("Properties", Properties);
            sb.AppendQuery("QueryOrder", QueryOrder);
            sb.AppendQuery("Queues", Queues);
            sb.AppendQuery("ReasonFilter", ReasonFilter);
            sb.AppendQuery("RepositoryId", RepositoryId);
            sb.AppendQuery("RepositoryType", RepositoryType);
            sb.AppendQuery("RequestedFor", RequestedFor);
            sb.AppendQuery("ResultFilter", ResultFilter);
            sb.AppendQuery("StatusFilter", StatusFilter);
            sb.AppendQuery("TagFilters", TagFilters);

            //sb.Append($"api-version={ApiVersion}");
            return sb.ToString();
        }

        public string RequestBody() => string.Empty;
    }
}

