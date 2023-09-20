using Ban3.Infrastructures.DataPersist.Attributes;
using Ban3.Infrastructures.DataPersist.Entities;
using Newtonsoft.Json;

namespace Ban3.Sites.ViaMicrosoft.Entities.TFVC;

[TableIs("AssociatedWorkItem", "AssociatedWorkItem", false)]
public class AssociatedWorkItem
    : BaseEntity
{
    [JsonProperty("assignedTo")] public string AssignedTo { get; set; }

    [JsonProperty("state")] public string State { get; set; }

    [JsonProperty("title")] public string Title { get; set; }

    /// <summary>
    /// REST Url of the work item.
    /// </summary>
    [JsonProperty("url")]
    public string Url { get; set; }

    [JsonProperty("webUrl")] public string WebUrl { get; set; }

    [JsonProperty("workItemType")] public string WorkItemType { get; set; }
}