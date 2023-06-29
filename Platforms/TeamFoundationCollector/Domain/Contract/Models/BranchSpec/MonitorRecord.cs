using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models.BranchSpec
{
    public class MonitorRecord
    {
        public string Name { get; set; } = string.Empty;

        public string Version { get; set; } = string.Empty;

        public Dictionary<string, string> GuidelineVersions { get; set; } = new();

        public bool NotSame 
            => GuidelineVersions.Any(o => o.Value != Version);
    }
}
