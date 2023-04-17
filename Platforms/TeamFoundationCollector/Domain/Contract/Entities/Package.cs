using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities
{
    /// <summary>
    /// Package version metadata for a Maven package
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/artifactspackagetypes/maven/get-package-version?view=azure-devops-server-rest-6.0
    /// </summary>
    public class Package
    {
        /// <summary>
        /// Related REST links.
        /// </summary>
        [JsonProperty("_links")]
        public ReferenceLinks? Links { get; set; }

        /// <summary>
        /// If and when the package was deleted.
        /// </summary>
        [JsonProperty("deletedDate")]
        public string DeletedDate { get; set; } = string.Empty;

        /// <summary>
        /// Package Id.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// The display name of the package.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// If and when the package was permanently deleted.
        /// </summary>
        [JsonProperty("permanentlyDeletedDate")]
        public string PermanentlyDeletedDate { get; set; } = string.Empty;

        /// <summary>
        /// The history of upstream sources for this package.
        /// The first source in the list is the immediate source from which this package was saved.
        /// </summary>
        [JsonProperty("sourceChain")]
        public List<UpstreamSourceInfo>? SourceChain { get; set; }

        /// <summary>
        /// The version of the package.
        /// </summary>
        [JsonProperty("version")]
        public string Version { get; set; } = string.Empty;
    }
}
