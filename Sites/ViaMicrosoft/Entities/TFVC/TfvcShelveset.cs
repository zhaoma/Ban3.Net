using System.Collections.Generic;
using Newtonsoft.Json;

using Ban3.Infrastructures.Common.Contracts.Attributes;

namespace Ban3.Sites.ViaMicrosoft.Entities.TFVC
{
    [TableStrategy("Shelveset", "Shelveset", false)]
	public class TfvcShelveset
		:TfvcShelvesetRef
	{
		public TfvcShelveset()
		{
		}

		[JsonProperty("changes")]
		public IEnumerable<TfvcChange> Changes { get; set; } 

        [JsonProperty("notes")]
		public IEnumerable<CheckinNote> Notes { get; set; } 

		[JsonProperty("policyOverride")]
		public TfvcPolicyOverrideInfo PolicyOverride { get; set; } 
	}
}

