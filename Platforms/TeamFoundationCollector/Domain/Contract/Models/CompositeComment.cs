using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models;

public class CompositeComment
{
    public CompositeComment(){}

    public CompositeComment(DiscussionComment comment)
    {
        Id=comment.Id;
        AuthorGuid = comment.Author!=null? comment.Author.Id:string.Empty;
        Content=comment.Content;
        PublishedDate = comment.PublishedDate;
        LastUpdatedDate = comment.LastUpdatedDate;
    }

    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("authorGuid")] 
    public string AuthorGuid { get; set; } = string.Empty;
    
    [JsonProperty("content")]
    public string Content { get; set; } = string.Empty;
    
    [JsonProperty("publishedDate")]
    public string PublishedDate { get; set; } = string.Empty;

    [JsonProperty("lastUpdatedDate")]
    public string LastUpdatedDate { get; set; } = string.Empty;

}