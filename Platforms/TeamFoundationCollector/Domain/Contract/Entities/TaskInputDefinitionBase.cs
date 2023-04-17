using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/templates/get?view=azure-devops-rest-7.0#taskinputdefinitionbase
/// </summary>
public class TaskInputDefinitionBase
{
    [JsonProperty("aliases")]
    public List<string>? Aliases { get; set; }

    [JsonProperty("defaultValue")]
    public string DefaultValue { get; set; } = string.Empty;

    [JsonProperty("groupName")]
    public string GroupName { get; set; } = string.Empty;

    [JsonProperty("helpMarkDown")]
    public string HelpMarkDown { get; set; } = string.Empty;

    [JsonProperty("label")]
    public string Label { get; set; } = string.Empty;

    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    [JsonProperty("options")]
    public object? Options { get; set; } 

    [JsonProperty("properties")]
    public object? Properties { get; set; } 

    [JsonProperty("required")]
    public bool Required { get; set; } 

    [JsonProperty("type")]
    public string Type { get; set; } = string.Empty;

    [JsonProperty("validation")]
    public TaskInputValidation? Validation { get; set; } 

    [JsonProperty("visibleRule")]
    public string VisibleRule { get; set; } = string.Empty;
}