using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// Represents the reference to a specific version of a comment on a Work Item.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/wit/work-items/list?view=azure-devops-rest-7.0&tabs=HTTP#workitemcommentversionref
/// </summary>
public class WorkItemCommentVersionRef
{
    /// <summary>
    /// The id assigned to the comment.
    /// </summary>
    [JsonProperty("commentId")]
    public int CommentId { get; set; }

    /// <summary>
    /// [Internal] The work item revision where this comment was originally added.
    /// </summary>
    [JsonProperty("createdInRevision")]
    public int CreatedInRevision { get; set; }

    /// <summary>
    /// [Internal] Specifies whether comment was deleted.
    /// </summary>
    [JsonProperty("isDeleted")]
    public bool IsDeleted { get; set; }

    /// <summary>
    /// [Internal] The text of the comment.
    /// </summary>
    [JsonProperty("text")]
    public string? Text { get; set; }

    [JsonProperty("url")]
    public string? Url { get; set; }

    /// <summary>
    /// The version number.
    /// </summary>
    [JsonProperty("version")]
    public int Version { get; set; }
}