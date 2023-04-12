using Newtonsoft.Json;

namespace Ban3.Infrastructures.Platforms.ViaMicrosoft.Entities.TFVC
{
	public class TfvcBranchMapping
	{
		public TfvcBranchMapping()
		{
		}

		/// <summary>
		/// Depth of the branch.
		/// </summary>
		[JsonProperty("depth")]
		public string Depth { get; set; } 

		/// <summary>
        /// Server item for the branch.
        /// </summary>
        [JsonProperty("serverItem")]
		public string ServerItem { get; set; } 

		/// <summary>
		/// Type of the branch.
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; } 

	}
}

