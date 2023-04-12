using System;
using System.Collections.Generic;
using System.Text;

using Dapper.Contrib.Extensions;

using Newtonsoft.Json;

using Ban3.Infrastructures.Common.Contracts.Attributes;
using Ban3.Infrastructures.Common.Contracts.Entities;

namespace Ban3.Infrastructures.Platforms.ViaMicrosoft.Entities.Core
{
    [Table( "TeamMember" )]
    [TableStrategy( "TeamMember", "TeamMember", true, false )]
    public class TeamMember
            : _BaseEntity
    {

        public string TeamId { get; set; } = string.Empty;

        [Write( false )]
        [JsonProperty( "identity" )]
        public Identity Identity { get; set; }

        public string IdentityId { get; set; } = string.Empty;

        [JsonProperty( "isTeamAdmin" )]
        public bool IsTeamAdmin { get; set; }

        public override string KeyValue() => Id;

        public override string EqualCondition()
        {
            return $"{IdentityId}:{TeamId}:{IsTeamAdmin}";
        }
    }
}