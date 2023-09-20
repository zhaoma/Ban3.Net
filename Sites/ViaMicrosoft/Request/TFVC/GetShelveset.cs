using Newtonsoft.Json;

namespace Ban3.Sites.ViaMicrosoft.Request.TFVC
{
	public class GetShelveset
	:IRequest
	{
		public string Method() => "GET";

		public string Resource()
			=> Enums.APIResource.Shelveset.ToAPIResourceString();

		public string JsonBody() => null;

		public GetShelveset()
		{
		}

        [JsonProperty("shelvesetId")]
		public string ShelvesetId { get; set; } 

        [JsonProperty("requestData")]
		public TfvcShelvesetRequestData RequestData { get; set; } 
	}
}

