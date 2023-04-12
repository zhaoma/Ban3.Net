using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.Platforms.ViaMicrosoft.Entities.WIQL
{
    /// <summary>
    /// Represents the reference to a specific version of a comment on a Work Item.
    /// </summary>
    public class WorkItemCommentVersionRef
    {
        public string CommentId { get; set; }

        public int CreatedInRevision { get; set; }
        
        public bool IsDeleted { get; set; }
        
        public string Text { get; set; }

        public string Url { get; set; }

        public int Version { get; set; }
    }
}
