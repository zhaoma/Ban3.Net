
using Newtonsoft.Json;

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
        [JsonProperty("_links")]
        public ReferenceLinks? Links { get; set; }

        /// <summary>
        /// The name of the attachment.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

    }
}
