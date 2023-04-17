using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities
{
    /// <summary>
    /// Artifacts are collections of files produced by a pipeline. 
    /// Use artifacts to share files between stages in a pipeline or between different pipelines.
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/pipelines/artifacts/get?view=azure-devops-rest-7.0#artifact
    /// </summary>
	public class Artifact
    {
        /// <summary>
        /// The name of the artifact.
        /// </summary>
        [JsonProperty("name")]
        public string Name{ get; set; } = string.Empty;

        /// <summary>
        /// Signed url for downloading this artifact
        /// </summary>
        [JsonProperty("signedContent")]
        public SignedUrl? SignedContent { get; set; }

        /// <summary>
        /// Self-referential url
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; } = string.Empty;
    }
}

