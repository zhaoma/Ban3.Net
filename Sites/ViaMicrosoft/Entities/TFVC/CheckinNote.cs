using Newtonsoft.Json;

namespace Ban3.Sites.ViaMicrosoft.Entities.TFVC
{
	public class CheckinNote
	{
		public CheckinNote()
		{
		}

        [JsonProperty("name")]
		public string Name { get; set; } 

        [JsonProperty("value")]
		public string Value { get; set; } 
	}
}

