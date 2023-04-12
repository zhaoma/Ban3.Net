using System;
using System.Collections.Generic;
using System.Text;

using Dapper.Contrib.Extensions;

using Newtonsoft.Json;

namespace Ban3.Infrastructures.Platforms.ViaMicrosoft.Entities.Builds
{
    public class Build
    {
        /// <summary>
        /// The ID of the build.
        /// </summary>
        [ExplicitKey]
        [JsonProperty( "id" )]
        public int Id { get; set; }

        /// <summary>
        /// The build number/name of the build.
        /// </summary>
        [JsonProperty("buildNumber")]
        public string BuildNumber { get; set; } = string.Empty;
    }
}