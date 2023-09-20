using System.Collections.Generic;
using System.Threading;

using Dapper.Contrib.Extensions;

using Newtonsoft.Json;

using Ban3.Sites.ViaMicrosoft.Entities.Discussion;
using Ban3.Infrastructures.Common.Contracts.Attributes;
using Ban3.Infrastructures.Common.Contracts.Entities;
using Ban3.Infrastructures.Common.Extensions;

namespace Ban3.Sites.ViaMicrosoft.Entities.TFVC
{
    /// <summary>
    /// 变更集
    /// </summary>
    [Table( "Changeset" )]
    [TableStrategy( "Changeset", "Changeset", false )]
    public class TfvcChangesetRef
            : _BaseEntity
    {
        [JsonProperty( "changesetId" )]
        [Write(false)]
        public int ChangesetId { get; set; }

        /// <summary>
        /// Alias or display name of user
        /// </summary>
        [JsonProperty( "author" )]
        [Write(false)]
        public IdentityRef Author { get; set; }

        public string AuthorId { get; set; }

        /// <summary>
        /// Alias or display name of user
        /// </summary>
        [JsonProperty( "checkedInBy" )]
        [Write(false)]
        public IdentityRef CheckedInBy { get; set; }

        public string CheckedInById { get; set; }

        /// <summary>
        /// Creation date of the changeset.
        /// </summary>
        [JsonProperty( "createdDate" )]
        public string CreatedDate { get; set; }

        /// <summary>
        /// Comment for the changeset.
        /// </summary>
        [JsonProperty( "comment" )]
        public string Comment { get; set; }

        /// <summary>
        /// Was the Comment result truncated?
        /// </summary>
        [JsonProperty( "commentTruncated" )]
        public bool CommentTruncated { get; set; }

        [JsonProperty( "threads" )]
        [Write(false)]
        public List<Entities.Discussion.Thread> Threads { get; set; }

        /// <summary>
        /// List of work items associated with the changeset.
        /// </summary>
        [Write(false)]
        [JsonProperty( "workItems" )]
        public List<AssociatedWorkItem> WorkItems { get; set; }

        public override string KeyValue() => Id;

        public override string EqualCondition()
        {
            return $"{Comment}.{Threads.ObjToJson()}.{WorkItems.ObjToJson()}";
        }
    }
}