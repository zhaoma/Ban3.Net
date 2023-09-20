using Newtonsoft.Json;
using System;
using Ban3.Infrastructures.DataPersist.Attributes;
using Ban3.Infrastructures.DataPersist.Entities;

namespace Ban3.Sites.ViaMicrosoft.Entities.Discussion;

[TableIs("Comment", "Comment", false)]
public class Comment
    : BaseEntity
{
    public Comment()
    {
        Id = Guid.NewGuid().ToString("N");
    }

    public string Id { get; set; }

    [JsonProperty("id")] public int CommentId { get; set; }

    [JsonProperty("threadId")] public int ThreadId { get; set; }

    [JsonProperty("author")] public IdentityRef Author { get; set; }

    public string AuthorId => Author?.Id;

    [JsonProperty("content")] public string Content { get; set; }

    [JsonProperty("publishedDate")] public string PublishedDate { get; set; }

    [JsonProperty("lastUpdatedDate")] public string LastUpdatedDate { get; set; }

    [JsonProperty("lastContentUpdatedDate")]
    public string LastContentUpdatedDate { get; set; }

    [JsonProperty("commentType")] public string CommentType { get; set; }
}