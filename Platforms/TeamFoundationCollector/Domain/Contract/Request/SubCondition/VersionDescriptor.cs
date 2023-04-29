using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.SubCondition;

/// <summary>
/// 
/// </summary>
public class VersionDescriptor
{
    /// <summary>
    /// Version object.
    /// </summary>
    public string Version { get; set; } = string.Empty;

    /// <summary>
    /// Version descriptor. 
    /// Default is null.
    /// </summary>
    public TfvcVersionOption? VersionOption { get; set; }

    /// <summary>
    /// Version descriptor. 
    /// Default is null.
    /// </summary>
    public TfvcVersionType? VersionType { get; set; }
}