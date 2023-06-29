using System.Collections.Generic;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models.BranchSpec;

public class MonitorJob
{
    public string Subject { get; set; } = string.Empty;

    public List<MonitorSection> Sections { get; set; } = new();
    
    public List<string> Subscribed { get; set; } = new();
}