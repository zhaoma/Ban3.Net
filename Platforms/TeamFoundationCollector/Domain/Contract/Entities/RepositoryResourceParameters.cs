using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/pipelines/runs/run-pipeline?view=azure-devops-rest-7.0#repositoryresourceparameters
/// </summary>
public class RepositoryResourceParameters
{
    [JsonProperty("refName")]
    public string RefName { get; set; } = string.Empty;

    /// <summary>
    /// This is the security token to use when connecting to the repository.
    /// </summary>
    [JsonProperty("token")]
    public string Token { get; set; } = string.Empty;

    /// <summary>
    /// Optional.
    /// This is the type of the token given. If not provided, a type of "Bearer" is assumed. Note: Use "Basic" for a PAT token.
    /// </summary>
    [JsonProperty("tokenType")]
    public string TokenType { get; set; } = string.Empty;


    [JsonProperty("version")]
    public string Version { get; set; } = string.Empty;
}