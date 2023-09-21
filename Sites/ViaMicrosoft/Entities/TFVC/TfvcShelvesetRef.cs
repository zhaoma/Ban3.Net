using System.Collections.Generic;



using Newtonsoft.Json;



using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.DataPersist.Attributes;
using Ban3.Infrastructures.DataPersist.Entities;

namespace Ban3.Sites.ViaMicrosoft.Entities.TFVC;

/// <summary>
/// 搁置集
/// </summary>
[TableIs("Shelveset", "Shelveset", false)]
public class TfvcShelvesetRef
    : BaseEntity
{
    public TfvcShelvesetRef()
    {
    }

    public string Id { get; set; }

    [JsonProperty("id")] public string ShelvesetId { get; set; }

    [JsonProperty("name")] public string Name { get; set; }

    [JsonProperty("owner")] public Entities.IdentityRef Owner { get; set; }

    public string OwnerId { get; set; }

    [JsonProperty("comment")] public string Comment { get; set; }

    [JsonProperty("createdDate")] public string CreatedDate { get; set; }

    [JsonProperty("commentTruncated")] public bool CommentTruncated { get; set; }

    [JsonProperty("url")] public string Url { get; set; }

    [JsonProperty("threads")] public List<Entities.Discussion.Thread> Threads { get; set; }

    [JsonProperty("workItems")] public List<AssociatedWorkItem> WorkItems { get; set; }
}