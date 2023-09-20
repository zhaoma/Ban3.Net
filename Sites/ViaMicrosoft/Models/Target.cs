using System;
using Newtonsoft.Json;

namespace Ban3.Sites.ViaMicrosoft.Models
{
	public class Target
	{
		public Target()
		{
		}
		/*
		/// <summary>
		/// https://dev.azure.com/
		/// https://dev.azure.com/{organization}/{project}/_apis/tfvc/changesets
		///?maxCommentLength={maxCommentLength}&$skip={$skip}&$top={$top}&$orderby={$orderby}
		/// &searchCriteria.includeLinks={searchCriteria.includeLinks}
		///&searchCriteria.followRenames={searchCriteria.followRenames}
		///&searchCriteria.toId={searchCriteria.toId}&searchCriteria.fromId={searchCriteria.fromId}
		///&searchCriteria.toDate={searchCriteria.toDate}&searchCriteria.fromDate={searchCriteria.fromDate}
		///&searchCriteria.author={searchCriteria.author}&searchCriteria.itemPath={searchCriteria.itemPath}
		///&api-version=5.1
		/// https://tfs-cr.healthcare.siemens.com:8090/tfs/CT/CTS/_apis/tfvc/changesets 
		/// </summary>
		public string Host { get; set; } 

        /// <summary>
        /// The name of the Azure DevOps organization.
        /// </summary>
        [JsonProperty("organization")]
		public string Organization { get; set; } 

		*/

		/// <summary>
		/// Azure DevOps server name ({server:port})
		/// </summary>
		[JsonProperty("instance")]
		public string Instance { get; set; } = "https://tfs-cr.healthcare.siemens.com:8090/tfs";

        /// <summary>
        /// The name of the Azure DevOps collection.
        /// </summary>
        [JsonProperty("collection")]
        public string Collection { get; set; } = "CT";

        /// <summary>
        /// Project ID or project name
        /// </summary>
        [JsonProperty("project")]
        public string Project { get; set; } = "CTS";

		/// <summary>
        /// 
        /// </summary>
        [JsonProperty("apiVersion")]
		public Enums.APIVersion APIVersion { get; set; }

		/// <summary>
		/// 
		/// </summary>
        [JsonProperty("username")] 
        public string UserName { get; set; } = "type TFS username here.";

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("password")]
        public string Password { get; set; } = "type TFS password here.";

    }
}

