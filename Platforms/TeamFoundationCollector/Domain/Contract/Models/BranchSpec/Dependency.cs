using System.Xml;
using Ban3.Infrastructures.Common.Extensions;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models.BranchSpec;

public class Dependency
{
    public Dependency(XmlNode node)
    {
        Name = node.TryGetAttribute("Name");
        Project = node.TryGetAttribute("Project");
        Version = node.TryGetAttribute("Version");
    }

    public string Name { get; set; }

    public string Project { get; set; }

    public string Version { get; set; }
}