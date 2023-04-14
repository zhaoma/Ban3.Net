using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// Metadata for a shallow shelveset.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/tfvc/shelvesets/list?view=azure-devops-rest-7.0&tabs=HTTP#tfvcshelvesetref
/// </summary>
public class TfvcShelvesetRef
{
    /// <summary>
    /// List of reference links for the shelveset.
    /// </summary>
    [JsonProperty("_links")]
    public ReferenceLinks Links { get; set; }

    /// <summary>
    /// Shelveset comment.
    /// </summary>
    [JsonProperty("comment")]
    public string Comment { get; set; }

    /// <summary>
    /// Shelveset comment truncated as applicable.
    /// </summary>
    [JsonProperty("commentTruncated")]
    public bool CommentTruncated { get; set; }

    /// <summary>
    /// Shelveset create date.
    /// </summary>
    [JsonProperty("createdDate")]
    public string CreatedDate { get; set; }

    /// <summary>
    /// Shelveset Id.
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; }

    /// <summary>
    /// Shelveset name.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// Shelveset Owner.
    /// </summary>
    [JsonProperty("owner")]
    public IdentityRef Owner { get; set; }

    /// <summary>
    /// Shelveset Url.
    /// </summary>
    [JsonProperty("url")]
    public string Url { get; set; }
}