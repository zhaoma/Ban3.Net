using System.Text.Json.Serialization;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities
{
    /// <summary>
    /// Deletion state of a maven package.
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/artifactspackagetypes/maven/get-package-version-from-recycle-bin?view=azure-devops-server-rest-6.0#mavenpackageversiondeletionstate
    /// </summary>
    public class MavenPackageVersionDeletionState
    {
        /// <summary>
        /// Artifact Id of the package.
        /// </summary>
        [JsonPropertyName("artifactId")]
        public string ArtifactId { get; set; }

        /// <summary>
        /// UTC date the package was deleted.
        /// </summary>
        [JsonPropertyName("deletedDate")]
        public string DeletedDate { get; set; }

        /// <summary>
        /// Group Id of the package.
        /// </summary>
        [JsonPropertyName("groupId")]
        public string GroupId { get; set; }

        /// <summary>
        /// Version of the package.
        /// </summary>
        [JsonPropertyName("version")]
        public string Version { get; set; }
    }
}