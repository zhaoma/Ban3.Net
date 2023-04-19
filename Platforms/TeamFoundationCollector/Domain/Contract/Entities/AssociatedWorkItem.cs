using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/tfvc/changesets/get?view=azure-devops-rest-7.0#associatedworkitem
/// </summary>
public class AssociatedWorkItem
{
    [JsonProperty("assignedTo")]
    public string AssignedTo { get; set; } = string.Empty;

    /// <summary>
    /// Id of associated the work item.
    /// </summary>
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("state")]
    public string State { get; set; } = string.Empty;

    [JsonProperty("title")]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// REST Url of the work item.
    /// </summary>
    [JsonProperty("url")]
    public string Url { get; set; } = string.Empty;

    [JsonProperty("webUrl")]
    public string WebUrl { get; set; } = string.Empty;

    [JsonProperty("workItemType")]
    public string WorkItemType { get; set; } = string.Empty;
}