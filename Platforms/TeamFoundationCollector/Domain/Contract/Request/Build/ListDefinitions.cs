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
    public string Method { get; set; } = "Get";

    [JsonProperty("top")] public int? Top { get; set; }
    
    [JsonProperty("builtAfter")] public string BuiltAfter { get; set; } = string.Empty;

    [JsonProperty("continuationToken")] public string ContinuationToken { get; set; } = string.Empty;

    [JsonProperty("definitionIds")] public string DefinitionIds { get; set; } = string.Empty;

    [JsonProperty("includeAllProperties")] public bool? IncludeAllProperties { get; set; }

    [JsonProperty("includeLatestBuilds")] public bool? IncludeLatestBuilds { get; set; }

    [JsonProperty("minMetricsTime")] public string MinMetricsTime { get; set; } = string.Empty;

    [JsonProperty("name")] public string Name { get; set; } = string.Empty;

    [JsonProperty("notBuiltAfter")] public string NotBuiltAfter { get; set; } = string.Empty;

    [JsonProperty("path")] public string Path { get; set; } = string.Empty;

    [JsonProperty("processType")] public int? ProcessType { get; set; }

    [JsonProperty("queryOrder")] public DefinitionQueryOrder? QueryOrder { get; set; }

    [JsonProperty("repositoryId")] public string RepositoryId { get; set; } = string.Empty;

    [JsonProperty("repositoryType")] public string RepositoryType { get; set; } = string.Empty;

    [JsonProperty("taskIdFilter")] public string TaskIdFilter { get; set; } = string.Empty;

    [JsonProperty("uuid")] public string Uuid { get; set; } = string.Empty;

    [JsonProperty("yamlFilename")] public string YamlFilename { get; set; } = string.Empty;

    public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/build/definitions";

    public string RequestQuery()
    {
        var sb = new StringBuilder();

        sb.Append("?");

        sb.AppendQuery("$top", Top);
        sb.AppendQuery("builtAfter", BuiltAfter);
        sb.AppendQuery("continuationToken", ContinuationToken);
        sb.AppendQuery("definitionIds", DefinitionIds);
        sb.AppendQuery("includeAllProperties", IncludeAllProperties);
        sb.AppendQuery("includeLatestBuilds", IncludeLatestBuilds);
        sb.AppendQuery("minMetricsTime", MinMetricsTime);
        sb.AppendQuery("name", Name);
        sb.AppendQuery("notBuiltAfter", NotBuiltAfter);
        sb.AppendQuery("path", Path);
        sb.AppendQuery("processType", ProcessType);
        sb.AppendQuery("queryOrder", QueryOrder);
        sb.AppendQuery("repositoryId", RepositoryId);
        sb.AppendQuery("repositoryType", RepositoryType);
        sb.AppendQuery("taskIdFilter", TaskIdFilter);
        sb.AppendQuery("uuid", Uuid);
        sb.AppendQuery("yamlFilename", Top);

        //sb.Append($"&api-version={ApiVersion}");
        return sb.ToString();
    }

    public string RequestBody() => string.Empty;
}

