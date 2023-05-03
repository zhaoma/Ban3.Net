using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.SubCondition;

/// <summary>
/// 
/// </summary>
public class VersionDescriptor
{
    /// <summary>
    /// Version object.
    /// </summary>
    [JsonProperty("version")]
    public string? Version { get; set; }

    /// <summary>
    /// Version descriptor. 
    /// Default is null.
    /// </summary>
    [JsonProperty("versionOption")]
    public TfvcVersionOption? VersionOption { get; set; }

    /// <summary>
    /// Version descriptor. 
    /// Default is null.
    /// </summary>
    [JsonProperty("versionType")]
    public TfvcVersionType? VersionType { get; set; }
}