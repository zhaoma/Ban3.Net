using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Ban3.Sites.ViaMicrosoft.Models
{
    public class ReportAuthor
    {
        [JsonProperty("identity")]
        public Entities.IdentityRef Identity { get; set; }

        [JsonProperty("teams")]
        public List<Entities.Core.WebApiTeam> Teams { get; set; }

    }
}
