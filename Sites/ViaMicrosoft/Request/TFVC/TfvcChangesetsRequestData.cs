using System.Collections.Generic;

namespace Ban3.Sites.ViaMicrosoft.Request.TFVC
{
	public class TfvcChangesetsRequestData
	{
		public TfvcChangesetsRequestData()
		{
		}

		/// <summary>
		/// List of changeset Ids.
		/// </summary>
		public IEnumerable<int> ChangesetIds { get; set; } 

		/// <summary>
        /// Length of the comment.
        /// </summary>
		public int CommentLength { get; set; }

		/// <summary>
        /// Whether to include the _links field on the shallow references
        /// </summary>
		public bool IncludeLinks { get; set; }
	}
}

