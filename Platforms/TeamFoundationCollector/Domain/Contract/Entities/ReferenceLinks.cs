using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities
{
    /// <summary>
    /// The class to represent a collection of REST reference links.
    /// </summary>
    public class ReferenceLinks
    {
        /// <summary>
        /// The readonly view of the links.
        /// Because Reference links are readonly, we only want to expose them as read only.
        /// </summary>
        [JsonProperty("links")]
        public object? Links { get; set; }
    }
}
