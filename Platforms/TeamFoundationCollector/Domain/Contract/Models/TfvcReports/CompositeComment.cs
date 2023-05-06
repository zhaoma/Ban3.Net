using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Extensions;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models.TfvcReports;

public class CompositeComment
{
    public CompositeComment() { }

    public CompositeComment(DiscussionComment comment)
    {
        Id = comment.Id;
        if (comment.Author != null)
        {
            AuthorGuid = comment.Author.Id;
            AuthorName = comment.Author.DisplayName.ShowName();
        }

        Content = comment.Content;
        PublishedDate = comment.PublishedDate;
        LastUpdatedDate = comment.LastUpdatedDate;
    }

    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("authorGuid")]
    public string AuthorGuid { get; set; } = string.Empty;

    [JsonProperty("authorName")]
    public string AuthorName { get; set; } = string.Empty;

    [JsonProperty("content")]
    public string Content { get; set; } = string.Empty;

    [JsonProperty("publishedDate")]
    public string PublishedDate { get; set; } = string.Empty;

    [JsonProperty("lastUpdatedDate")]
    public string LastUpdatedDate { get; set; } = string.Empty;

}