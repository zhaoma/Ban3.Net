using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ban3.Sites.ViaMicrosoft.Entities.TFVC
{
	public class TfvcChange
	{
		public TfvcChange()
		{
		}

		/// <summary>
		/// The type of change that was made to the item.
		/// Enums/VersionControlChangeType
		/// </summary>
		[JsonProperty("changeType")]
		public string ChangeType { get; set; } 

		/// <summary>
        /// Current version.
        /// </summary>
        [JsonProperty("item")]
		public string Item { get; set; } 

		/// <summary>
		/// List of merge sources in case of rename or branch creation.
		/// </summary>
		[JsonProperty("mergeSources")]
		public List<TfvcMergeSource> MergeSources { get; set; } 

		/// <summary>
		/// Content of the item after the change.
		/// </summary>
		[JsonProperty("newContent")]
		public ItemContent NewContent { get; set; } 

		/// <summary>
		/// Version at which a (shelved) change was pended against
		/// </summary>
		[JsonProperty("pendingVersion")]
		public int PendingVersion { get; set; }

		/// <summary>
		/// Path of the item on the server.
		/// </summary>
		[JsonProperty("sourceServerItem")]
		public string SourceServerItem { get; set; } 

		/// <summary>
		/// URL to retrieve the item.
		/// </summary>
		[JsonProperty("url")]
		public string Url { get; set; } 
	}
}

