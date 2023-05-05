using System.Collections.Generic;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models.BranchSpec;

public class MonitorJob
{
    public string Subject { get; set; }

    public List<MonitorSection> Sections { get; set; }
    
    public List<string> Subscribed { get; set; }
}