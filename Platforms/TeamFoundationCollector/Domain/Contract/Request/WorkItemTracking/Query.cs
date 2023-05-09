using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Tfvc;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.WorkItemTracking;

/// <summary>
/// Gets the results of the query given its WIQL.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/wit/wiql/query-by-wiql?view=azure-devops-server-rest-6.0&tabs=HTTP
/// </summary>
public class Query
    : PresetRequest, IRequest
{
    public Query()
    {
        Method = "Post";
    }

    /// <summary>
    /// Team ID or team name
    /// </summary>
    public string? Team { get; set; }

    /// <summary>
    /// The max number of results to return.
    /// </summary>
    [JsonProperty("$top")]
    public int? Top { get; set; }

    /// <summary>
    /// Whether or not to use time precision.
    /// </summary>
    [JsonProperty("timePrecision")]
    public bool? TimePrecision { get; set; }

    public Entities.Wiql? Body { get; set; }

    public string RequestPath() =>
        string.IsNullOrEmpty(Team)
            ? $"{Instance}/{Organization}/_apis/wit/wiql"
            : $"{Instance}/{Organization}/{Team}/_apis/wit/wiql";

    public override string RequestQuery()
    {
        var r = base.RequestQuery();
        if (r != "?")
            r += "&";

        r += $"api-version={ApiVersion}";
        return r;
    }

    public override string RequestBody() => JsonConvert.SerializeObject(Body);
}