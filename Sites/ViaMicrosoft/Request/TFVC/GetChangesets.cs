using Newtonsoft.Json;

namespace Ban3.Sites.ViaMicrosoft.Request.TFVC
{
	public class GetChangesets
		:MultiPageQuery,IRequest
	{
		public string Method()=> "GET";

		public string Resource()
			=> Enums.APIResource.Changesets.ToAPIResourceString();

		public string JsonBody() => null;

		public GetChangesets()
		{
		}

        /// <summary>
        /// Results are sorted by ID in descending order by default. Use id asc to sort by ID in ascending order.
        /// </summary>
        [JsonProperty("orderby")]
		public string OrderBy { get; set; } 

		/// <summary>
        /// Include details about associated work items in the response. Default: null
        /// </summary>
        [JsonProperty("maxCommentLength")]
		public int MaxCommentLength { get; set; }

		/// <summary>
        /// 
        /// </summary>
        [JsonProperty("searchCriteria")]
		public TfvcChangesetsSearchCriteria SearchCriteria { get; set; } 	
	}
}

