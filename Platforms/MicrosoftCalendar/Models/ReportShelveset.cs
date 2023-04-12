using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.Platforms.ViaMicrosoft.Models
{
    public class ReportShelveset
    {

        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("shelvesetId")]
        public string ShelvesetId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("owner")]
        public ReportAuthor Owner { get; set; }
        
        /// <summary>
        /// Creation date of the changeset.
        /// </summary>
        [JsonProperty("createdDate")]
        public string CreatedDate { get; set; }

        /// <summary>
        /// Comment for the changeset.
        /// </summary>
        [JsonProperty("comment")]
        public string Comment { get; set; }

        /// <summary>
        /// Was the Comment result truncated?
        /// </summary>
        [JsonProperty("commentTruncated")]
        public bool CommentTruncated { get; set; }

        [JsonProperty("discussion")]
        public List<Entities.Discussion.Thread> Discussion { get; set; }

        [JsonProperty("workItems")]
        public List<Entities.TFVC.AssociatedWorkItem> WorkItems { get; set; }
    }
}
