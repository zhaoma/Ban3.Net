using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// Represents a revision of a build definition.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/definitions/get-definition-revisions?view=azure-devops-rest-7.0#builddefinitionrevision
/// </summary>
public class BuildDefinitionRevision
{
    /// <summary>
    /// The change type (add, edit, delete).
    /// </summary>
    [JsonProperty("changeType")]
    public AuditAction ChangeType { get; set; }

    /// <summary>
    /// The identity of the person or process that changed the definition.
    /// </summary>
    [JsonProperty("changedBy")]
    public IdentityRef? ChangedBy { get; set; }

    /// <summary>
    /// The date and time that the definition was changed.
    /// </summary>
    [JsonProperty("changedDate")]
    public string ChangedDate { get; set; } = string.Empty;

    /// <summary>
    /// The comment associated with the change.
    /// </summary>
    [JsonProperty("comment")]
    public string Comment { get; set; } = string.Empty;

    /// <summary>
    /// A link to the definition at this revision.
    /// </summary>
    [JsonProperty("definitionUrl")]
    public string DefinitionUrl { get; set; } = string.Empty;

    /// <summary>
    /// The name of the definition.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The revision number.
    /// </summary>
    [JsonProperty("revision")]
    public int Revision { get; set; }
}