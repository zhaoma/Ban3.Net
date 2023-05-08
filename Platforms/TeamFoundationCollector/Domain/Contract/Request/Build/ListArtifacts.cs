using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using System.IO;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Build;

/// <summary>
/// Gets all artifacts for a build.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/artifacts/list?view=azure-devops-rest-7.0
/// </summary>
public class ListArtifacts
    : PresetRequest, IRequest
{
    /// <summary>
    /// The ID of the build.
    /// </summary>
    public int BuildId { get; set; }

    public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/build/builds/{BuildId}/artifacts";
}