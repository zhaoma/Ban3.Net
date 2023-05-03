using System.Text;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Attributes;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
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
    public CreateDefinition()
    {
        Method = "Post";
    }
        
    [JsonProperty("definitionToCloneId")] 
    public int? DefinitionToCloneId { get; set; }

    [JsonProperty("definitionToCloneRevision")]
    public int? DefinitionToCloneRevision { get; set; }

    public CreateDefinitionBody? Body { get; set; }

    public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/build/definitions";

    public override string RequestBody() => JsonConvert.SerializeObject(Body);

}