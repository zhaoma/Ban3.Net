namespace Ban3.Sites.ViaMicrosoft.Request.TFVC
{
	public class GetLabelItems
		:MultiPageQuery,IRequest
	{
		public string Method() => "GET";

		public string Resource()
			=> Enums.APIResource.LabelItems.ToAPIResourceString(LabelId);

		public string JsonBody() => null;

		public GetLabelItems()
		{
		}


		public string LabelId { get; set; } 

	}
}

