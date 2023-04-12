using System;
using System.Collections.Generic;
using System.Text;

using Dapper.Contrib.Extensions;
using Ban3.Infrastructures.Common.Contracts.Attributes;

namespace Ban3.Infrastructures.Platforms.ViaMicrosoft.Entities
{
    [Table( "Identity" )]
    [TableStrategy( "Identity", "Identity", true )]
    public class Identity
            : IdentityRef {}
}