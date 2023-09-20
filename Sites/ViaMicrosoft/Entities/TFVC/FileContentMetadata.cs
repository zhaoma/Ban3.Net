using Newtonsoft.Json;

namespace Ban3.Sites.ViaMicrosoft.Entities.TFVC
{
	public class FileContentMetadata
	{
		public FileContentMetadata()
		{
		}

        [JsonProperty("contentType")]
		public string ContentType { get; set; } 
		
		[JsonProperty("encoding")]
		public int Encoding { get; set; }

		[JsonProperty("extension")]
		public string Extension { get; set; } 

		[JsonProperty("fileName")]
		public string FileName { get; set; } 

		[JsonProperty("isBinary")]
		public bool IsBinary { get; set; } 

		[JsonProperty("isImage")]
		public bool IsImage { get; set; }

		[JsonProperty("vsLink")]
		public string VSLink { get; set; } 
	}
}

