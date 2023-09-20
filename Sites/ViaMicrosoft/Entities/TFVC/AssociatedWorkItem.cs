using Dapper.Contrib.Extensions;

using Newtonsoft.Json;

using Ban3.Infrastructures.Common.Contracts.Attributes;
using Ban3.Infrastructures.Common.Contracts.Entities;

namespace Ban3.Sites.ViaMicrosoft.Entities.TFVC
{
    [Table( "AssociatedWorkItem" )]
    [TableStrategy( "AssociatedWorkItem", "AssociatedWorkItem", false )]
    public class AssociatedWorkItem
            : _BaseEntity
    {
        [JsonProperty( "assignedTo" )]
        public string AssignedTo { get; set; }

        [JsonProperty( "state" )]
        public string State { get; set; }

        [JsonProperty( "title" )]
        public string Title { get; set; }

        /// <summary>
        /// REST Url of the work item.
        /// </summary>
        [JsonProperty( "url" )]
        public string Url { get; set; }

        [JsonProperty( "webUrl" )]
        public string WebUrl { get; set; }

        [JsonProperty( "workItemType" )]
        public string WorkItemType { get; set; }

        public override string KeyValue() => Id;

        public override string EqualCondition()
        {
            return $"{Id}";
        }
    }
}