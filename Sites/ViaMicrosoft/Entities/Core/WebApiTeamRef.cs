using Newtonsoft.Json;
using Ban3.Infrastructures.DataPersist.Attributes;
using Ban3.Infrastructures.DataPersist.Entities;

namespace Ban3.Sites.ViaMicrosoft.Entities.Core;

/// <summary>
/// 
/// </summary>
[TableIs("WebApiTeam", "WebApiTeam", true)]
public class WebApiTeamRef
    : BaseEntity
{
    /// <summary>
    /// Team(Identity) Guid.A Team Foundation ID.
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; }

    /// <summary>
    /// Team name
    /// </summary>

    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    ///  Team REST API Url
    /// </summary>

    [JsonProperty("url")]
    public string Url { get; set; }

    public override string KeyValue() => Id;
}