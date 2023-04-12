using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Ban3.Platforms.TeamFoundationCollector.Infrastructrue.Common.Enums;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities
{
    /// <summary>
    /// Upstream source definition, including its Identity, package type, and other associated information.
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/artifactspackagetypes/maven/get-package-version?view=azure-devops-server-rest-6.0#upstreamsourceinfo
    /// </summary>
    public class UpstreamSourceInfo
    {
        /// <summary>
        /// Locator for connecting to the upstream source in a user friendly format, that may potentially change over time
        /// </summary>
        [JsonPropertyName("displayLocation")]
        public string DisplayLocation { get; set; }

        /// <summary>
        /// Identity of the upstream source.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Locator for connecting to the upstream source
        /// </summary>
        [JsonPropertyName("location")]
        public string Location { get; set; }

        /// <summary>
        /// Display name.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Source type, such as Public or Internal.
        /// </summary>
        [JsonPropertyName("sourceType")]
        public PackagingSourceType SourceType { get; set; }
    }
}
