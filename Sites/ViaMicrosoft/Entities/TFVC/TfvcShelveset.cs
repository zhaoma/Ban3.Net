using System.Collections.Generic;
using Newtonsoft.Json;



namespace Ban3.Sites.ViaMicrosoft.Entities.TFVC
{
    [TableIs("Shelveset", "Shelveset", false)]
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

