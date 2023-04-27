using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// A signed url allowing limited-time anonymous access to private resources.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/pipelines/logs/get?view=azure-devops-rest-7.0#signedurl
/// </summary>
public class SignedUrl
{
    /// <summary>
    /// Timestamp when access expires.
    /// </summary>
    [JsonProperty("signatureExpires")]
    public string SignatureExpires { get; set; } = string.Empty;

    /// <summary>
    /// The URL to allow access to.
    /// </summary>
    [JsonProperty("url")]
    public string Url { get; set; } = string.Empty;
}
