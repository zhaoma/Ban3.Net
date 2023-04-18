using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Build
{
    /// <summary>
    /// Deletes a definition and all associated builds.
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/definitions/delete?view=azure-devops-rest-7.0
    /// </summary>
	public class DeleteDefinition
        : PresetRequest, IRequest
    {
        public string Method { get; set; } = "Delete";
        
        /// <summary>
        /// The ID of the definition.
        /// </summary>
        [JsonProperty("definitionId")]
        public int DefinitionId { get; set; }

        public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/build/definitions/{DefinitionId}";

        public string RequestQuery() => $"?api-version={ApiVersion}";

        public string RequestBody() => string.Empty;
    }
}

