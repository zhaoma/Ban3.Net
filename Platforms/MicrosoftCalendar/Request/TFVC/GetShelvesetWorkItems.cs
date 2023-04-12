using Newtonsoft.Json;

namespace Ban3.Infrastructures.Platforms.ViaMicrosoft.Request.TFVC
{
	public class GetShelvesetWorkItems
		:IRequest
	{
		public string Method() => "GET";

		public string Resource()
			=> Enums.APIResource.ShelvesetWorkItems.ToAPIResourceString();

		public string JsonBody() => null;

		public GetShelvesetWorkItems()
		{
		}

		[JsonProperty("shelvesetId")]
		public string ShelvesetId { get; set; } 
	}
}

