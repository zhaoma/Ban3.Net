using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// Represents a template from which new build definitions can be created.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/templates/get?view=azure-devops-rest-7.0#builddefinitiontemplate
/// </summary>
public class BuildDefinitionTemplate
{
    /// <summary>
    /// Indicates whether the template can be deleted.
    /// </summary>
    [JsonProperty("canDelete")]
    public bool CanDelete { get; set; }

    /// <summary>
    /// The template category.
    /// </summary>
    [JsonProperty("category")]
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// An optional hosted agent queue for the template to use by default.
    /// </summary>
    [JsonProperty("defaultHostedQueue")]
    public string DefaultHostedQueue { get; set; } = string.Empty;

    /// <summary>
    /// A description of the template.
    /// </summary>
    [JsonProperty("description")]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// The ID of the task whose icon is used when showing this template in the UI.
    /// </summary>
    [JsonProperty("iconTaskId")]
    public string IconTaskId { get; set; } = string.Empty;

    [JsonProperty("icons")]
    public object? Icons { get; set; }

    /// <summary>
    /// The ID of the template.
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// The name of the template.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The actual template.
    /// </summary>
    [JsonProperty("template")]
    public BuildDefinition? Template { get; set; } 
}