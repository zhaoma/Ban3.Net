using System.Collections.Generic;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Build;

/// <summary>
/// Gets the work items associated with a build. Only work items in the same project are returned.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/get-build-work-items-refs?view=azure-devops-rest-7.0
/// </summary>
public class GetBuildWorkItemsRefsFromCommits
    : PresetRequest, IRequest
{
    public GetBuildWorkItemsRefsFromCommits()
    {
        Method = "Post";
    }

    public int BuildId { get; set; }

    [JsonProperty("top")]
    public int? Top { get; set; }

    public List<string>? Body { get; set; }

    public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/build/builds/{BuildId}/workitems";

    public override string RequestBody() => JsonConvert.SerializeObject(Body);
}

