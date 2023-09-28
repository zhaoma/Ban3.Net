using Ban3.Infrastructures.Common.Extensions;

namespace Ban3.Sites.ViaMicrosoft.Request.TFVC
{
	public class GetChangesetsBatch
		: MultiPageQuery, IRequest
	{
		
		public string Method() => "POST";

		public string Resource()
			=> Enums.APIResource.ChangesetsBatch.ToAPIResourceString();

		public string JsonBody()=>RequestData.ObjToJson(); 


        public GetChangesetsBatch()
		{
		}

		public TfvcChangesetsRequestData RequestData { get; set; } 
	}
}

