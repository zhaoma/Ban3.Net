using Newtonsoft.Json;

namespace Ban3.Sites.ViaMicrosoft.Request.TFVC
{
	public class GetLabels
		:MultiPageQuery,IRequest
	{

		public string Method() => "GET";

		public string Resource()
			=> Enums.APIResource.Labels.ToAPIResourceString();

		public string JsonBody() => null;


		public GetLabels()
		{
		}


		[JsonProperty("requestData")]
		public TfvcLabelRequestData RequestData { get; set; } 
	}
}

