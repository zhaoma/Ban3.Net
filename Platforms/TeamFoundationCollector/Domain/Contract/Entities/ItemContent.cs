using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/tfvc/changesets/get?view=azure-devops-rest-7.0#itemcontent
/// </summary>
public class ItemContent
{
    [JsonProperty("content")]
    public string Content { get; set; } = string.Empty;

    [JsonProperty("contentType")]
    [JsonConverter(typeof(StringEnumConverter))]
    public ItemContentType ContentType { get; set; }
}