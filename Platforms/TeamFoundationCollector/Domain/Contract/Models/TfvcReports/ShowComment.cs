using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models.TfvcReports;

public class ShowComment
{

    public string Status { get; set; } = string.Empty;

    [JsonProperty("authorGuid")]
    public string AuthorGuid { get; set; } = string.Empty;

    [JsonProperty("authorName")]
    public string AuthorName { get; set; } = string.Empty;

    [JsonProperty("content")]
    public string Content { get; set; } = string.Empty;

    [JsonProperty("publishedDate")]
    public string PublishedDate { get; set; } = string.Empty;

}