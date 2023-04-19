using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// Item path and Version descriptor properties
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/tfvc/items/get-items-batch?view=azure-devops-rest-7.0#tfvcitemdescriptor
/// </summary>
public class TfvcItemDescriptor
{
    [JsonProperty("path")]
    public string Path { get; set; } = string.Empty;

    /// <summary>
    /// Enums.VersionControlRecursionType
    /// Defaults to OneLevel.
    /// </summary>
    [JsonProperty("recursionLevel")]
    public VersionControlRecursionType RecursionLevel { get; set; }

    /// <summary>
    /// Specify the desired version, can be null or empty string only if VersionType is latest or tip.
    /// </summary>
    [JsonProperty("version")]
    public string Version { get; set; } = string.Empty;

    /// <summary>
    /// Enums.TfvcVersionOption
    /// Defaults to None.
    /// </summary>
    [JsonProperty("versionOption")]
    public TfvcVersionOption VersionOption { get; set; }

    /// <summary>
    /// Enums.TfvcVersionType
    /// Defaults to Latest.
    /// </summary>
    [JsonProperty("versionType")]
    public TfvcVersionType VersionType { get; set; }
}