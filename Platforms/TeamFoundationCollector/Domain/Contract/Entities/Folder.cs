using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// Represents a folder that contains build definitions.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/folders/list?view=azure-devops-rest-7.0#folder
/// </summary>
public class Folder
{
    /// <summary>
    /// The process or person who created the folder.
    /// </summary>
    [JsonProperty("createdBy")]
    public IdentityRef? CreateBy { get; set; }

    /// <summary>
    /// The date the folder was created.
    /// </summary>
    [JsonProperty("createdOn")]
    public string CreatedOn { get; set; } = string.Empty;

    /// <summary>
    /// The description.
    /// </summary>
    [JsonProperty("description")]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// The process or person that last changed the folder.
    /// </summary>
    [JsonProperty("lastChangedBy")]
    public IdentityRef? LastChangedBy { get; set; }

    /// <summary>
    /// The date the folder was last changed.
    /// </summary>
    [JsonProperty("lastChangedDate")]
    public string LastChangedDate { get; set; } = string.Empty;

    /// <summary>
    /// The full path.
    /// </summary>
    [JsonProperty("path")]
    public string Path { get; set; } = string.Empty;

    /// <summary>
    /// The project.
    /// </summary>
    [JsonProperty("project")]
    public TeamProjectReference? Project{ get; set; }
}