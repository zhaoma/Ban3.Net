using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/artifacts/get-artifact?view=azure-devops-server-rest-6.0
    /// </summary>
    public class ArtifactResource
    {
        /// <summary>
        /// The class to represent a collection of REST reference links.
        /// </summary>
        [JsonPropertyName("_links")]
        public ReferenceLinks Links { get; set; }

        /// <summary>
        /// Type-specific data about the artifact.
        /// </summary>
        [JsonPropertyName("data")]
        public string Data { get; set; }

        /// <summary>
        /// A link to download the resource.
        /// </summary>
        [JsonPropertyName("downloadUrl")]
        public string DownloadUrl { get; set; }

        /// <summary>
        /// Type-specific properties of the artifact.
        /// </summary>
        [JsonPropertyName("properties")]
        public object Properties { get; set; }

        /// <summary>
        /// The type of the resource: File container, version control folder, UNC path, etc.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// The full http link to the resource.
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
