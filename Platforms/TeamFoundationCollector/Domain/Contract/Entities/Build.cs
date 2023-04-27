using Newtonsoft.Json;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Newtonsoft.Json.Converters;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities
{
    /// <summary>
    /// Data representation of a build.
    /// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/builds/get?view=azure-devops-rest-7.0#build
    /// </summary>
    public class Build
    {
        /// <summary>
        /// The class to represent a collection of REST reference links.
        /// </summary>
        [JsonProperty("_links")]
        public ReferenceLinks? Links { get; set; }

        /// <summary>
        /// The agent specification for the build.
        /// </summary>
        [JsonProperty("agentSpecification")]
        public AgentSpecification? AgentSpecification { get; set; }
        
        /// <summary>
        /// The build number/name of the build.
        /// </summary>
        [JsonProperty("buildNumber")]
        public string BuildNumber { get; set; } = string.Empty;

        /// <summary>
        /// The build number revision.
        /// </summary>
        [JsonProperty("buildNumberRevision")]
        public int BuildNumberRevision { get; set; }

        /// <summary>
        /// The build controller.
        /// This is only set if the definition type is Xaml.
        /// </summary>
        [JsonProperty("controller")]
        public BuildController? Controller { get; set; }

        /// <summary>
        /// The definition associated with the build.
        /// </summary>
        [JsonProperty("definition")]
        public DefinitionReference? Definition { get; set; }

        /// <summary>
        /// Indicates whether the build has been deleted.
        /// </summary>
        [JsonProperty("deleted")]
        public bool Deleted { get; set; }

        /// <summary>
        /// The identity of the process or person that deleted the build.
        /// </summary>
        [JsonProperty("deletedBy")]
        public IdentityRef? DeletedBy { get; set; }

        /// <summary>
        /// The date the build was deleted.
        /// </summary>
        [JsonProperty("deletedDate")]
        public string DeletedDate { get; set; } = string.Empty;

        /// <summary>
        /// The description of how the build was deleted.
        /// </summary>
        [JsonProperty("deletedReason")]
        public string DeletedReason { get; set; } = string.Empty;

        /// <summary>
        /// A list of demands that represents the agent capabilities required by this build.
        /// </summary>
        [JsonProperty("demands")]
        public List<Demand>? Demands { get; set; }

        /// <summary>
        /// The time that the build was completed.
        /// </summary>
        [JsonProperty("finishTime")]
        public string FinishTime { get; set; } = string.Empty;

        /// <summary>
        /// The ID of the build.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// The identity representing the process or person that last changed the build.
        /// </summary>
        [JsonProperty("lastChangedBy")]
        public IdentityRef? LastChangedBy { get; set; }

        /// <summary>
        /// The date the build was last changed.
        /// </summary>
        [JsonProperty("lastChangedDate")]
        public string LastChangedDate { get; set; } = string.Empty;

        /// <summary>
        /// Information about the build logs.
        /// </summary>
        [JsonProperty("logs")]
        public BuildLogReference? Logs { get; set; }

        /// <summary>
        /// The orchestration plan for the build.
        /// </summary>
        [JsonProperty("orchestrationPlan")]
        public TaskOrchestrationPlanReference? OrchestrationPlan { get; set; }

        /// <summary>
        /// The parameters for the build.
        /// </summary>
        [JsonProperty("parameters")]
        public string Parameters { get; set; } = string.Empty;

        /// <summary>
        /// Orchestration plans associated with the build (build, cleanup)
        /// </summary>
        [JsonProperty("plans")]
        public List<TaskOrchestrationPlanReference>? Plans { get; set; }

        /// <summary>
        /// The build's priority.
        /// </summary>
        [JsonProperty("priority")]
        [JsonConverter(typeof(StringEnumConverter))]
        public QueuePriority Priority { get; set; }

        /// <summary>
        /// The team project.
        /// </summary>
        [JsonProperty("project")]
        public TeamProjectReference? Project { get; set; }

        /// <summary>
        /// The class represents a property bag as a collection of key-value pairs.
        /// Values of all primitive types (any type with a TypeCode != TypeCode.Object) except for DBNull are accepted.
        /// Values of type Byte[], Int32, Double, DateType and String preserve their type,
        /// other primitives are retuned as a String. Byte[] expected as base64 encoded string.
        /// </summary>
        [JsonProperty("properties")]
        public PropertiesCollection? Properties { get; set; }

        /// <summary>
        /// The quality of the xaml build (good, bad, etc.)
        /// </summary>
        [JsonProperty("quality")]
        public string Quality { get; set; } = string.Empty;

        /// <summary>
        /// The queue.
        /// This is only set if the definition type is Build.
        /// WARNING: this field is deprecated and does not corresponds to the jobs queues.
        /// </summary>
        [JsonProperty("queue")]
        public AgentPoolQueue? Queue { get; set; }

        /// <summary>
        /// Additional options for queueing the build.
        /// 
        /// </summary>
        [JsonProperty("queueOptions")]
        [JsonConverter(typeof(StringEnumConverter))]
        public QueueOptions QueueOptions { get; set; }

        /// <summary>
        /// The current position of the build in the queue.
        /// </summary>
        [JsonProperty("queuePosition")]
        public int QueuePosition { get; set; }

        /// <summary>
        /// The time that the build was queued.
        /// </summary>
        [JsonProperty("queueTime")]
        public string QueueTime { get; set; } = string.Empty;

        /// <summary>
        /// The reason that the build was created.
        /// </summary>
        [JsonProperty("reason")]
        [JsonConverter(typeof(StringEnumConverter))]
        public BuildReason Reason { get; set; }

        /// <summary>
        /// The repository.
        /// </summary>
        [JsonProperty("repository")]
        public BuildRepository? Repository { get; set; }

        /// <summary>
        /// The identity that queued the build.
        /// </summary>
        [JsonProperty("requestedBy")]
        public IdentityRef? RequestedBy { get; set; }

        /// <summary>
        /// The identity on whose behalf the build was queued.
        /// </summary>
        [JsonProperty("requestedFor")]
        public IdentityRef? RequestedFor { get; set; }

        /// <summary>
        /// The build result.
        /// </summary>
        [JsonProperty("result")]
        [JsonConverter(typeof(StringEnumConverter))]
        public BuildResult Result { get; set; }

        /// <summary>
        /// Indicates whether the build is retained by a release.
        /// </summary>
        [JsonProperty("retainedByRelease")]
        public bool RetainedByRelease { get; set; }

        /// <summary>
        /// The source branch.
        /// </summary>
        [JsonProperty("sourceBranch")]
        public string SourceBranch { get; set; } = string.Empty;

        /// <summary>
        /// The source version.
        /// </summary>
        [JsonProperty("sourceVersion")]
        public string SourceVersion { get; set; } = string.Empty;

        /// <summary>
        /// The time that the build was started.
        /// </summary>
        [JsonProperty("startTime")]
        public string StartTime { get; set; } = string.Empty;

        /// <summary>
        /// The status of the build.
        /// </summary>
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public BuildStatus Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("tags")]
        public List<string>? Tags { get; set; }

        /// <summary>
        /// Parameters to template expression evaluation
        /// </summary>
        [JsonProperty("templateParameters")]
        public object? TemplateParameters { get; set; }

        /// <summary>
        /// Sourceprovider-specific information about what triggered the build
        /// </summary>
        [JsonProperty("triggerInfo")]
        public object? TriggerInfo { get; set; }

        /// <summary>
        /// The build that triggered this build via a Build completion trigger.
        /// </summary>
        [JsonProperty("triggeredByBuild")]
        public Build? TriggeredByBuild { get; set; }

        /// <summary>
        /// The URI of the build.
        /// </summary>
        [JsonProperty("uri")]
        public string Uri { get; set; } = string.Empty;

        /// <summary>
        /// The REST URL of the build.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; } = string.Empty;

        /// <summary>
        /// Represents the result of validating a build request.
        /// </summary>
        [JsonProperty("validationResults")]
        public List<BuildRequestValidationResult>? ValidationResults { get; set; }
    }
}
