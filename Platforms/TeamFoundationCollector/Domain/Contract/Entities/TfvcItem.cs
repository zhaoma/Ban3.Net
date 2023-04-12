using System.Text.Json.Serialization;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

public class TfvcItem
{
    /// <summary>
    /// The class to represent a collection of REST reference links.
    /// </summary>
    [JsonPropertyName("_links")]
    public ReferenceLinks Links { get; set; }

    public string ChangeDate { get; set; }

    public string Content { get; set; }

    public FileContentMetadata ContentMetadata { get; set; }

    /// <summary>
    /// Greater than 0 if item is deleted.
    /// </summary>
    public int DeletionId { get; set; }

    public int Encoding { get; set; }

    public string HashValue { get; set; }

    public bool IsBranch { get; set; }

    public bool IsFolder { get; set; }

    public bool IsPendingChange { get; set; }

    public bool IsSymLink { get; set; }

    public string Path { get; set; }

    public int Size { get; set; }

    public string Url { get; set; }

    public int Version { get; set; }
}