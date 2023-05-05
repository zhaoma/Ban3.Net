using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// Information on the policy override.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/tfvc/changesets/get?view=azure-devops-rest-7.0#tfvcpolicyoverrideinfo
/// </summary>
public class TfvcPolicyOverrideInfo
{
    /// <summary>
    /// Overidden policy comment.
    /// </summary>
    [JsonProperty("comment")]
    public string Comment { get; set; } = string.Empty;

    /// <summary>
    /// Information on the failed policy that was overridden.
    /// </summary>
    [JsonProperty("policyFailures")]
    public List<TfvcPolicyFailureInfo>? PolicyFailures { get; set; } 
}