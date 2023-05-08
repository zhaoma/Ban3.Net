using System.Collections.Generic;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Extensions;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models.TfvcReports;

public class CompositeChangeset
{
    public CompositeChangeset()
    {
    }

    public CompositeChangeset(TfvcChangesetRef changesetRef)
    {
        Id = changesetRef.ChangesetId;
        FileId = changesetRef.ChangesetId + "";
        CreatedDate = changesetRef.CreatedDate;
        Comment = changesetRef.Comment;
        if (changesetRef.Author != null)
        {
            AuthorGuid = changesetRef.Author.Id;
            AuthorName = changesetRef.Author.DisplayName.ShowName();
        }
    }

    [JsonProperty("Id")] public int Id { get; set; }

    [JsonProperty("fileId")]
    public string FileId { get; set; } = string.Empty;

    [JsonProperty("authorGuid")]
    public string AuthorGuid { get; set; } = string.Empty;

    [JsonProperty("authorName")] public string AuthorName { get; set; } = string.Empty;

    [JsonProperty("createdDate")] public string CreatedDate { get; set; } = string.Empty;

    [JsonProperty("comment")] public string Comment { get; set; } = string.Empty;

    [JsonProperty("threads")] public List<CompositeThread>? Threads { get; set; }
}
