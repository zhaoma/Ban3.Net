using System;
using System.Collections.Generic;
using System.Text;
using Ban3.Infrastructures.DataPersist.Entities;
using Newtonsoft.Json;

namespace Ban3.Sites.ViaMicrosoft.Entities.Builds
{
    public class Build: BaseEntity
    {
        /// <summary>
        /// The ID of the build.
        /// </summary>
        [JsonProperty( "id" )]
        public int Id { get; set; }

        /// <summary>
        /// The build number/name of the build.
        /// </summary>
        [JsonProperty("buildNumber")]
        public string BuildNumber { get; set; } = string.Empty;
    }
}