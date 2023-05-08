using System.Collections.Generic;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Extensions;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models.TfvcReports;

public class CompositeShelveset
{
    public CompositeShelveset()
    {
    }

    public CompositeShelveset(TfvcShelvesetRef shelvesetRef)
    {
        Id = shelvesetRef.Name;
        FileId = shelvesetRef.Id.MD5String();
        CreatedDate = shelvesetRef.CreatedDate;
        Comment = shelvesetRef.Comment;
        if (shelvesetRef.Owner != null)
        {
            AuthorGuid = shelvesetRef.Owner.Id;
            AuthorName = shelvesetRef.Owner.DisplayName.ShowName();
        }
    }

    [JsonProperty("id")] public string Id { get; set; } = string.Empty;

    [JsonProperty("fileId")]
    public string FileId { get; set; } = string.Empty;

    [JsonProperty("authorGuid")]
    public string AuthorGuid { get; set; } = string.Empty;

    [JsonProperty("authorName")] public string AuthorName { get; set; } = string.Empty;

    [JsonProperty("createdDate")] public string CreatedDate { get; set; } = string.Empty;

    [JsonProperty("comment")] public string Comment { get; set; } = string.Empty;

    [JsonProperty("threads")] public List<CompositeThread>? Threads { get; set; }
}