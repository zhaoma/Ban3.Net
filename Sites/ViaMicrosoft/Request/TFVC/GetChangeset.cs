using Ban3.Sites.ViaMicrosoft.Request;
using Ban3.Sites.ViaMicrosoft.Request.TFVC;
using Newtonsoft.Json;

namespace Ban3.Sites.ViaMicrosoft.Request.TFVC
{
	public class GetChangeset
		: MultiPageQuery, IRequest
	{
		public string Method() => "GET";

		public string Resource()
			=> Enums.APIResource.Changeset.ToAPIResourceString(ChangesetId);

        public string JsonBody() => null;

		public GetChangeset()
		{
		}

		public int ChangesetId { get; set; }

		/// <summary>
		/// Results are sorted by ID in descending order by default. Use id asc to sort by ID in ascending order.
		/// </summary>
		[JsonProperty("$orderby")]
		public string OrderBy { get; set; } 

		/// <summary>
		/// Include policy details and check-in notes in the response. Default: false
		/// </summary>
		[JsonProperty("includeDetails")]
		public bool IncludeDetails { get; set; }

		/// <summary>
		/// Include renames. Default: false
		/// </summary>
		[JsonProperty("includeSourceRename")]
		public bool IncludeSourceRename { get; set; }

		/// <summary>
		/// Return the child branches for each root branch.Default: False
		/// </summary>
		[JsonProperty("includeWorkItems")]
		public bool IncludeWorkItems { get; set; }

		/// <summary>
		/// Return deleted branches.Default: False
		/// </summary>
		[JsonProperty("maxChangeCount")]
		public bool MaxChangeCount { get; set; }


		/// <summary>
		/// Include details about associated work items in the response. Default: null
		/// </summary>
		[JsonProperty("maxCommentLength")]
		public int MaxCommentLength { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("searchCriteria")]
		public TfvcChangesetsSearchCriteria SearchCriteria { get; set; } 

	}
}

