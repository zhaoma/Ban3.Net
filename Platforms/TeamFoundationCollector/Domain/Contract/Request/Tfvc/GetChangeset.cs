using System.Text;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.SubCondition;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Tfvc;

/// <summary>
/// Retrieve a Tfvc Changeset
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/tfvc/changesets/get?view=azure-devops-rest-7.0
/// </summary>
public class GetChangeset
    : PresetRequest, IRequest
{
    public string Method { get; set; } = "Get";
    
    /// <summary>
    /// Changeset Id to retrieve.
    /// </summary>
    [JsonProperty("id")]
    public int Id { get; set; }

    /// <summary>
    /// Results are sorted by ID in descending order by default.
    /// Use id asc to sort by ID in ascending order.
    /// </summary>
    [JsonProperty("orderby")]
    public string OrderBy { get; set; } = string.Empty;

    /// <summary>
    /// Number of results to skip.
    /// Default: null
    /// </summary>
    [JsonProperty("skip")]
    public int? Skip { get; set; }

    /// <summary>
    /// The maximum number of results to return.
    /// Default: null
    /// </summary>
    [JsonProperty("top")]
    public int? Top { get; set; }

    /// <summary>
    /// Include policy details and check-in notes in the response.
    /// Default: false
    /// </summary>
    [JsonProperty("includeDetails")]
    public bool IncludeDetails { get; set; } = true;

    /// <summary>
    /// Include renames.
    /// Default: false
    /// </summary>
    [JsonProperty("includeSourceRename")]
    public bool IncludeSourceRename { get; set; } = true;

    /// <summary>
    /// Include workitems.
    /// Default: false
    /// </summary>
    [JsonProperty("includeWorkItems")]
    public bool IncludeWorkItems { get; set; } = true;

    /// <summary>
    /// Number of changes to return (maximum 100 changes)
    /// Default: 0
    /// </summary>
    [JsonProperty("maxChangeCount")]
    public int MaxChangeCount { get; set; } = 100;

    /// <summary>
    /// Include details about associated work items in the response. Default: null
    /// </summary>
    [JsonProperty("maxCommentLength")]
    public int? MaxCommentLength { get; set; } = 10000;

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("searchCriteria")]
    public SearchCriteria? SearchCriteria { get; set; }

    public TfvcMappingFilter? MappingFilter { get; set; }
    
    public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/tfvc/changesets/{Id}";

    public string RequestQuery()
    {
        var sb = new StringBuilder();

        sb.Append("?");
        
        if (!string.IsNullOrEmpty(OrderBy))
            sb.Append($"$orderby={OrderBy}&");

        if (Skip != null)
            sb.Append($"$skip={Skip}&");
        if (Top != null)
            sb.Append($"$top={Top}&");
        sb.Append($"includeDetails={IncludeDetails}&");
        sb.Append($"includeSourceRename={IncludeSourceRename}&");
        sb.Append($"includeWorkItems={IncludeWorkItems}&");

        sb.Append($"maxChangeCount={MaxChangeCount}&");
        if (MaxCommentLength != null)
            sb.Append($"maxCommentLength={MaxCommentLength}&");

        if (SearchCriteria != null)
        {
            sb.Append($"searchCriteria.author={SearchCriteria.Author}&");
            sb.Append($"searchCriteria.followRenames={SearchCriteria.FollowRenames}&");
            sb.Append($"searchCriteria.fromDate={SearchCriteria.FromDate}&");
            sb.Append($"searchCriteria.fromId={SearchCriteria.FromId}&");
            sb.Append($"searchCriteria.includeLinks={SearchCriteria.IncludeLinks}&");
            sb.Append($"searchCriteria.itemPath={SearchCriteria.ItemPath}&");
            sb.Append($"searchCriteria.toDate={SearchCriteria.ToDate}&");
            sb.Append($"searchCriteria.toId={SearchCriteria.ToId}&");
        }

        sb.Append($"api-version={ApiVersion}");
        return sb.ToString();
    }

    public string RequestBody() => MappingFilter != null
        ? JsonConvert.SerializeObject(MappingFilter)
        : string.Empty;
}