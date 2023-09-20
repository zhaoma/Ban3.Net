using Newtonsoft.Json;

namespace Ban3.Sites.ViaMicrosoft.Request.TFVC
{
	public class GetShelvesetChanges
		:MultiPageQuery,IRequest
	{
		public string Method() => "GET";

		public string Resource()
			=> Enums.APIResource.ShelvesetChanges.ToAPIResourceString();

		public string JsonBody() => null;

		public GetShelvesetChanges()
		{
		}

		[JsonProperty("shelvesetId")]
		public string ShelvesetId { get; set; } 
	}
}

