using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Build
{
    /// <summary>
    /// Gets a build
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/get?view=azure-devops-rest-7.0
    /// </summary>
    public class GetBuild
        : PresetRequest, IRequest
    {
        /// <summary>
        /// The ID of the definition.
        /// </summary>
        [JsonProperty("buildId")]
        public int BuildId { get; set; }

        [JsonProperty("propertyFilters")]
        public string PropertyFilters { get; set; } = string.Empty;
        
        public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/build/builds/{BuildId}";

        public string RequestQuery() =>string.IsNullOrEmpty(PropertyFilters)
            ? $"?api-version={ApiVersion}"
            : $"?propertyFilters={PropertyFilters}&api-version={ApiVersion}";

        
    }
}

