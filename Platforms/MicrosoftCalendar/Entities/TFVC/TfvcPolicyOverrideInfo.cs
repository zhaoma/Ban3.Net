using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.Platforms.ViaMicrosoft.Entities.TFVC
{
	public class TfvcPolicyOverrideInfo
	{
		public TfvcPolicyOverrideInfo()
		{
		}

        [JsonProperty("comment")]
		public string Comment { get; set; } 

        [JsonProperty("policyFailures")]
		public IEnumerable<TfvcPolicyFailureInfo> PolicyFailures { get; set; } = default;
	}
}

