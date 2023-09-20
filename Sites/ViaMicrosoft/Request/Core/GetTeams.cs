using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace Ban3.Sites.ViaMicrosoft.Request.Core
{
    public class GetTeams
            : MultiPageQuery, IRequest
    {
        public string Method() => "GET";

        public string Resource()
            => Enums.APIResource.Teams.ToAPIResourceString( ProjectId );

        public string JsonBody() => null;

        public string ProjectId { get; set; }

        /// <summary>
        /// A value indicating whether or not to
        /// expand Identity information in the result WebApiTeam object.
        /// </summary>
        [JsonProperty( "$expandIdentity" )]
        public bool ExpandIdentity { get; set; }

        /// <summary>
        /// If true, then return all teams requesting user is member.
        /// Otherwise return all teams user has read access.
        /// </summary>
        [JsonProperty( "$mine" )]
        public bool Mine { get; set; }
    }
}