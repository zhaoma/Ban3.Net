﻿using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Tfvc;

/// <summary>
/// Retrieve Tfvc changes for a given changeset.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/tfvc/changesets/get-changeset-changes?view=azure-devops-rest-7.0
/// </summary>
public class GetChangesetChanges
    : PresetRequest, IRequest
{
    public string Method { get; set; } = "Get";
    
    /// <summary>
    /// ID of the changeset. Default: null
    /// </summary>
    [JsonProperty("id")]
    public int Id { get; set; }

    /// <summary>
    /// Number of results to skip.
    /// Default: null
    /// </summary>
    [JsonProperty("skip")]
    public int? Skip { get; set; }

    /// <summary>
    /// The maximum number of results to return.
    /// Default: null
    /// </summary>
    [JsonProperty("top")]
    public int? Top { get; set; }

    /// <summary>
    /// Return the next page of results.
    /// Default: null
    /// </summary>
    [JsonProperty("continuationToken")] 
    public string ContinuationToken { get; set; } = string.Empty;
    
    public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/tfvc/changesets/{Id}/changes";

    public string RequestQuery()
    {
        var sb = new StringBuilder();

        sb.Append("?");

        if (Skip != null)
            sb.Append($"$skip={Skip}&");
        if (Top != null)
            sb.Append($"$top={Top}&");

        if (!string.IsNullOrEmpty(ContinuationToken))
            sb.Append($"continuationToken={ContinuationToken}&");

        sb.Append($"api-version={ApiVersion}");
        return sb.ToString();
    }

    public string RequestBody() =>string.Empty;
}