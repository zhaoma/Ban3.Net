using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models;

public class CompositeThread
{
    public CompositeThread(){}

    public CompositeThread(DiscussionThread thread)
    {
        Id=thread.Id;
        PublishedDate=thread.PublishedDate;
        LastUpdatedDate=thread.LastUpdatedDate;
        Properties = thread.ConvertedProperties;

        Comments = thread.Comments?
            .Select(o => new CompositeComment(o))
            .ToList();
    }

    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("publishedDate")]
    public string PublishedDate { get; set; } = string.Empty;

    [JsonProperty("lastUpdatedDate")]
    public string LastUpdatedDate { get; set; } = string.Empty;

    [JsonProperty("comments")]
    public List<CompositeComment>? Comments { get; set; }

    [JsonProperty("convertedProperties")]
    public DiscussionProperties? Properties { get; set; }
}