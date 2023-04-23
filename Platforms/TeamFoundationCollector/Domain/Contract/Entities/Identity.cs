using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/ims/identities/read-identities?view=azure-devops-rest-7.0#identity
/// </summary>
public class Identity
{
    /// <summary>
    /// The custom display name for the identity (if any). Setting this property to an empty string will clear the existing custom display name.
    /// Setting this property to null will not affect the existing persisted value (since null values do not get sent over the wire or to the database)
    /// </summary>
    [JsonProperty("customDisplayName")]
    public string CustomDisplayName { get; set; } = string.Empty;

    /// <summary>
    /// An Identity descriptor is a wrapper for the identity type (Windows SID, Passport) along with a unique identifier such as the SID or PUID.
    /// </summary>
    [JsonProperty("descriptor")]
    public IdentityDescriptor? Descriptor { get; set; }

    /// <summary>
    /// Identity Identifier. Also called Storage Key, or VSID
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// True if the identity has a membership in any Azure Devops group in the organization.
    /// </summary>
    [JsonProperty("isActive")]
    public bool IsActive { get; set; }

    /// <summary>
    /// True if the identity is a group.
    /// </summary>
    [JsonProperty("isContainer")]
    public bool IsContainer { get; set; }

    [JsonProperty("masterId")]
    public string MasterId { get; set; } = string.Empty;

    /// <summary>
    /// Id of the members of the identity (groups only).
    /// </summary>
    [JsonProperty("memberIds")]
    public IEnumerable<string>? MemberIds { get; set; }

    /// <summary>
    /// An Identity descriptor is a wrapper for the identity type (Windows SID, Passport) along with a unique identifier such as the SID or PUID.
    /// </summary>
    [JsonProperty("memberOf")]
    public IEnumerable<IdentityDescriptor>? MemberOf { get; set; }

    /// <summary>
    /// An Identity descriptor is a wrapper for the identity type (Windows SID, Passport) along with a unique identifier such as the SID or PUID.
    /// </summary>
    [JsonProperty("members")]
    public IEnumerable<IdentityDescriptor>? Members { get; set; }

    [JsonProperty("metaTypeId")]
    public int MetaTypeId { get; set; }

    /// <summary>
    /// The class represents a property bag as a collection of key-value pairs.
    /// Values of all primitive types (any type with a TypeCode != TypeCode.Object) except for DBNull are accepted.
    /// Values of type Byte[], Int32, Double, DateType and String preserve their type, other primitives are retuned as a String. Byte[] expected as base64 encoded string.
    /// </summary>
    [JsonProperty("properties")]
    public PropertiesCollection? Properties { get; set; }

    /// <summary>
    /// The display name for the identity as specified by the source identity provider.
    /// </summary>
    [JsonProperty("providerDisplayName")]
    public string ProviderDisplayName { get; set; } = string.Empty;

    [JsonProperty("resourceVersion")]
    public int ResourceVersion { get; set; }

    [JsonProperty("socialDescriptor")]
    public string SocialDescriptor { get; set; } = string.Empty;

    /// <summary>
    /// Subject descriptor of a Graph entity.
    /// </summary>
    [JsonProperty("subjectDescriptor")]
    public string SubjectDescriptor { get; set; } = string.Empty;

    [JsonProperty("uniqueUserId")]
    public int UniqueUserId { get; set; }
}