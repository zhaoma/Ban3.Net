using System.Collections.Generic;

using Dapper.Contrib.Extensions;

using Newtonsoft.Json;

using Ban3.Infrastructures.Common.Contracts.Attributes;
using Ban3.Infrastructures.Common.Contracts.Entities;
using Ban3.Infrastructures.Common.Extensions;

namespace Ban3.Sites.ViaMicrosoft.Entities.TFVC
{
    /// <summary>
    /// 搁置集
    /// </summary>
    [Table( "Shelveset" )]
    [TableStrategy( "Shelveset", "Shelveset", false )]
    public class TfvcShelvesetRef
            : _BaseEntity
    {
        public TfvcShelvesetRef() {}

        [ExplicitKey]
        public string Id { get; set; }

        [JsonProperty( "id" )]
        public string ShelvesetId { get; set; }

        [JsonProperty( "name" )]
        public string Name { get; set; }

        [JsonProperty( "owner" )]
        [Write(false)]
        public Entities.IdentityRef Owner { get; set; }

        public string OwnerId { get; set; }

        [JsonProperty( "comment" )]
        public string Comment { get; set; }

        [JsonProperty( "createdDate" )]
        public string CreatedDate { get; set; }

        [JsonProperty( "commentTruncated" )]
        public bool CommentTruncated { get; set; }

        [JsonProperty( "url" )]
        public string Url { get; set; }

        [JsonProperty( "threads" )]
        [Write(false)]
        public List<Entities.Discussion.Thread> Threads { get; set; }

        [JsonProperty( "workItems" )]
        [Write(false)]
        public List<AssociatedWorkItem> WorkItems { get; set; }

        public override string KeyValue() => Id;

        public override string EqualCondition()
        {
            return $"{Comment}.{Threads.ObjToJson()}.{WorkItems.ObjToJson()}";
        }
    }
}