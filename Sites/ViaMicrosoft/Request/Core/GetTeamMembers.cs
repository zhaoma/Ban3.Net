using Ban3.Sites.ViaMicrosoft.Enums;

namespace Ban3.Sites.ViaMicrosoft.Request.Core;

public class GetTeamMembers
    : MultiPageQuery
{
    public string ProjectId { get; set; } = string.Empty;

    public string TeamId { get; set; } = string.Empty;

    public GetTeamMembers()
    {
        Url = APIResource.TeamMembers.ToAPIResourceString(ProjectId, TeamId);
    }
}