
namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities
{
    /// <summary>
    /// Represents an artifact produced by a build.
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/artifacts/get-artifact?view=azure-devops-server-rest-6.0
    /// </summary>
    public class BuildArtifact
    {
        /// <summary>
        /// The artifact ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the artifact.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The actual resource.
        /// </summary>
        public ArtifactResource Resource { get; set; }

        /// <summary>
        /// The artifact source, which will be the ID of the job that produced this artifact.
        /// If an artifact is associated with multiple sources, this points to the first source.
        /// </summary>
        public string Source { get; set; }
    }
}
