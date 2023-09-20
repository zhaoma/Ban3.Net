using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

using Ban3.Sites.ViaMicrosoft.Enums;

namespace Ban3.Sites.ViaMicrosoft.Request.Core
{
    public class GetProjects
            : MultiPageQuery, IRequest
    {
        public string Method() => "GET";

        public string Resource()
            => Enums.APIResource.Projects.ToAPIResourceString();

        public string JsonBody() => null;

        [JsonProperty( "continuationToken" )]
        public string ContinuationToken { get; set; }

        [JsonProperty( "getDefaultTeamImageUrl" )]
        public bool GetDefaultTeamImageUrl { get; set; }

        /// <summary>
        /// Filter on team projects in a specific team project state (default: WellFormed).
        /// </summary>
        [JsonProperty( "stateFilter" )]
        public ProjectState StateFilter { get; set; }
    }
}