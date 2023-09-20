using Ban3.Infrastructures.DataPersist.Attributes;
using Ban3.Infrastructures.DataPersist.Entities;
using Newtonsoft.Json;

namespace Ban3.Sites.ViaMicrosoft.Entities;

/// <summary>
/// @TFVC..
/// </summary>
[TableIs("Identity", "Identity", true)]
public class IdentityRef
    : BaseEntity
{
    /// <summary>
    /// This is the non-unique display name of the graph subject.
    /// To change this field, you must alter its value in the source provider.
    /// </summary>
    [JsonProperty("displayName")]
    public string DisplayName { get; set; } = string.Empty;

    /// <summary>
    /// Deprecated - use Domain+PrincipalName instead
    /// </summary>
    [JsonProperty("uniqueName")]
    public string UniqueName { get; set; } = string.Empty;

    /// <summary>
    /// This url is the full route to the source resource of this graph subject.
    /// </summary>
    [JsonProperty("url")]
    public string Url { get; set; } = string.Empty;

    /// <summary>
    /// Deprecated - Available in the "avatar" entry of the IdentityRef "_links" dictionary
    /// </summary>
    [JsonProperty("imageUrl")]
    public string ImageUrl { get; set; } = string.Empty;

    [JsonProperty("changesetCount")] public int ChangesetCount { get; set; }

    [JsonProperty("shelvesetCount")] public int ShelvesetCount { get; set; }

    [JsonProperty("passRatio")] public int PassRatio { get; set; }
}