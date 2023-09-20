using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Sites.ViaMicrosoft.Request.Core
{
    public class GetTeamMembers
            : MultiPageQuery, IRequest
    {
        public string Method() => "GET";

        public string Resource()
            => Enums.APIResource.TeamMembers.ToAPIResourceString( ProjectId, TeamId );

        public string JsonBody() => null;

        public string ProjectId { get; set; }

        public string TeamId { get; set; }
    }
}