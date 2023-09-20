using Newtonsoft.Json;

namespace Ban3.Sites.ViaMicrosoft.Request.TFVC
{
	public class MappingFilter
	{
		public MappingFilter()
		{
		}

		[JsonProperty("exclude")]
		public bool Exclude { get; set; } 

		[JsonProperty("serverPath")]
		public string ServerPath { get; set; } 
	}
}

