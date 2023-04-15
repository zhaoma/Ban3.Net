using System;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities
{
    /// <summary>
    /// A collection of logs.
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/pipelines/logs/list?view=azure-devops-rest-7.0#logcollection
    /// </summary>
	public class LogCollection
    {
        /// <summary>
        /// The list of logs.
        /// </summary>
        [JsonProperty("logs")]
        public List<Log> Logs { get; set; }

        /// <summary>
        /// A signed url allowing limited-time anonymous access to private resources.
        /// </summary>
        [JsonProperty("signedContent")]
        public SignedUrl SignedContent { get; set; }

        /// <summary>
        /// URL of the log.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}

