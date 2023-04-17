using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Tfvc;

public class GetBatchedChangesetsBody
{
    /// <summary>
    /// List of changeset Ids.
    /// </summary>
    [JsonProperty("changesetIds")]
    public List<int>? ChangesetIds { get; set; }

    /// <summary>
    /// Max length of the comment.
    /// </summary>
    [JsonProperty("commentLength")]
    public int CommentLength { get; set; }

    /// <summary>
    /// Whether to include the _links field on the shallow references
    /// </summary>
    [JsonProperty("includeLinks")]
    public bool IncludeLinks { get; set; }
}