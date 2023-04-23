﻿using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// Metadata for a shelveset.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/tfvc/shelvesets/get?view=azure-devops-rest-7.0#tfvcshelveset
/// </summary>
public class TfvcShelveset
:TfvcShelvesetRef
{
    /// <summary>
    /// List of changes.
    /// </summary>
    [JsonProperty("changes")]
    public List<TfvcChange>? Changes { get; set; }

    /// <summary>
    /// List of checkin notes.
    /// </summary>
    [JsonProperty("notes")]
    public List<CheckinNote>? Notes { get; set; }

    /// <summary>
    /// Policy override information if applicable.
    /// </summary>
    [JsonProperty("policyOverride")]
    public TfvcPolicyOverrideInfo? PolicyOverride { get; set; }

    /// <summary>
    /// List of associated workitems.
    /// </summary>
    [JsonProperty("workItems")]
    public List<AssociatedWorkItem>? WorkItems { get; set; }
}