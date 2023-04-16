using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// Metadata for a Label.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/tfvc/labels/list?view=azure-devops-rest-7.0&tabs=HTTP#tfvclabelref
/// </summary>
public class TfvcLabelRef
{
    /// <summary>
    /// Collection of reference links.
    /// </summary>
    [JsonProperty("_links")]
    public ReferenceLinks? Links { get; set; }

    /// <summary>
    /// Label description.
    /// </summary>
    [JsonProperty("description")]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Label Id.
    /// </summary>
    [JsonProperty("id")]
    public int Id { get; set; }

    /// <summary>
    /// Label scope.
    /// </summary>
    [JsonProperty("labelScope")]
    public string LabelScope { get; set; } = string.Empty;

    /// <summary>
    /// Last modified datetime for the label.
    /// </summary>
    [JsonProperty("modifiedDate")]
    public string ModifiedDate { get; set; } = string.Empty;

    /// <summary>
    /// Label name.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Label owner.
    /// </summary>
    [JsonProperty("owner")]
    public IdentityRef? Owner { get; set; }

    /// <summary>
    /// Label Url.
    /// </summary>
    [JsonProperty("url")]
    public string Url { get; set; } = string.Empty;
}