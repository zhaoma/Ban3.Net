using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/pipelines/runs/get?view=azure-devops-rest-7.0#runresources
/// </summary>
public class RunResources
{
    [JsonProperty("repositories")] public Dictionary<string, RepositoryResource>? Repositories { get; set; }
}

