using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities
{
    /// <summary>
    /// Represents a reference to an agent pool.
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/get?view=azure-devops-rest-7.0#taskagentpoolreference
    /// </summary>
    public class TaskAgentPoolReference
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("isHosted")]
        public bool IsHosted { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
