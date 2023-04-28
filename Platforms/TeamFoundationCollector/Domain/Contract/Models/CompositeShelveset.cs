using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models;

public class CompositeShelveset
{
    public CompositeShelveset() { }

    public CompositeShelveset(TfvcShelvesetRef shelvesetRef)
    {
        Id = shelvesetRef.Id;
        CreatedDate = shelvesetRef.CreatedDate;
        Comment = shelvesetRef.Comment;
    }

    [JsonProperty("id")] public string Id { get; set; } = string.Empty;

    [JsonProperty("createdDate")] public string CreatedDate { get; set; } = string.Empty;

    [JsonProperty("comment")] public string Comment { get; set; } = string.Empty;

    [JsonProperty("threads")] public List<CompositeThread>? Threads { get; set; }
}