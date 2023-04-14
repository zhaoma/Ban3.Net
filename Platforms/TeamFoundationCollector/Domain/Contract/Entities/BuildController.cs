using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/get?view=azure-devops-rest-7.0#buildcontroller
    /// </summary>
    public class BuildController
    {
        /// <summary>
        /// The class to represent a collection of REST reference links.
        /// </summary>
        [JsonProperty("_links")]
        public ReferenceLinks Links { get; set; }

        /// <summary>
        /// The date the controller was created.
        /// </summary>
        [JsonProperty("createdDate")]
        public string CreateDate { get; set; }

        /// <summary>
        /// The description of the controller.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Indicates whether the controller is enabled.
        /// </summary>
        [JsonProperty("enabled")]
        private bool Enabled { get; set; }

        /// <summary>
        /// Id of the resource
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Name of the linked resource (definition name, controller name, etc.)
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The status of the controller.
        /// </summary>
        [JsonProperty("status")]
        public ControllerStatus Status { get; set; }

        /// <summary>
        /// The date the controller was last updated.
        /// </summary>
        [JsonProperty("updatedDate")]
        public string UpdatedDate { get; set; }

        /// <summary>
        /// The controller's URI.
        /// </summary>
        [JsonProperty("uri")]
        public string Uri { get; set; }

        /// <summary>
        /// Full http link to the resource
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
