using Dapper.Contrib.Extensions;

using Newtonsoft.Json;
using System;
using Ban3.Infrastructures.Common.Contracts.Attributes;
using Ban3.Infrastructures.Common.Contracts.Entities;

namespace Ban3.Sites.ViaMicrosoft.Entities.Discussion
{
    [Table( "Comment" )]
    [TableStrategy( "Comment", "Comment", false )]
    public class Comment
            : _BaseEntity
    {
        public Comment()
        {
            Id = Guid.NewGuid().ToString("N");
        }

        [ExplicitKey]
        public string Id{ get; set; }

        [JsonProperty( "id" )]
        public int CommentId { get; set; }

        [JsonProperty( "threadId" )]
        public int ThreadId { get; set; }

        [JsonProperty( "author" )]
        [Write(false)]
        public IdentityRef Author { get; set; }

        public string AuthorId => Author?.Id;

        [JsonProperty( "content" )]
        public string Content { get; set; }

        [JsonProperty( "publishedDate" )]
        public string PublishedDate { get; set; }

        [JsonProperty( "lastUpdatedDate" )]
        public string LastUpdatedDate { get; set; }

        [JsonProperty( "lastContentUpdatedDate" )]
        public string LastContentUpdatedDate { get; set; }

        [JsonProperty( "commentType" )]
        public string CommentType { get; set; }

        public override string KeyValue() => $"{ThreadId}:{CommentId}";

        public override string EqualCondition()
        {
            return $"{ThreadId}:{CommentId}:{Content}";
        }
    }
}