using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Build;

/// <summary>
/// Deletes a build.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/delete?view=azure-devops-rest-7.0
/// </summary>
public class DeleteBuild
    : PresetRequest, IRequest
{
    public DeleteBuild()
    {
        Method = "Delete";
    }

    /// <summary>
    /// The ID of the build.
    /// </summary>
    public int BuildId { get; set; }
    
    public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/build/builds/{BuildId}";
}

