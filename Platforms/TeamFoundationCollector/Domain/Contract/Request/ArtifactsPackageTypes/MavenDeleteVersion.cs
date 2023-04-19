using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.ArtifactsPackageTypes
{
    public class MavenDeleteVersion
        : PresetRequest, IRequest
    {
        public string Method { get; set; } = "Delete";
        
        [JsonProperty("artifactId")] 
        public string ArtifactId { get; set; } = string.Empty;

        /// <summary>
        /// Name or ID of the feed.
        /// </summary>
        [JsonProperty("feed")]
        public string Feed { get; set; } = string.Empty;

        /// <summary>
        /// Group ID of the package.
        /// </summary>
        [JsonProperty("groupId")]
        public string GroupId { get; set; } = string.Empty;

        /// <summary>
        /// Version of the package.
        /// </summary>
        [JsonProperty("version")]
        public string Version { get; set; } = string.Empty;

        public string RequestPath() => $"{Instance}/{Organization}/_apis/packaging/feeds/{Feed}/maven/groups/{GroupId}/artifacts/{ArtifactId}/versions/{Version}";

        public string RequestQuery()=> $"?api-version={ApiVersion}";

        public string RequestBody() => string.Empty;
    }
}
