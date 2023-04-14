﻿using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// Metadata for a changeset.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/tfvc/changesets/get-batched-changesets?view=azure-devops-rest-7.0&tabs=HTTP#tfvcchangesetref
/// </summary>
public class TfvcChangesetRef
{
    /// <summary>
    /// A collection of REST reference links.
    /// </summary>
    [JsonProperty("_links")]
    public ReferenceLinks Links { get; set; }
    
    /// <summary>
    /// Alias or display name of user
    /// </summary>
    [JsonProperty("author")]
    public IdentityRef Author { get; set; }

    /// <summary>
    /// Id of the changeset.
    /// </summary>
    [JsonProperty("changesetId")]
    public int ChangesetId { get; set; }
    
    /// <summary>
    /// Alias or display name of user
    /// </summary>
    [JsonProperty("checkedInBy")]
    public IdentityRef CheckedInBy { get; set; }
    
    /// <summary>
    /// Comment for the changeset.
    /// </summary>
    [JsonProperty("comment")]
    public string Comment { get; set; }

    /// <summary>
    /// Was the Comment result truncated?
    /// </summary>
    [JsonProperty("commentTruncated")]
    public bool CommentTruncated { get; set; }

    /// <summary>
    /// Creation date of the changeset.
    /// </summary>
    [JsonProperty("createdDate")]
    public string CreatedDate { get; set; }

    /// <summary>
    /// URL to retrieve the item.
    /// </summary>
    [JsonProperty("url")]
    public string Url { get; set; }
}