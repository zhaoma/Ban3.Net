using Newtonsoft.Json;

namespace Ban3.Infrastructures.Platforms.ViaMicrosoft.Request.TFVC
{
	public class GetLabel
		:IRequest
	{

		public string Method() => "GET";

		public string Resource()
			=> Enums.APIResource.Label.ToAPIResourceString(LabelId);

		public string JsonBody() => null;

		public GetLabel()
		{
		}

		public string LabelId { get; set; } 


        [JsonProperty("requestData")]
		public TfvcLabelRequestData RequestData { get; set; } 
	}
}

