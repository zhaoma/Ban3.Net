using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

public class DiscussionThread
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("artifactUri")]
    public string ArtifactUri { get; set; } = string.Empty;

    [JsonProperty("publishedDate")]
    public string PublishedDate { get; set; } = string.Empty;

    [JsonProperty("lastUpdatedDate")]
    public string LastUpdatedDate { get; set; } = string.Empty;

    [JsonProperty("comments")]
    public List<DiscussionComment>? Comments { get; set; }

    [JsonProperty("properties")]
    public Dictionary<string, TypeAndValue>? Properties { get; set; }

    [JsonProperty("convertedProperties")]
    public DiscussionProperties ConvertedProperties => new(Properties);

    [JsonProperty("commentsCount")]
    public int CommentsCount { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; } = string.Empty;

    [JsonProperty("isDeleted")]
    public bool IsDeleted { get; set; }
}
