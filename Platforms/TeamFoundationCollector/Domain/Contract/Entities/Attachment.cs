using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities
{
    /// <summary>
    /// Represents an attachment to a build.
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/attachments/list?view=azure-devops-server-rest-6.0#attachment
    /// </summary>
    public class Attachment
    {
        /// <summary>
        /// The class to represent a collection of REST reference links.
        /// </summary>
        [JsonPropertyName("_links")]
        public ReferenceLinks Links { get; set; }

        /// <summary>
        /// The name of the attachment.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

    }
}
