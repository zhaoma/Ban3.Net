
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities
{
    /// <summary>
    /// Specification of the agent defined by the pool provider.
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/get?view=azure-devops-rest-7.0#agentspecification
    /// </summary>
    public class AgentSpecification
    {
        /// <summary>
        /// Agent specification unique identifier.
        /// </summary>
        [JsonProperty("identifier")]
        public string Identifier { get; set; }
    }
}
