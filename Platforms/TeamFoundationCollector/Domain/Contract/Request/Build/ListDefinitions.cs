using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;
using System.Text;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Build;

/// <summary>
/// Gets a list of definitions.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/definitions/list?view=azure-devops-rest-7.0
/// </summary>
public class ListDefinitions
    : PresetRequest, IRequest
{
    [JsonProperty("$top")] public int? Top { get; set; }
    
    [JsonProperty("builtAfter")] public string? BuiltAfter { get; set; } 

    [JsonProperty("continuationToken")] public string? ContinuationToken { get; set; } 

    [JsonProperty("definitionIds")] public string? DefinitionIds { get; set; } 

    [JsonProperty("includeAllProperties")] public bool? IncludeAllProperties { get; set; }

    [JsonProperty("includeLatestBuilds")] public bool? IncludeLatestBuilds { get; set; }

    [JsonProperty("minMetricsTime")] public string? MinMetricsTime { get; set; } 

    [JsonProperty("name")] public string? Name { get; set; } 

    [JsonProperty("notBuiltAfter")] public string? NotBuiltAfter { get; set; } 

    [JsonProperty("path")] public string? Path { get; set; } 

    [JsonProperty("processType")] public int? ProcessType { get; set; }

    [JsonProperty("queryOrder")] public DefinitionQueryOrder? QueryOrder { get; set; }

    [JsonProperty("repositoryId")] public string? RepositoryId { get; set; } 

    [JsonProperty("repositoryType")] public string? RepositoryType { get; set; } 

    [JsonProperty("taskIdFilter")] public string? TaskIdFilter { get; set; } 

    [JsonProperty("uuid")] public string? Uuid { get; set; } 

    [JsonProperty("yamlFilename")] public string? YamlFilename { get; set; } 

    public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/build/definitions";
}

