using Newtonsoft.Json;

namespace Ban3.Infrastructures.Platforms.ViaMicrosoft.Request.TFVC
{
	public class GetBranch
		:IRequest
	{
        public string Method() => "GET";

        public string Resource()
            => Enums.APIResource.Branch.ToAPIResourceString();

        public string JsonBody() => null;

		public GetBranch()
		{
		}


		/// <summary>
		/// Full path to the branch.Default: $/ Examples: $/, $/MyProject, $/MyProject/SomeFolder.
		/// </summary>
		[JsonProperty("path")]
		public string Path { get; set; } 

		/// <summary>
		/// Return the child branches for each root branch.Default: False
		/// </summary>
		[JsonProperty("includeChildren")]
		public bool IncludeChildren { get; set; }


		/// <summary>
		/// Return the parent branch, if there is one. Default: False
		/// </summary>
		[JsonProperty("includeParent")]
		public bool IncludeParent { get; set; }
	}
}

