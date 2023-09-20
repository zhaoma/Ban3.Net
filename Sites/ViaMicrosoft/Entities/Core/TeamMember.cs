using Newtonsoft.Json;

using Ban3.Infrastructures.DataPersist.Attributes;
using Ban3.Infrastructures.DataPersist.Entities;

namespace Ban3.Sites.ViaMicrosoft.Entities.Core;

[TableIs("TeamMember", "TeamMember", true, "msData")]
public class TeamMember
    : BaseEntity
{
    [FieldIs(ColumnIndex = 1, ColumnName = "TeamId", Key = true, NotForUpdate = true, Subject = "TEAM ID")]
    public string TeamId { get; set; } = string.Empty;

    [JsonProperty("identity")] public Identity Identity { get; set; }

    public string IdentityId { get; set; } = string.Empty;

    [JsonProperty("isTeamAdmin")] public bool IsTeamAdmin { get; set; }
}