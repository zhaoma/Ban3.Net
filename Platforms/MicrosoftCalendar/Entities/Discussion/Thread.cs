using System.Collections.Generic;

using Dapper.Contrib.Extensions;

using Newtonsoft.Json;

using Ban3.Infrastructures.Common.Contracts.Attributes;
using Ban3.Infrastructures.Common.Contracts.Entities;

namespace Ban3.Infrastructures.Platforms.ViaMicrosoft.Entities.Discussion
{
    [Table( "Thread" )]
    [TableStrategy( "Thread", "Thread", false )]
    public class Thread
            : _BaseEntity
    {
        [JsonProperty("artifactUri")]
        public string ArtifactUri { get; set; } = string.Empty;

        [JsonProperty( "publishedDate" )]
        public string PublishedDate { get; set; } = string.Empty;

        [JsonProperty( "lastUpdatedDate" )]
        public string LastUpdatedDate { get; set; } = string.Empty;

        [JsonProperty( "comments" )]
        [Write(false)]
        public List<Comment>? Comments { get; set; }

        [JsonProperty( "commentsCount" )]
        public int CommentsCount { get; set; }

        [JsonProperty( "status" )]
        public string Status { get; set; } = string.Empty;

        [JsonProperty( "isDeleted" )]
        public bool IsDeleted { get; set; }

        public override string KeyValue() => Id;

        public override string EqualCondition()
        {
            return $"{CommentsCount}:{LastUpdatedDate}";
        }
    }
}