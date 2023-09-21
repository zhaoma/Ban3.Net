using System.Collections.Generic;
using Newtonsoft.Json;

using Ban3.Infrastructures.DataPersist.Attributes;
using Ban3.Infrastructures.DataPersist.Entities;

namespace Ban3.Sites.ViaMicrosoft.Entities.TFVC;

/// <summary>
/// 变更集
/// </summary>
[TableIs("Changeset", "Changeset", false)]
public class TfvcChangesetRef
    : BaseEntity
{
    [JsonProperty("changesetId")] public int ChangesetId { get; set; }

    /// <summary>
    /// Alias or display name of user
    /// </summary>
    [JsonProperty("author")]
    public IdentityRef Author { get; set; }

    public string AuthorId { get; set; }

    /// <summary>
    /// Alias or display name of user
    /// </summary>
    [JsonProperty("checkedInBy")]
    public IdentityRef CheckedInBy { get; set; }

    public string CheckedInById { get; set; }

    /// <summary>
    /// Creation date of the changeset.
    /// </summary>
    [JsonProperty("createdDate")]
    public string CreatedDate { get; set; }

    /// <summary>
    /// Comment for the changeset.
    /// </summary>
    [JsonProperty("comment")]
    public string Comment { get; set; }

    /// <summary>
    /// Was the Comment result truncated?
    /// </summary>
    [JsonProperty("commentTruncated")]
    public bool CommentTruncated { get; set; }

    [JsonProperty("threads")] public List<Entities.Discussion.Thread> Threads { get; set; }

    /// <summary>
    /// List of work items associated with the changeset.
    /// </summary>

    [JsonProperty("workItems")]
    public List<AssociatedWorkItem> WorkItems { get; set; }
}