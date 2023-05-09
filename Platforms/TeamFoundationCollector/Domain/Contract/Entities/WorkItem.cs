using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// Describes a work item.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/wit/work-items/list?view=azure-devops-rest-7.0&tabs=HTTP#workitem
/// </summary>
public class WorkItem
{
    /// <summary>
    /// Link references to related REST resources.
    /// </summary>
    [JsonProperty("_links")]
    public ReferenceLinks? Links { get; set; }

    /// <summary>
    /// Reference to a specific version of the comment added/edited/deleted in this revision.
    /// </summary>
    [JsonProperty("commentVersionRef")]
    public WorkItemCommentVersionRef? CommentVersionRef { get; set; }

    /// <summary>
    /// Map of field and values for the work item.
    /// </summary>
    [JsonProperty("fields")]
    public Dictionary<string,object>? Fields { get; set; }

    /// <summary>
    /// The work item ID.
    /// </summary>
    [JsonProperty("id")]
    public int Id { get; set; }

    /// <summary>
    /// Relations of the work item.
    /// </summary>
    [JsonProperty("relations")]
    public List<WorkItemRelation>? Relations { get; set; }

    /// <summary>
    /// Revision number of the work item.
    /// </summary>
    [JsonProperty("rev")]
    public int Rev { get; set; }

    [JsonProperty("url")] public string Url { get; set; } = string.Empty;
}