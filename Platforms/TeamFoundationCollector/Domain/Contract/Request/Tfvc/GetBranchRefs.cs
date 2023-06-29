﻿using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Tfvc;

public class GetBranchRefs
    : PresetRequest, IRequest
{
    /// <summary>
    /// Full path to the branch.
    /// Default: $/
    /// Examples: $/, $/MyProject, $/MyProject/SomeFolder.
    /// </summary>
    [JsonProperty("scopePath")]
    public string ScopePath { get; set; } = "$/";

    /// <summary>
    /// Return deleted branches.
    /// Default: False
    /// </summary>
    [JsonProperty("includeDeleted")]
    public bool IncludeDeleted { get; set; } = false;

    /// <summary>
    /// Return links.
    /// Default: False
    /// </summary>
    [JsonProperty("includeLinks")]
    public bool IncludeLinks { get; set; } = false;
    
    public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/tfvc/branches";

    //public string RequestQuery() => $"?scopePath={ScopePath}&includeDeleted={IncludeDeleted}&includeLinks={IncludeLinks}&api-version={ApiVersion}";

    
}