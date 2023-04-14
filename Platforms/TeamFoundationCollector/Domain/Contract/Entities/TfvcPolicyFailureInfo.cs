using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// Policy failure information.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/tfvc/changesets/get?view=azure-devops-rest-7.0&tabs=HTTP#tfvcpolicyfailureinfo
/// </summary>
public class TfvcPolicyFailureInfo
{
    /// <summary>
    /// Policy failure message.
    /// </summary>
    [JsonProperty("message")]
    public string Message { get; set; }

    /// <summary>
    /// Name of the policy that failed.
    /// </summary>
    [JsonProperty("policyName")]
    public string PolicyName { get; set; }
}