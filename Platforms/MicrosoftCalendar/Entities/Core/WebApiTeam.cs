using System;
using System.Collections.Generic;
using System.Text;

using Dapper.Contrib.Extensions;

using Newtonsoft.Json;

using Ban3.Infrastructures.Common.Contracts.Attributes;

namespace Ban3.Infrastructures.Platforms.ViaMicrosoft.Entities.Core
{
    [Table( "WebApiTeam" )]
    [TableStrategy( "WebApiTeam", "WebApiTeam", true )]
    public class WebApiTeam
            : WebApiTeamRef
    {
        [JsonProperty( "description" )]
        public string Description { get; set; }

        [JsonProperty( "identityUrl" )]
        public string IdentityUrl { get; set; }

        [JsonProperty( "projectName" )]
        public string ProjectName { get; set; }

        [JsonProperty( "projectId" )]
        public string ProjectId { get; set; }

        public bool Followed { get; set; }

        public override string KeyValue() => Id;

        public override string EqualCondition()
        {
            return $"{Name}:{Url}";
        }
    }
}