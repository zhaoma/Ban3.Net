using Newtonsoft.Json;

namespace Ban3.Infrastructures.Platforms.ViaMicrosoft.Request.TFVC
{
	public class TfvcLabelRequestData
	{
		public TfvcLabelRequestData()
		{
		}

        [JsonProperty("includeLinks")]
		public bool IncludeLinks { get; set; }

		[JsonProperty("itemLabelFilter")]
		public string ItemLabelFilter { get; set; } 

        [JsonProperty("labelScope")]
		public string LabelScope { get; set; } 

		[JsonProperty("maxItemCount")]
		public int MaxItemCount { get; set; }

        [JsonProperty("name")]
		public string Name { get; set; } 

		[JsonProperty("owner")]
		public string Owner { get; set; } 

	}
}

