using Newtonsoft.Json;

namespace Ban3.Sites.ViaMicrosoft.Request.TFVC
{
	public class GetBranchRefs
		:IRequest
	{
		public string Method() => "GET";

		public string Resource()
			=> Enums.APIResource.BranchRefs.ToAPIResourceString();

		public string JsonBody() => null;

		public GetBranchRefs()
		{
		}

		/// <summary>
		/// Full path to the branch.Default: $/ Examples: $/, $/MyProject, $/MyProject/SomeFolder.
		/// </summary>
		[JsonProperty("scopePath")]
		public string ScopePath { get; set; } 

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

	}
}

