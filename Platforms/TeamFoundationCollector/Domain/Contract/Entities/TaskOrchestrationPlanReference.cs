using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// Represents a reference to an orchestration plan.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/get?view=azure-devops-rest-7.0#taskorchestrationplanreference
/// </summary>
public class TaskOrchestrationPlanReference
{
    /// <summary>
    /// The type of the plan.
    /// </summary>
    [JsonProperty("orchestrationType")]
    public int OrchestrationType { get; set; }

    /// <summary>
    /// The ID of the plan.
    /// </summary>
    [JsonProperty("planId")]
    public string PlanId { get; set; } = string.Empty;
}