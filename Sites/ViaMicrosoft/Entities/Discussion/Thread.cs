using System.Collections.Generic;
using Ban3.Infrastructures.DataPersist.Attributes;
using Ban3.Infrastructures.DataPersist.Entities;
using Newtonsoft.Json;

namespace Ban3.Sites.ViaMicrosoft.Entities.Discussion;

[TableIs("Thread", "Thread", false)]
public class Thread
    : BaseEntity
{
    [JsonProperty("artifactUri")] public string ArtifactUri { get; set; } = string.Empty;

    [JsonProperty("publishedDate")] public string PublishedDate { get; set; } = string.Empty;

    [JsonProperty("lastUpdatedDate")] public string LastUpdatedDate { get; set; } = string.Empty;

    [JsonProperty("comments")] public List<Comment>? Comments { get; set; }

    [JsonProperty("commentsCount")] public int CommentsCount { get; set; }

    [JsonProperty("status")] public string Status { get; set; } = string.Empty;

    [JsonProperty("isDeleted")] public bool IsDeleted { get; set; }
}