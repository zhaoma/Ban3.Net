
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Newtonsoft.Json;

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
        [JsonProperty("displayLocation")]
        public string DisplayLocation { get; set; } = string.Empty;

        /// <summary>
        /// Identity of the upstream source.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Locator for connecting to the upstream source
        /// </summary>
        [JsonProperty("location")]
        public string Location { get; set; } = string.Empty;

        /// <summary>
        /// Display name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Source type, such as Public or Internal.
        /// </summary>
        [JsonProperty("sourceType")]
        public PackagingSourceType SourceType { get; set; }
    }
}
