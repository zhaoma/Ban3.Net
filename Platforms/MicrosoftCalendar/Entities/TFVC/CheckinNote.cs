using Newtonsoft.Json;

namespace Ban3.Infrastructures.Platforms.ViaMicrosoft.Entities.TFVC
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

