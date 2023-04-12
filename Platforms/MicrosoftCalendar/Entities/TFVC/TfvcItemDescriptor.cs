using Newtonsoft.Json;

namespace Ban3.Infrastructures.Platforms.ViaMicrosoft.Entities.TFVC
{
	public class TfvcItemDescriptor
	{
		public TfvcItemDescriptor()
		{
		}

        [JsonProperty("path")]		
		public string Path { get; set; } 
		
		/// <summary>
        /// Enums.VersionControlRecursionType
        /// </summary>
        [JsonProperty("recursionLevel")]
		public string RecursionLevel { get; set; } 

        [JsonProperty("version")]
		public string Version { get; set; } 

        /// <summary>
        /// Enums.TfvcVersionOption
        /// </summary>
		[JsonProperty("versionOption")]
		public string VersionOption { get; set; } 

		/// <summary>
        /// Enums.TfvcVersionType
        /// </summary>
        [JsonProperty("versionType")]
		public string VersionType { get; set; } 
	}
}

