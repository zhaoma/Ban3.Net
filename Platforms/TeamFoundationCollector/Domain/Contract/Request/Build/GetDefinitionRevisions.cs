using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Build
{
    /// <summary>
    /// Gets all revisions of a definition.
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/definitions/get-definition-revisions?view=azure-devops-rest-7.0
    /// </summary>
    public class GetDefinitionRevisions
        : PresetRequest, IRequest
    {

        public string Method { get; set; } = "Get";

        [JsonProperty("definitionId")]
        public int DefinitionId { get; set; }

        public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/build/definitions/{DefinitionId}/revisions";

        public string RequestQuery() => $"?api-version={ApiVersion}";

        public string RequestBody() => string.Empty;
    }
}

