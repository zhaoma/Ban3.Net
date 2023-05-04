namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models;

public class JobForMonitorBranchSpec
{
    public string TargetPath { get; set; }

    public string GuidelinePath { get; set; }

    public List<string> Subscribed { get; set; }
}