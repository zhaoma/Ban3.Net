// ——————————————————————————————————————
// zhaoma @ 2022 :
// /Users/zhaoma/Projects/fintry/src/Tfvckits/Domain/Platform/Models/ReportTeam.cs
// ——————————————————————————————————————

using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace Ban3.Sites.ViaMicrosoft.Models
{
    public class ReportTeam
    {
        [JsonProperty( "team" )]
        public Entities.Core.WebApiTeam Team { get; set; }

        [JsonProperty( "identities" )]
        public List<Entities.IdentityRef> Identities { get; set; }

        [JsonProperty( "changesetCount" )]
        public int ChangesetCount { get; set; }

        [JsonProperty( "shelvesetCount" )]
        public int ShelvesetCount { get; set; }

        [JsonProperty( "passRatio" )]
        public int PassRatio { get; set; }
    }
}