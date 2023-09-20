using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

using Dapper.Contrib.Extensions;

using Newtonsoft.Json;

using Ban3.Infrastructures.Common.Contracts.Attributes;
using Ban3.Infrastructures.Common.Contracts.Entities;
using Ban3.Infrastructures.DataPersist.Attributes;

namespace Ban3.Sites.ViaMicrosoft.Entities.Core
{
    [TableIs( "TeamMember", "TeamMember", true,"msData" )]
    public class TeamMember
            : _BaseEntity
    {
        [FieldIs(ColumnIndex = 1,ColumnName = "TeamId",Key = true,NotForUpdate = true,Subject = "ID")]
        public string TeamId { get; set; } = string.Empty;
        
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