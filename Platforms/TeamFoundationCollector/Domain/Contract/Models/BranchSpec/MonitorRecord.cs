using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models.BranchSpec
{
    public class MonitorRecord
    {
        public string Name { get; set; }

        public string Version { get; set; }

        public Dictionary<string,string> GuidelineVersions { get; set; }

        public bool NotSame 
            => GuidelineVersions.Any(o => o.Value != Version);
    }
}
