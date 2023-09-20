using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ban3.Sites.ViaMicrosoft.Entities.TFVC
{
	public class TfvcLabel
		:TfvcLabelRef
	{
		public TfvcLabel()
		{
		}

        [JsonProperty("items")]
		public IEnumerable<TfvcItem> Items { get; set; }


	}
}

