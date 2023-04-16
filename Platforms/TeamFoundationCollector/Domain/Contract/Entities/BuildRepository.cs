using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// Represents a repository used by a build definition.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/get?view=azure-devops-rest-7.0#buildrepository
/// </summary>
public class BuildRepository
{
    /// <summary>
    /// Indicates whether to checkout submodules.
    /// </summary>
    [JsonProperty("checkoutSubmodules")]
    public bool CheckoutSubmodules { get; set; }

    /// <summary>
    /// Indicates whether to clean the target folder when getting code from the repository.
    /// </summary>
    [JsonProperty("clean")]
    public string Clean { get; set; } = string.Empty;

    /// <summary>
    /// The name of the default branch.
    /// </summary>
    [JsonProperty("defaultBranch")]
    public string DefaultBranch { get; set; } = string.Empty;

    /// <summary>
    /// The ID of the repository.
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// The friendly name of the repository.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    [JsonProperty("properties")]
    public object? Properties { get; set; }
    
    /// <summary>
    /// The root folder.
    /// </summary>
    [JsonProperty("rootFolder")]
    public string RootFolder { get; set; } = string.Empty;

    /// <summary>
    /// The type of the repository.
    /// </summary>
    [JsonProperty("type")]
    public string Type { get; set; } = string.Empty;

    /// <summary>
    /// The URL of the repository.
    /// </summary>
    [JsonProperty("url")]
    public string Url { get; set; } = string.Empty;
}