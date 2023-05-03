using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Build;

/// <summary>
/// Gets a definition, optionally at a specific revision.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/definitions/get?view=azure-devops-rest-7.0
/// </summary>
public class GetDefinition
    : PresetRequest, IRequest
{
    public int DefinitionId { get; set; }

    [JsonProperty("includeLatestBuilds")]
    public bool? IncludeLatestBuilds { get; set; }

    [JsonProperty("minMetricsTime")] 
    public string? MinMetricsTime { get; set; } 

    [JsonProperty("propertyFilters")]
    public string? PropertyFilters { get; set; }

    [JsonProperty("revision")]
    public int? Revision { get; set; }

    public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/build/definitions/{DefinitionId}";
}

