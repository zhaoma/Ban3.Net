using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Build
{
    /// <summary>
    /// Updates an existing build definition.
    /// In order for this operation to succeed, the value of the "Revision" property of the request body must match the existing build definition's.
    /// It is recommended that you obtain the existing build definition by using GET, modify the build definition as necessary, and then submit the modified definition with PUT.
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/definitions/update?view=azure-devops-rest-7.0
    /// </summary>
    public class UpdateDefinition
        : PresetRequest, IRequest
    {
        public UpdateDefinition() { Method = "Put"; }
	 
        [JsonProperty("definitionId")]
        public int DefinitionId { get; set; }
        
        [JsonProperty("secretsSourceDefinitionId")]
        public int? SecretsSourceDefinitionId { get; set; }
        
        [JsonProperty("secretsSourceDefinitionRevision")]
        public int? SecretsSourceDefinitionRevision { get; set; }

        public UpdateDefinitionBody? Body { get; set; }

        public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/build/definitions";
        public string RequestQuery()
        {
            var sb = new StringBuilder();

            sb.Append("?");

            if (SecretsSourceDefinitionId != null)
                sb.Append($"secretsSourceDefinitionId={SecretsSourceDefinitionId}&");
            if (SecretsSourceDefinitionRevision != null)
                sb.Append($"secretsSourceDefinitionRevision={SecretsSourceDefinitionRevision}&");

            sb.Append($"api-version={ApiVersion}");
            return sb.ToString();
        }

        public override string RequestBody() => JsonConvert.SerializeObject(Body);
    }
}

