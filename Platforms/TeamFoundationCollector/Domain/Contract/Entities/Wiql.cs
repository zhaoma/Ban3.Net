using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// A WIQL query
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/wit/wiql/query-by-wiql?view=azure-devops-server-rest-6.0&tabs=HTTP#wiql
/// </summary>
public class Wiql
{
    /// <summary>
    /// The text of the WIQL query
    /// </summary>
    [JsonProperty("query")]
    public string Query { get; set; } = string.Empty;
}