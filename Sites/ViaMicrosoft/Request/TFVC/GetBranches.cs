using Newtonsoft.Json;

namespace Ban3.Sites.ViaMicrosoft.Request.TFVC
{
	public class GetBranches
		: IRequest
	{
		public string Method() => "GET";

		public string Resource()
			=> Enums.APIResource.Branches.ToAPIResourceString();

        public string JsonBody() => null;

		public GetBranches()
		{
		}

		/// <summary>
		/// Return the child branches for each root branch.Default: False
		/// </summary>
		[JsonProperty("includeChildren")]
		public bool IncludeChildren { get; set; }

		/// <summary>
		/// Return deleted branches.Default: False
		/// </summary>
		[JsonProperty("includeDeleted")]
		public bool IncludeDeleted { get; set; }

		/// <summary>
		/// Return links.Default: False
		/// </summary>
		[JsonProperty("includeLinks")]
		public bool IncludeLinks { get; set; }

		/// <summary>
		/// Return the parent branch, if there is one. Default: False
		/// </summary>
		[JsonProperty("includeParent")]
		public bool IncludeParent { get; set; }
	}
}

