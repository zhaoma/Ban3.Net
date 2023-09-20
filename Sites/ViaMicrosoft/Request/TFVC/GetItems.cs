using Newtonsoft.Json;

namespace Ban3.Sites.ViaMicrosoft.Request.TFVC
{
	public class GetItems
		:IRequest
	{

		public string Method() => "GET";

		public string Resource()
			=> Enums.APIResource.Items.ToAPIResourceString();

		public string JsonBody() => null;


		public GetItems()
		{
		}

		/// <summary>
		/// True to include links.
		/// </summary>
		public bool IncludeLinks { get; set; }

		/// <summary>
		/// Version control path of a folder to return multiple items.
		/// </summary>
		[JsonProperty("scopePath")]
		public string ScopePath { get; set; } 

		/// <summary>
		/// None(just the item), or OneLevel(contents of a folder).
		/// Enums.VersionControlRecursionType
		/// </summary>
		[JsonProperty("recursionLevel")]
		public string RecursionLevel { get; set; } 

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("versionDescriptor")]
		public TfvcVersionDescriptor VersionDescriptor { get; set; } 


	}
}

