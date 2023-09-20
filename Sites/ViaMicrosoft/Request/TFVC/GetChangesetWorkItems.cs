namespace Ban3.Sites.ViaMicrosoft.Request.TFVC
{
	public class GetChangesetWorkItems
		:IRequest
	{

		public string Method() => "GET";

		public string Resource()
			=> Enums.APIResource.ChangesetWorkItems.ToAPIResourceString(ChangesetId);

		public string JsonBody() => null;

		public GetChangesetWorkItems()
		{
		}

		public int ChangesetId { get; set; }
	}
}

