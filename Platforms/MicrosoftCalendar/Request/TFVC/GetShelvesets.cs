using Newtonsoft.Json;

namespace Ban3.Infrastructures.Platforms.ViaMicrosoft.Request.TFVC
{
	public class GetShelvesets
		: MultiPageQuery, IRequest
	{
		public string Method() => "GET";

		public string Resource()
			=> Enums.APIResource.Shelvesets.ToAPIResourceString();

		public string JsonBody() => null;

		public GetShelvesets()
		{
		}

		[JsonProperty("requestData")]
		public TfvcShelvesetRequestData RequestData { get; set; } 
	}
}

