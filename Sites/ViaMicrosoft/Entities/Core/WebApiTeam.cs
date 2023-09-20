using Newtonsoft.Json;

using Ban3.Infrastructures.DataPersist.Attributes;

namespace Ban3.Sites.ViaMicrosoft.Entities.Core;

[TableIs("WebApiTeam", "WebApiTeam", true, "msData")]
public class WebApiTeam
    : WebApiTeamRef
{
    [JsonProperty("description")] public string Description { get; set; }

    [JsonProperty("identityUrl")] public string IdentityUrl { get; set; }

    [JsonProperty("projectName")] public string ProjectName { get; set; }

    [JsonProperty("projectId")] public string ProjectId { get; set; }

    public bool Followed { get; set; }
}