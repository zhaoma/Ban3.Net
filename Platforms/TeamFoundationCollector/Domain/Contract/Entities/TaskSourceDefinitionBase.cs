using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/templates/get?view=azure-devops-rest-7.0#tasksourcedefinitionbase
/// </summary>
public class TaskSourceDefinitionBase
{
    [JsonProperty("authKey")]
    public string AuthKey { get; set; } = string.Empty;

    [JsonProperty("endpoint")]
    public string Endpoint { get; set; } = string.Empty;

    [JsonProperty("keySelector")]
    public string KeySelector { get; set; } = string.Empty;

    [JsonProperty("selector")]
    public string Selector { get; set; } = string.Empty;

    [JsonProperty("target")]
    public string Target { get; set; } = string.Empty;
}