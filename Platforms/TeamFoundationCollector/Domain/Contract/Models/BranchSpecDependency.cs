using System.Xml;
using Ban3.Infrastructures.Common.Extensions;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models;

public class BranchSpecDependency
{
    public BranchSpecDependency(XmlNode node)
    {
        Name = node.TryGetAttribute("Name");
        Project = node.TryGetAttribute("Project");
        Version = node.TryGetAttribute("Version");
    }

    public string Name { get; set; }

    public string Project { get; set; }

    public string Version { get; set; }
}