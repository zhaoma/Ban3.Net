using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Attributes;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.ArtifactsPackageTypes;

public class MavenDeleteVersion
    : PresetRequest, IRequest
{
    public MavenDeleteVersion() {
        Method = "Delete";
    }

    public string ArtifactId { get; set; } = string.Empty;

    /// <summary>
    /// Name or ID of the feed.
    /// </summary>
    public string Feed { get; set; } = string.Empty;

    /// <summary>
    /// Group ID of the package.
    /// </summary>
    public string GroupId { get; set; } = string.Empty;

    /// <summary>
    /// Version of the package.
    /// </summary>
    public string Version { get; set; } = string.Empty;

    public string RequestPath() => $"{Instance}/{Organization}/_apis/packaging/feeds/{Feed}/maven/groups/{GroupId}/artifacts/{ArtifactId}/versions/{Version}";

}