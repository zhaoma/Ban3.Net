using System.Text;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Build;

/// <summary>
/// Creates a new definition.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/definitions/create?view=azure-devops-rest-7.0
/// </summary>
public class CreateDefinition
    : PresetRequest, IRequest
{
    public string Method { get; set; } = "Post";
        
    [JsonProperty("definitionToCloneId")] 
    public int? DefinitionToCloneId { get; set; }

    [JsonProperty("definitionToCloneRevision")]
    public int? DefinitionToCloneRevision { get; set; }

    public CreateDefinitionBody? Body { get; set; }

    public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/build/definitions";

    public string RequestQuery()
    {
        var sb = new StringBuilder();

        sb.Append("?");

        if (DefinitionToCloneId != null)
            sb.Append($"definitionToCloneId={DefinitionToCloneId}&");
        if (DefinitionToCloneRevision != null)
            sb.Append($"definitionToCloneRevision={DefinitionToCloneRevision}&");

        sb.Append($"api-version={ApiVersion}");
        return sb.ToString();
    }

    public string RequestBody() => JsonConvert.SerializeObject(Body);

}