using Newtonsoft.Json;

namespace Ban3.Sites.ViaMicrosoft.Entities.TFVC
{
	public class TfvcPolicyFailureInfo
	{
		public TfvcPolicyFailureInfo()
		{
		}

        [JsonProperty("name")]
		public string Name { get; set; } 

        [JsonProperty("policyName")]
		public string PolicyName { get; set; } 
	}
}

