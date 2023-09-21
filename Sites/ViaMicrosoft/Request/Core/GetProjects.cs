using Newtonsoft.Json;

using Ban3.Sites.ViaMicrosoft.Enums;

namespace Ban3.Sites.ViaMicrosoft.Request.Core;

public class GetProjects
    : MultiPageQuery
{
    [JsonProperty("continuationToken")] 
    public string ContinuationToken { get; set; }

    [JsonProperty("getDefaultTeamImageUrl")]
    public bool GetDefaultTeamImageUrl { get; set; }

    /// <summary>
    /// Filter on team projects in a specific team project state (default: WellFormed).
    /// </summary>
    [JsonProperty("stateFilter")]
    public ProjectState StateFilter { get; set; }

    public GetProjects()
    {
        Url=APIResource.Projects.ToAPIResourceString();
    }
}