using Newtonsoft.Json;

namespace Ban3.Infrastructures.Platforms.ViaMicrosoft.Entities.TFVC
{
	public class TfvcMergeSource
	{
		public TfvcMergeSource()
		{
		}

		/// <summary>
		/// Indicates if this a rename source. If false, it is a merge source.
		/// </summary>
		[JsonProperty("isRename")]
		public bool IsRename { get; set; }

		/// <summary>
		/// The server item of the merge source
		/// </summary>
		[JsonProperty("serverItem")]
		public string ServerItem { get; set; } 

		/// <summary>
		/// Start of the version range
		/// </summary>
		[JsonProperty("versionFrom")]
		public int VersionFrom { get; set; }

		/// <summary>
		/// End of the version range
		/// </summary>
		[JsonProperty("versionTo")]
		public int VersionTo { get; set; }
	}
}

