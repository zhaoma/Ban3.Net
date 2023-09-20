using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ban3.Sites.ViaMicrosoft.Response.WIQL
{
    public class WorkItemQueryResult
    {
        /// <summary>
        /// The type of the query
        /// </summary>
        [JsonProperty("queryType")]
        public string QueryType { get; set; }

        /// <summary>
        /// The result type
        /// </summary>
        [JsonProperty("queryResultType")]
        public string QueryResultType { get; set; }

        /// <summary>
        /// The date the query was run in the context of.
        /// </summary>
        [JsonProperty("asOf")]
        public string AsOf { get; set; }

        /// <summary>
        /// The columns of the query.
        /// </summary>
        [JsonProperty("columns")]
        public List<Entities.WIQL.WorkItemFieldReference> Columns { get; set; }

        /// <summary>
        /// The work items returned by the query.
        /// </summary>
        [JsonProperty("workItems")]
        public List<Entities.WIQL.WorkItemReference> WorkItems { get; set; }
    }
}
