﻿using System.Collections.Generic;
using Newtonsoft.Json;

using Ban3.Infrastructures.Common.Contracts.Attributes;

namespace Ban3.Infrastructures.Platforms.ViaMicrosoft.Entities.TFVC
{
    [TableStrategy( "Changeset", "Changeset", false )]
    public class TfvcChangeset
            : TfvcChangesetRef
    {
        public TfvcChangeset() {}

        /// <summary>
        /// Account Id of the changeset.
        /// </summary>
        [JsonProperty( "accountId" )]
        public string AccountId { get; set; }

        /// <summary>
        /// List of associated changes.
        /// </summary>
        [JsonProperty( "changes" )]
        public IEnumerable<TfvcChange> Changes { get; set; }

        /// <summary>
        /// Checkin Notes for the changeset.
        /// </summary>
        [JsonProperty( "checkinNotes" )]
        public IEnumerable<CheckinNote> CheckinNotes { get; set; }

        /// <summary>
        /// Collection Id of the changeset.
        /// </summary>
        [JsonProperty( "collectionId" )]
        public string CollectionId { get; set; }

        /// <summary>
        /// Are more changes available.
        /// </summary>
        [JsonProperty( "hasMoreChanges" )]
        public bool HasMoreChanges { get; set; }

        /// <summary>
        /// Policy Override for the changeset.
        /// </summary>
        [JsonProperty( "policyOverride" )]
        public TfvcPolicyOverrideInfo PolicyOverride { get; set; }

        /// <summary>
        /// Team Project Ids for the changeset.
        /// </summary>
        [JsonProperty( "teamProjectIds" )]
        public string[] TeamProjectIds { get; set; }

        /// <summary>
        /// URL to retrieve the item.
        /// </summary>
        [JsonProperty( "url" )]
        public string Url { get; set; }
    }
}

