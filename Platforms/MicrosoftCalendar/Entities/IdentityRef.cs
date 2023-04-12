using Dapper.Contrib.Extensions;

using Newtonsoft.Json;

using Ban3.Infrastructures.Common.Contracts.Attributes;
using Ban3.Infrastructures.Common.Contracts.Entities;

namespace Ban3.Infrastructures.Platforms.ViaMicrosoft.Entities
{
    /// <summary>
    /// @TFVC..
    /// </summary>
    [Table( "Identity" )]
    [TableStrategy( "Identity", "Identity", true )]
    public class IdentityRef
            : _BaseEntity
    {
        /// <summary>
        /// This is the non-unique display name of the graph subject.
        /// To change this field, you must alter its value in the source provider.
        /// </summary>
        [JsonProperty( "displayName" )]
        public string DisplayName { get; set; } = string.Empty;

        /// <summary>
        /// Deprecated - use Domain+PrincipalName instead
        /// </summary>
        [JsonProperty( "uniqueName" )]
        public string UniqueName { get; set; } = string.Empty;

        /// <summary>
        /// This url is the full route to the source resource of this graph subject.
        /// </summary>
        [JsonProperty( "url" )]
        public string Url { get; set; } = string.Empty;

        /// <summary>
        /// Deprecated - Available in the "avatar" entry of the IdentityRef "_links" dictionary
        /// </summary>
        [JsonProperty( "imageUrl" )]
        public string ImageUrl { get; set; } = string.Empty;

        public override string KeyValue() => Id;

        public override string EqualCondition()
        {
            return $"{DisplayName}:{ImageUrl}";
        }

        [Write( false )]
        [JsonProperty( "changesetCount" )]
        public int ChangesetCount { get; set; }

        [Write( false )]
        [JsonProperty( "shelvesetCount" )]
        public int ShelvesetCount { get; set; }

        [Write( false )]
        [JsonProperty( "passRatio" )]
        public int PassRatio { get; set; }
    }
}