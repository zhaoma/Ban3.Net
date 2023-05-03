using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Build;

/// <summary>
/// Gets the changes made to the repository between two given builds.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/get-changes-between-builds?view=azure-devops-rest-7.0
/// </summary>
public class GetChangesBetweenBuilds
    : PresetRequest, IRequest
{
    /// <summary>
    /// The maximum number of changes to return.
    /// </summary>
    [JsonProperty("top")]
    public int? Top { get; set; }

    /// <summary>
    /// The ID of the first build.
    /// </summary>
    [JsonProperty("fromBuildId")]
    public int? FromBuildId { get; set; }

    /// <summary>
    /// The ID of the last build.
    /// </summary>
    [JsonProperty("toBuildId")]
    public int? ToBuildId { get; set; }

    public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/build/changes";
}

