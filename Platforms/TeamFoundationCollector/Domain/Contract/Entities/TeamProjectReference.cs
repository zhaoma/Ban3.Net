using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities
{
    /// <summary>
    /// Represents a shallow reference to a TeamProject.
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/get?view=azure-devops-rest-7.0#teamprojectreference
    /// </summary>
    public class TeamProjectReference
    {
        /// <summary>
        /// Project abbreviation.
        /// </summary>
        [JsonProperty("abbreviation")]
        public string Abbreviation { get; set; }

        /// <summary>
        /// Url to default team identity image.
        /// </summary>
        [JsonProperty("defaultTeamImageUrl")]
        public string DefaultTeamImageUrl { get; set; }

        /// <summary>
        /// The project's description (if any).
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Project identifier.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Project last update time.
        /// </summary>
        [JsonProperty("lastUpdateTime")]
        public string LastUpdateTime { get; set; }

        /// <summary>
        /// Project name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Project revision.
        /// </summary>
        [JsonProperty("revision")]
        public int Revision { get; set; }

        /// <summary>
        /// Project state.
        /// </summary>
        [JsonProperty("url")]
        public ProjectState State { get; set; }

        /// <summary>
        /// Url to the full version of the object.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Project visibility.
        /// </summary>
        [JsonProperty("visibility")]
        public ProjectVisibility Visibility { get; set; }
    }
}
