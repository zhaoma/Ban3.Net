
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities
{
    /// <summary>
    /// Represents a queue for running builds.
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/get?view=azure-devops-rest-7.0#agentpoolqueue
    /// </summary>
    public class AgentPoolQueue
    {
        /// <summary>
        /// The class to represent a collection of REST reference links.
        /// </summary>
        [JsonProperty("_links")]
        public ReferenceLinks Links { get; set; }

        /// <summary>
        /// The ID of the queue.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// The name of the queue.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The pool used by this queue.
        /// </summary>
        [JsonProperty("pool")]
        public TaskAgentPoolReference Pool { get; set; }

        /// <summary>
        /// The full http link to the resource.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
