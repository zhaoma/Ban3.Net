using System;
using System.Collections.Generic;
using System.Text;

using Dapper.Contrib.Extensions;

using Newtonsoft.Json;

using Ban3.Infrastructures.Common.Contracts.Attributes;
using Ban3.Infrastructures.Common.Contracts.Entities;

namespace Ban3.Sites.ViaMicrosoft.Entities.Core
{
    /// <summary>
    /// 
    /// </summary>
    [TableStrategy( "WebApiTeam", "WebApiTeam", true )]
    public class WebApiTeamRef
            : _BaseEntity
    {
        /// <summary>
        /// Team(Identity) Guid.A Team Foundation ID.
        /// </summary>
        [ExplicitKey]
        [JsonProperty( "id" )]
        public string Id { get; set; }

        /// <summary>
        /// Team name
        /// </summary>

        [JsonProperty( "name" )]
        public string Name { get; set; }

        /// <summary>
        ///  Team REST API Url
        /// </summary>

        [JsonProperty( "url" )]
        public string Url { get; set; }

        public override string KeyValue() => Id;
    }
}