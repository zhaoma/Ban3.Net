using System.Collections.Generic;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models.BranchSpec;

public class MonitorSection
{
    public string SectionName { get; set; }

    public KeyValuePair<string, string> Target { get; set; }

    public Dictionary<string, string> Guidelines { get; set; }

}