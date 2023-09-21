using System;
using System.Collections.Generic;
using System.Text;
using Ban3.Sites.ViaMicrosoft.Enums;
using Newtonsoft.Json;

namespace Ban3.Sites.ViaMicrosoft.Request.Core;

public class GetTeams
    : MultiPageQuery
{
    public string ProjectId { get; set; } = string.Empty;

    /// <summary>
    /// A value indicating whether or not to
    /// expand Identity information in the result WebApiTeam object.
    /// </summary>
    [JsonProperty("$expandIdentity")]
    public bool ExpandIdentity { get; set; }

    /// <summary>
    /// If true, then return all teams requesting user is member.
    /// Otherwise return all teams user has read access.
    /// </summary>
    [JsonProperty("$mine")]
    public bool Mine { get; set; }

    public GetTeams()
    {
        Url=APIResource.Teams.ToAPIResourceString(ProjectId);
    }
}