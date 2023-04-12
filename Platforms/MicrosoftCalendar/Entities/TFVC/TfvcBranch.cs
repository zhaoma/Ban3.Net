using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.Platforms.ViaMicrosoft.Entities.TFVC
{
	public class TfvcBranch
		:TfvcBranchRef
	{
		public TfvcBranch()
		{
		}

		/// <summary>
		/// List of children for the branch.
		/// </summary>
		[JsonProperty("children")]
		public IEnumerable<TfvcBranch> Children { get; set; } 

		/// <summary>
		/// List of branch mappings.
		/// </summary>
		[JsonProperty("mappings")]
		public IEnumerable<TfvcBranchMapping> Mappings { get; set; } 

		/// <summary>
		/// Path of the branch's parent.
		/// </summary>
		[JsonProperty("parent")]
		public TfvcShallowBranchRef Parent { get; set; } 

		/// <summary>
		/// List of paths of the related branches.
		/// </summary>
		[JsonProperty("relatedBranches")]
		public IEnumerable<TfvcShallowBranchRef> RelatedBranches { get; set; } 
	}
}

