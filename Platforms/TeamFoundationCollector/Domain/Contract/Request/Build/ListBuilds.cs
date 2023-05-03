using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;
using System;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using System.Text;
using Ban3.Infrastructures.Common.Extensions;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Build;

/// <summary>
/// Gets a list of builds.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/list?view=azure-devops-rest-7.0
/// </summary>
public class ListBuilds
    : PresetRequest, IRequest
{
    /// <summary>
    /// The maximum number of changes to return.
    /// </summary>
    [JsonProperty("$top")]
    public int? Top { get; set; }

    [JsonProperty("branchName")]
    public string? BranchName { get; set; } = string.Empty;

    [JsonProperty("buildIds")]
    public string? BuildIds { get; set; } = string.Empty;

    [JsonProperty("buildNumber")]
    public string? BuildNumber { get; set; } = string.Empty;

    [JsonProperty("continuationToken")]
    public string? ContinuationToken { get; set; } = string.Empty;

    [JsonProperty("definitions")]
    public string? Definitions { get; set; } = string.Empty;

    [JsonProperty("deletedFilter")]
    public QueryDeletedOption? DeletedFilter { get; set; }

    [JsonProperty("maxBuildsPerDefinition")]
    public int? MaxBuildsPerDefinition { get; set; }

    [JsonProperty("maxTime")]
    public string? MaxTime { get; set; } = string.Empty;

    [JsonProperty("minTime")]
    public string? MinTime { get; set; } = string.Empty;

    [JsonProperty("properties")]
    public string? Properties { get; set; } = string.Empty;

    [JsonProperty("queryOrder")]
    public BuildQueryOrder? QueryOrder { get; set; }

    [JsonProperty("queues")]
    public string? Queues { get; set; } = string.Empty;

    [JsonProperty("reasonFilter")]
    public BuildReason? ReasonFilter { get; set; }

    [JsonProperty("repositoryId")]
    public string? RepositoryId { get; set; } = string.Empty;

    [JsonProperty("repositoryType")]
    public string? RepositoryType { get; set; } = string.Empty;

    [JsonProperty("requestedFor")]
    public string? RequestedFor { get; set; } = string.Empty;

    [JsonProperty("resultFilter")]
    public BuildResult? ResultFilter { get; set; }

    [JsonProperty("statueFilter")]
    public BuildStatus? StatusFilter { get; set; }

    [JsonProperty("tagFilters")]
    public string? TagFilters { get; set; } = string.Empty;

    public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/build/builds";
}

