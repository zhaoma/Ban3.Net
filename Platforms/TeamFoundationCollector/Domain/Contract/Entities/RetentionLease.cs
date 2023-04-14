using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;

/// <summary>
/// A valid retention lease prevents automated systems from deleting a pipeline run.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/get-retention-leases-for-build?view=azure-devops-rest-7.0#retentionlease
/// </summary>
public class RetentionLease
{
    /// <summary>
    /// When the lease was created.
    /// </summary>
    [JsonProperty("createdOn")]
    public string CreatedOn { get; set; }

    /// <summary>
    /// The pipeline definition of the run.
    /// </summary>
    [JsonProperty("definitionId")]
    public string DefinitionId { get; set; }

    /// <summary>
    /// The unique identifier for this lease.
    /// </summary>
    [JsonProperty("leaseId")]
    public string LeaseId { get; set; }

    /// <summary>
    /// Non-unique string that identifies the owner of a retention lease.
    /// </summary>
    [JsonProperty("ownerId")]
    public string OwnerId { get; set; }

    /// <summary>
    /// If set, this lease will also prevent the pipeline from being deleted while the lease is still valid.
    /// </summary>
    [JsonProperty("protectPipeline")]
    public string ProtectPipeline { get; set; }

    /// <summary>
    /// The pipeline run protected by this lease.
    /// </summary>
    [JsonProperty("runId")]
    public string RunId { get; set; }

    /// <summary>
    /// The last day the lease is considered valid.
    /// </summary>
    [JsonProperty("validUntil")]
    public string ValidUntil { get; set; }
}