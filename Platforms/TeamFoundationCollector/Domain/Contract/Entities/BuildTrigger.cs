using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// Represents a trigger for a buld definition.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/templates/get?view=azure-devops-rest-7.0#buildtrigger
/// </summary>
public class BuildTrigger
{
    [JsonProperty("triggerType")]
    public DefinitionTriggerType TriggerType { get; set; }
}