using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/queue?view=azure-devops-rest-7.0#identityref
/// </summary>
public class IdentityRef
{

    [JsonProperty("_links")] 
    public ReferenceLinks Links { get; set; }

    /// <summary>
    /// The descriptor is the primary way to reference the graph subject while the system is running.
    /// This field will uniquely identify the same graph subject across both Accounts and Organizations.
    /// </summary>
    public string Descriptor { get; set; }

    /// <summary>
    /// This is the non-unique display name of the graph subject.
    /// To change this field, you must alter its value in the source provider.
    /// </summary>
    public string DisplayName { get; set; }

    public string Id { get; set; }

    public bool IsDeletedInOrigin { get; set; }

    /// <summary>
    /// This url is the full route to the source resource of this graph subject.
    /// </summary>
    public string Url { get; set; }
}