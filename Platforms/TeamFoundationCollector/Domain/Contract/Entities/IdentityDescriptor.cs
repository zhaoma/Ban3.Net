using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// An Identity descriptor is a wrapper for the identity type (Windows SID, Passport) along with a unique identifier such as the SID or PUID.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/ims/identities/read-identities?view=azure-devops-rest-7.0&tabs=HTTP#identitydescriptor
/// </summary>
public class IdentityDescriptor
{
    /// <summary>
    /// The unique identifier for this identity, not exceeding 256 chars, which will be persisted.
    /// </summary>
    [JsonProperty("identifier")]
    public string Identifier { get; set; } = string.Empty;

    /// <summary>
    /// Type of descriptor (for example, Windows, Passport, etc.).
    /// </summary>
    [JsonProperty("identityType")]
    public string IdentityType { get; set; } = string.Empty;
}