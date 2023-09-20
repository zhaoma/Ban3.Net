using Newtonsoft.Json;

namespace Ban3.Sites.ViaMicrosoft.Request.TFVC
{
	public class TfvcVersionDescriptor
	{
		public TfvcVersionDescriptor()
		{
		}


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

