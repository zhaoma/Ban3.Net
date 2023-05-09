using System.Collections.Generic;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.WorkItemTracking;

/// <summary>
/// Returns a list of work items (Maximum 200)
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/wit/work-items/list?view=azure-devops-rest-7.0&tabs=HTTP#workitem
/// </summary>
public class ListWorkItems
    : PresetRequest, IRequest
{
    /// <summary>
    /// The comma-separated list of requested work item ids. (Maximum 200 ids allowed).
    /// </summary>
    [JsonProperty("ids")] public string Ids { get; set; } = string.Empty;

    /// <summary>
    /// The expand parameters for work item attributes. Possible options are { None, Relations, Fields, Links, All }.
    /// </summary>
    [JsonProperty("$expand")]
    [JsonConverter(typeof(StringEnumConverter))]
    public WorkItemExpand? Expand { get; set; }

    /// <summary>
    /// AsOf UTC date time string
    /// </summary>
    [JsonProperty("asOf")]
    public string? AsOf { get; set; }

    /// <summary>
    /// The flag to control error policy in a bulk get work items request. Possible options are {Fail, Omit}.
    /// </summary>
    [JsonProperty("errorPolicy")]
    [JsonConverter(typeof(StringEnumConverter))]
    public WorkItemErrorPolicy? ErrorPolicy { get; set; }

    /// <summary>
    /// Comma-separated list of requested fields
    /// </summary>
    [JsonProperty("fields")]
    public string? Fields { get; set; }

    public ListWorkItems(IEnumerable<int> ids, IEnumerable<string> fields)
    {
        Ids = string.Join(",", ids);
        Fields = string.Join(",", fields);
    }

    public string RequestPath() => $"{Instance}/{Organization}/_apis/wit/workitems";


}