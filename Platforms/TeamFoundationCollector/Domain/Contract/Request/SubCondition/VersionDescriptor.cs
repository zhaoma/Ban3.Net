using Ban3.Platforms.TeamFoundationCollector.Infrastructrue.Common.Enums;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.SubCondition;

public class VersionDescriptor
{
    public string Version { get; set; }

    public TfvcVersionOption VersionOption { get; set; }

    public TfvcVersionType VersionType { get; set; }
}