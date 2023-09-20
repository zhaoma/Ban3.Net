using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

using Newtonsoft.Json;

using Ban3.Infrastructures.DataPersist.Attributes;

namespace Ban3.Sites.ViaMicrosoft.Entities.Core
{
    [TableIs( "TeamProject", "TeamProject", true, false )]
    public class TeamProject
            : _BaseEntity
    {
        /// <summary>
        /// Project identifier.
        /// </summary>
        [JsonProperty( "id" )]
        public string Id { get; set; }

        /// <summary>
        /// Project name.
        /// </summary>
        [JsonProperty( "name" )]
        public string Name { get; set; }

        /// <summary>
        /// The project's description (if any).
        /// </summary>
        [JsonProperty( "description" )]
        public string Description { get; set; }

        /// <summary>
        /// Project revision.
        /// </summary>
        [JsonProperty( "revision" )]
        public long Revision { get; set; }

        /// <summary>
        /// Url to the full version of the object.
        /// </summary>
        [JsonProperty( "url" )]
        public string Url { get; set; }

        /// <summary>
        /// Project state.
        /// </summary>
        [JsonProperty( "state" )]
        public Enums.ProjectState State { get; set; }

        /// <summary>
        /// Project visibility.
        /// </summary>
        [JsonProperty( "visibility" )]
        public Enums.ProjectVisibility Visibility { get; set; }

        /// <summary>
        /// Project last update time.
        /// </summary>
        [JsonProperty( "lastUpdateTime" )]
        public string LastUpdateTime { get; set; }

        /// <summary>
        /// Url to default team identity imageoverride string KeyValue()       [JsonProperty( "defaultTeamImageUrl" )]
        public string DefaultTeamImageUrl { get; set; }
    }
}