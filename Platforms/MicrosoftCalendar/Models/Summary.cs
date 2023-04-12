using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.Platforms.ViaMicrosoft.Models
{
    public class Summary
    {
        public List<SummaryIdentity> Identities { get; set; }

        public List<SummaryTeam> Teams { get; set; }
    }
}