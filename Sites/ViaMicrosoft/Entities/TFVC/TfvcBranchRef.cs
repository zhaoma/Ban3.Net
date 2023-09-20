using Newtonsoft.Json;

namespace Ban3.Sites.ViaMicrosoft.Entities.TFVC
{
	public class TfvcBranchRef
	{
		public TfvcBranchRef()
		{
		}

		/// <summary>
		/// Creation date of the branch.
		/// </summary>
		[JsonProperty("createdDate")]
		public string CreatedDate { get; set; } 

		/// <summary>
		/// Description of the branch.
		/// </summary>
		[JsonProperty("description")]
		public string Description { get; set; } 

		/// <summary>
		/// Is the branch deleted?
		/// </summary>
		[JsonProperty("isDeleted")]
		public bool IsDeleted { get; set; } 

		/// <summary>
		/// Alias or display name of user
		/// </summary>
		[JsonProperty("owner")]
		public IdentityRef Owner { get; set; } 

		/// <summary>
		/// Path for the branch.
		/// </summary>
		[JsonProperty("path")]
		public string Path { get; set; } 

		/// <summary>
		/// URL to retrieve the item.
		/// </summary>
		[JsonProperty("url")]
		public string Url { get; set; } 
	}
}

