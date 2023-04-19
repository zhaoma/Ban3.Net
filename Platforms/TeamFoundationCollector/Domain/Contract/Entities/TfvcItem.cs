using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// Metadata for an item.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/tfvc/items/list?view=azure-devops-rest-7.0#tfvcitem
/// </summary>
public class TfvcItem
{
    /// <summary>
    /// The class to represent a collection of REST reference links.
    /// </summary>
    [JsonProperty("_links")]
    public ReferenceLinks? Links { get; set; }

    /// <summary>
    /// Item changed datetime.
    /// </summary>
    [JsonProperty("changeDate")]
    public string ChangeDate { get; set; } = string.Empty;

    [JsonProperty("content")]
    public string Content { get; set; } = string.Empty;

    [JsonProperty("contentMetadata")]
    public FileContentMetadata? ContentMetadata { get; set; }

    /// <summary>
    /// Greater than 0 if item is deleted.
    /// </summary>
    [JsonProperty("deletionId")]
    public int DeletionId { get; set; }

    [JsonProperty("encoding")]
    public int Encoding { get; set; }

    /// <summary>
    /// MD5 hash as a base 64 string, applies to files only.
    /// </summary>
    [JsonProperty("hashValue")]
    public string HashValue { get; set; } = string.Empty;

    /// <summary>
    /// True if item is a branch.
    /// </summary>
    [JsonProperty("isBranch")]
    public bool IsBranch { get; set; }

    [JsonProperty("isFolder")]
    public bool IsFolder { get; set; }

    /// <summary>
    /// True if there is a change pending.
    /// </summary>
    [JsonProperty("isPendingChange")]
    public bool IsPendingChange { get; set; }

    [JsonProperty("isSymLink")]
    public bool IsSymLink { get; set; }

    [JsonProperty("path")]
    public string Path { get; set; } = string.Empty;

    /// <summary>
    /// The size of the file, if applicable.
    /// </summary>
    [JsonProperty("size")]
    public int Size { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("url")]
    public string Url { get; set; } = string.Empty;

    /// <summary>
    /// Changeset version Id.
    /// </summary>
    [JsonProperty("version")]
    public int Version { get; set; }
}