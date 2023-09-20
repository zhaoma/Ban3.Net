namespace Ban3.Sites.ViaMicrosoft.Request.TFVC
{
	public class GetChangesetChanges
		: MultiPageQuery, IRequest
	{

		public string Method() => "GET";

		public string Resource()
			=> Enums.APIResource.ChangesetChanges.ToAPIResourceString(ChangesetId);

		public string JsonBody() => null;

		public GetChangesetChanges()
		{
		}


		public int ChangesetId { get; set; }

	}
}

