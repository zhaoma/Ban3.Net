using System.Collections.Generic;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models;

public class CompositeChangeset
{
    public CompositeChangeset(){}

    public CompositeChangeset(TfvcChangesetRef changesetRef)
    {
        Id = changesetRef.ChangesetId;
        CreatedDate = changesetRef.CreatedDate;
        Comment = changesetRef.Comment;
    }

    [JsonProperty("Id")] public int Id { get; set; }

    [JsonProperty("createdDate")] public string CreatedDate { get; set; } = string.Empty;

    [JsonProperty("comment")] public string Comment { get; set; } = string.Empty;

    [JsonProperty("threads")] public List<CompositeThread>? Threads { get; set; }
}
