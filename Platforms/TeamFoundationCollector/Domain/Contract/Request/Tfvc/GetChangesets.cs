using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.SubCondition;
using Newtonsoft.Json;
using System.Text;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Tfvc;

/// <summary>
/// Retrieve Tfvc Changesets
/// Note: This is a new version of the GetChangesets API that doesn't expose the unneeded queryParams present in the 1.0 version of the API.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/tfvc/changesets/get-changesets?view=azure-devops-rest-7.0
/// </summary>
public class GetChangesets
    : PresetRequest, IRequest
{
    /// <summary>
    /// Results are sorted by ID in descending order by default.
    /// Use id asc to sort by ID in ascending order.
    /// </summary>
    [JsonProperty("$orderby")]
    public string? OrderBy { get; set; }

    /// <summary>
    /// Number of results to skip.
    /// Default: null
    /// </summary>
    [JsonProperty("$skip")]
    public int? Skip { get; set; }

    /// <summary>
    /// The maximum number of results to return.
    /// Default: null
    /// </summary>
    [JsonProperty("$top")]
    public int? Top { get; set; }

    /// <summary>
    /// Include details about associated work items in the response. Default: null
    /// </summary>
    [JsonProperty("maxCommentLength")]
    public int? MaxCommentLength { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("searchCriteria")]
    public SearchCriteria? SearchCriteria { get; set; }

    public TfvcMappingFilter? MappingFilter { get; set; }

    public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/tfvc/changesets";

    public override string RequestBody() => MappingFilter != null
        ? JsonConvert.SerializeObject(MappingFilter)
        : string.Empty;
}