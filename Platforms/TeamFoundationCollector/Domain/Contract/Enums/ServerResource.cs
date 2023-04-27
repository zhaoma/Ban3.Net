using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Attributes;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums
{
    /// <summary>
    /// 资源
    /// </summary>
    public enum ServerResource
    {
        ArtifactsPackageMavenDeleteVersion,
        ArtifactsPackageMavenDeleteVersionFromRecycleBin,
        ArtifactsPackageMavenDownload,
        ArtifactsPackageMavenGetVersion,
        ArtifactsPackageMavenGetVersionFromRecycleBin,
        ArtifactsPackageMavenRestoreVersionFromRecycleBin,

        ArtifactsPackageNpmDeleteVersionFromRecycleBin,
        ArtifactsPackageNpmDeleteScopedVersionFromRecycleBin,
        ArtifactsPackageNpmDownload,
        ArtifactsPackageNpmDownloadScoped,
        ArtifactsPackageNpmGetReadme,
        ArtifactsPackageNpmGetVersion,
        ArtifactsPackageNpmGetVersionFromRecycleBin,
        ArtifactsPackageNpmGetScopedReadme,
        ArtifactsPackageNpmGetScopedVersion,
        ArtifactsPackageNpmGetScopedVersionFromRecycleBin,
        ArtifactsPackageNpmRestoreVersionFromRecycleBin,
        ArtifactsPackageNpmRestoreScopedVersionFromRecycleBin,
        ArtifactsPackageNpmUnpublish,
        ArtifactsPackageNpmUnpublishScoped,
        ArtifactsPackageNpmUpdate,
        ArtifactsPackageNpmUpdateBatch,
        ArtifactsPackageNpmUpdateScoped,
        
        ArtifactsPackageNuGetDeleteVersion,
        ArtifactsPackageNuGetDeleteVersionFromRecycleBin,
        ArtifactsPackageNuGetDownload,
        ArtifactsPackageNuGetGetVersion,
        ArtifactsPackageNuGetGetVersionFromRecycleBin,
        ArtifactsPackageNuGetRestoreVersionFromRecycleBin,
        ArtifactsPackageNuGetUpdate,
        ArtifactsPackageNuGetUpdateBatch,

        /// <summary>
        /// Associates an artifact with a build.
        /// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/artifacts/create?view=azure-devops-server-rest-6.0
        /// Response BuildArtifact ; Media Types: "application/zip", "application/json"
        /// </summary>
        BuildArtifactsCreate,

        /// <summary>
        /// Gets a specific artifact for a build.
        /// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/artifacts/get-artifact?view=azure-devops-server-rest-6.0
        /// Response BuildArtifact ; Media Types: "application/zip", "application/json"
        /// </summary>
        BuildArtifactsGetArtifact,

        /// <summary>
        /// Gets a file from the build.
        /// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/artifacts/get-file?view=azure-devops-server-rest-6.0
        /// Response string Media Types: "application/octet-stream"
        /// </summary>
        BuildArtifactsGetFile,

        /// <summary>
        /// Gets all artifacts for a build.
        /// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/artifacts/list?view=azure-devops-server-rest-6.0
        /// Response BuildArtifact[]
        /// </summary>
        BuildArtifactsList,


        BuildAttachmentsGet,


        BuildAttachmentsList,

        BuildAuthorizedresources,
        
        BuildCreateDefinition,
        BuildDeleteBuild,
        BuildDeleteDefinition,
        BuildGetBuild,
        BuildGetBuildChanges,
        BuildGetBuildLog,
        BuildGetBuildLogs,
        BuildGetBuildWorkItemsRefsFromCommits,
        BuildGetBuildWorkItemsRefs,
        BuildGetChangesBetweenBuilds,
        BuildGetController,
        BuildGetDefinition,
        BuildGetDefinitionRevisions,
        BuildGetTimeline,
        BuildGetWorkItemsBetweenBuilds,
        BuildListBuilds,
        BuildListControllers,
        BuildListDefinitions,
        BuildQueueBuild,
        BuildRestoreDefinition,
        BuildUpdateBuild,
        BuildUpdateBuilds,
        BuildUpdateDefinition,

        BuildGetReport,

        CoreProjectsCreate,
        CoreProjectsDelete,
        CoreProjectsGet,
        CoreProjectsGetProperties,
        CoreProjectsList,
        CoreProjectsSetProperties,
        CoreProjectsUpdate,

        CoreCreateTeam,
        CoreDeleteTeam,
        CoreGetPortrait,
        CoreGetTeam,
        CoreGetTeamMembers,
        CoreGetTeams,
        CoreUpdateTeam,

        /// <summary>
        /// GET https://{instance}/{collection}/{project}/_apis/tfvc/branches?path={path}&api-version=6.0
        /// GET https://{instance}/{collection}/{project}/_apis/tfvc/branches?path={path}&includeParent={includeParent}&includeChildren={includeChildren}&api-version=6.0
        /// GET https://{instance}/{collection}/{project}/_apis/tfvc/branches?scopePath={scopePath}&api-version=6.0
        /// GET https://{instance}/{collection}/{project}/_apis/tfvc/branches?scopePath={scopePath}&includeDeleted={includeDeleted}&includeLinks={includeLinks}&api-version=6.0
        /// GET https://{instance}/{collection}/{project}/_apis/tfvc/branches?api-version=6.0
        /// GET https://{instance}/{collection}/{project}/_apis/tfvc/branches?includeParent={includeParent}&includeChildren={includeChildren}&includeDeleted={includeDeleted}&includeLinks={includeLinks}&api-version=6.0
        /// </summary>

        [ResourceDeclare(typeof(Request.Tfvc.CreateChangeset), typeof(Response.Tfvc.CreateChangesetResult))]
        TfvcCreateChangeset,

        [ResourceDeclare(typeof(Request.Tfvc.GetBatchedChangesets), typeof(Response.Tfvc.GetBatchedChangesetsResult))]
        TfvcGetBatchedChangesets,
        
        TfvcGetBatchedItems,

        TfvcGetBranch,

        TfvcGetBranches,

        TfvcGetBranchRefs,

        [ResourceDeclare(typeof(Request.Tfvc.GetChangeset), typeof(Response.Tfvc.GetChangesetResult))]
        TfvcGetChangeset,

        TfvcGetChangesetChanges,

        TfvcGetChangesets,

        TfvcGetChangesetWorkItems,
        
        TfvcGetItem,

        TfvcGetItems,

        TfvcGetLabel,

        TfvcGetLabelItems,

        TfvcGetLabels,

        TfvcGetShelveset,

        TfvcGetShelvesetChanges,
        
        TfvcGetShelvesets,

        TfvcGetShelvesetWorkItems,
        
        DiscussionGetThread,
        DiscussionGetThreads,

        PipelinesCreatePipeline,
        PipelinesGetLog,
        PipelinesGetPipeline,
        PipelinesGetRun,
        PipelinesListLogs,
        PipelinesListPipelines,
        PipelinesListRuns,
        PipelinesRunPipeline,

        WorkItemTrackingSendMail
    }
}
