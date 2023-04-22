using System;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities
{
    public class DiscussionComment
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("threadId")]
        public int ThreadId { get; set; }

        [JsonProperty("author")]
        public IdentityRef? Author { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; } = string.Empty;

        [JsonProperty("publishedDate")]
        public string PublishedDate { get; set; } = string.Empty;

        [JsonProperty("lastUpdatedDate")]
        public string LastUpdatedDate { get; set; } = string.Empty;

        [JsonProperty("lastContentUpdatedDate")]
        public string LastContentUpdatedDate { get; set; } = string.Empty;

        [JsonProperty("commentType")]
        public string CommentType { get; set; } = string.Empty;

    }
}

