using System;
using System.Collections.Generic;
using System.Text;

using Dapper.Contrib.Extensions;
using Ban3.Infrastructures.Common.Contracts.Attributes;
using Ban3.Infrastructures.Common.Contracts.Entities;
using Ban3.Infrastructures.Common.Extensions;

namespace Ban3.Infrastructures.Platforms.ViaMicrosoft.Models
{
    [Table( "RefererMapping" )]
    [TableStrategy("RefererMapping", "RefererMapping", true, false)]
    public class RefererMapping
            : Entities._BaseEntity
    {
        [ExplicitKey]
        public string Id { get; set; }

        public string IdentityId { get; set; }

        public string RefererModule { get; set; }

        public string RefererId { get; set; }

        public string MappingModule { get; set; }

        public string MappingId { get; set; }

        public string CreatedTime { get; set; }

        public override string KeyValue() => EqualCondition().MD5String();

        public override string EqualCondition()
        {
            return $"{IdentityId}:{RefererModule}:{RefererId}:{MappingModule}:{MappingId}"; ;
        }
    }
}