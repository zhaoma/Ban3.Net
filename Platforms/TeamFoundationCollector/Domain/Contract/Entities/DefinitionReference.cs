using Newtonsoft.Json;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities
{
    /// <summary>
    /// Represents a reference to a definition.
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/get?view=azure-devops-rest-7.0#definitionreference
    /// </summary>
    public class DefinitionReference
    {
        /// <summary>
        /// The date this version of the definition was created.
        /// </summary>
        [JsonProperty("createdDate")]
        public string CreateDate { get; set; }

        /// <summary>
        /// The ID of the referenced definition.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// The name of the referenced definition.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The folder path of the definition.
        /// </summary>
        [JsonProperty("path")]
        public string Path { get; set; }

        /// <summary>
        /// A reference to the project.
        /// </summary>
        [JsonProperty("project")]
        public TeamProjectReference Project { get; set; }

        /// <summary>
        /// A value that indicates whether builds can be queued against this definition.
        /// </summary>
        [JsonProperty("queueStatus")]
        public DefinitionQueueStatus QueueStatus { get; set; }

        /// <summary>
        /// The definition revision number.
        /// </summary>
        [JsonProperty("revision")]
        public int Revision { get; set; }

        /// <summary>
        /// The type of the definition.
        /// </summary>
        [JsonProperty("type")]
        public DefinitionType Type { get; set; }

        /// <summary>
        /// The definition's URI.
        /// </summary>
        [JsonProperty("uri")]
        public string Uri { get; set; }

        /// <summary>
        /// The REST URL of the definition.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
