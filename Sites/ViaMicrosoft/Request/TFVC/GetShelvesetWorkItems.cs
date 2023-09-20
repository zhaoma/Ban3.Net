using Newtonsoft.Json;

namespace Ban3.Sites.ViaMicrosoft.Request.TFVC
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

