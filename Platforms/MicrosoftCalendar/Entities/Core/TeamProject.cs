using System;
using System.Collections.Generic;
using System.Text;

using Dapper.Contrib.Extensions;

using Newtonsoft.Json;

using Ban3.Infrastructures.Common.Contracts.Attributes;
using Ban3.Infrastructures.Common.Contracts.Entities;

namespace Ban3.Infrastructures.Platforms.ViaMicrosoft.Entities.Core
{
    [Table( "TeamProject" )]
    [TableStrategy( "TeamProject", "TeamProject", true, false )]
    public class TeamProject
            : _BaseEntity
    {
        /// <summary>
        /// Project identifier.
        /// </summary>
        [ExplicitKey]
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
        [Write( false )]
        public string DefaultTeamImageUrl { get; set; }

        public override string KeyValue() => Id;

        public override string EqualCondition()
        {
            return $"{Name}:{Revision}:{State}:{Visibility}";
        }
    }
}