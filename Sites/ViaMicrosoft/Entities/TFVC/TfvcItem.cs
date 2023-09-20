using Newtonsoft.Json;

namespace Ban3.Sites.ViaMicrosoft.Entities.TFVC
{
	public class TfvcItem
	{
		public TfvcItem()
		{
		}

        [JsonProperty("changeDate")]
		public string ChangeDate { get; set; } 


		[JsonProperty("content")]
		public string Content { get; set; } 


		[JsonProperty("contentMetadata")]
		public FileContentMetadata ContentMetadata { get; set; } 

        [JsonProperty("deletionId")]
		public int DeletionId { get; set; }

		/// <summary>
        /// File encoding from database, -1 represents binary.
        /// </summary>
		[JsonProperty("encoding")]
		public int Encoding { get; set; }

		/// <summary>
		/// MD5 hash as a base 64 string, applies to files only.
		/// </summary>
		[JsonProperty("hashValue")]
		public string HashValue { get; set; } 

        [JsonProperty("isBranch")]
		public bool IsBranch { get; set; }

        [JsonProperty("isFolder")]
		public bool IsFolder { get; set; }

        [JsonProperty("isPendingChange")]
		public bool IsPendingChange { get; set; }

        [JsonProperty("isSymLink")]
		public bool IsSymLink { get; set; }

        [JsonProperty("path")]
		public string Path { get; set; } 

		/// <summary>
        /// The size of the file, if applicable.
        /// </summary>
        [JsonProperty("size")]
		public int Size { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[JsonProperty("url")]
		public string Url { get; set; } 

		/// <summary>
        /// 
        /// </summary>
        [JsonProperty("version")]
		public int Version { get; set; }

	}
}

