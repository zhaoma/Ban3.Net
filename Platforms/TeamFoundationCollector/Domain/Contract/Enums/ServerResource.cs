using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        [ResourceDeclare("POST", "_apis/build/builds/{buildId}/artifacts?api-version=6.0")]
        BuildArtifactsCreate,

        /// <summary>
        /// Gets a specific artifact for a build.
        /// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/artifacts/get-artifact?view=azure-devops-server-rest-6.0
        /// Response BuildArtifact ; Media Types: "application/zip", "application/json"
        /// </summary>
        [ResourceDeclare("GET", "_apis/build/builds/{buildId}/artifacts?artifactName={artifactName}&api-version=6.0")]
        BuildArtifactsGetArtifact,

        /// <summary>
        /// Gets a file from the build.
        /// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/artifacts/get-file?view=azure-devops-server-rest-6.0
        /// Response string Media Types: "application/octet-stream"
        /// </summary>
        [ResourceDeclare("GET", "_apis/build/builds/{buildId}/artifacts?artifactName={artifactName}&fileId={fileId}&fileName={fileName}&api-version=6.0")]
        BuildArtifactsGetFile,

        /// <summary>
        /// Gets all artifacts for a build.
        /// https://learn.microsoft.com/en-us/rest/api/azure/devops/build/artifacts/list?view=azure-devops-server-rest-6.0
        /// Response BuildArtifact[]
        /// </summary>
        [ResourceDeclare("GET", "_apis/build/builds/{buildId}/artifacts?api-version=6.0")]
        BuildArtifactsList,


        BuildAttachmentsGet,


        BuildAttachmentsList,

        BuildAuthorizedresources,
        
        CoreProjectsCreate,
        CoreProjectsDelete,
        CoreProjectsGet,

        CoreProjectsGetProperties,

        [ResourceDeclare("Get","_apis/projects")]
        CoreProjectsList,

        CoreProjectsSetProperties,

        CoreProjectsUpdate,

        CoreTeamsCreate,
        CoreTeamsDelete,
        CoreTeamsGet,
        CoreTeamsList,
        CoreTeamsGetMembers,

        Portrait,

        /// <summary>
        /// GET https://{instance}/{collection}/{project}/_apis/tfvc/branches?path={path}&api-version=6.0
        /// GET https://{instance}/{collection}/{project}/_apis/tfvc/branches?path={path}&includeParent={includeParent}&includeChildren={includeChildren}&api-version=6.0
        /// GET https://{instance}/{collection}/{project}/_apis/tfvc/branches?scopePath={scopePath}&api-version=6.0
        /// GET https://{instance}/{collection}/{project}/_apis/tfvc/branches?scopePath={scopePath}&includeDeleted={includeDeleted}&includeLinks={includeLinks}&api-version=6.0
        /// GET https://{instance}/{collection}/{project}/_apis/tfvc/branches?api-version=6.0
        /// GET https://{instance}/{collection}/{project}/_apis/tfvc/branches?includeParent={includeParent}&includeChildren={includeChildren}&includeDeleted={includeDeleted}&includeLinks={includeLinks}&api-version=6.0
        /// </summary>
        [ResourceDeclare("Get", "_apis/tfvc/branches?api-version=6.0")]
        TfvcBranchesGet,

        TfvcChangesetsCreate,

        /// GET https://{instance}/{collection}/{project}/_apis/tfvc/changesets/{id}?api-version=6.0
        /// GET https://{instance}/{collection}/{project}/_apis/tfvc/changesets/{id}?maxChangeCount={maxChangeCount}&includeDetails={includeDetails}&includeWorkItems={includeWorkItems}&maxCommentLength={maxCommentLength}&includeSourceRename={includeSourceRename}&$skip={$skip}&$top={$top}&$orderby={$orderby}&searchCriteria.author={searchCriteria.author}&searchCriteria.followRenames={searchCriteria.followRenames}&searchCriteria.fromDate={searchCriteria.fromDate}&searchCriteria.fromId={searchCriteria.fromId}&searchCriteria.includeLinks={searchCriteria.includeLinks}&searchCriteria.itemPath={searchCriteria.itemPath}&searchCriteria.toDate={searchCriteria.toDate}&searchCriteria.toId={searchCriteria.toId}&api-version=6.0
        TfvcChangesetsGet,

        /// <summary>
        /// POST https://{instance}/{collection}/_apis/tfvc/changesetsbatch?api-version=6.0
        /// 
        /// </summary>
        TfvcChangesetsGetBatched,
        /// <summary>
        /// GET https://{instance}/{collection}/_apis/tfvc/changesets/{id}/changes?api-version=6.0
        /// GET https://{instance}/{collection}/_apis/tfvc/changesets/{id}/changes?$skip={$skip}&$top={$top}&continuationToken={continuationToken}&api-version=6.0
        /// </summary>
        TfvcChangesetsGetChanges,
        /// <summary>
        /// GET https://{instance}/{collection}/_apis/tfvc/changesets/{id}/workItems?api-version=6.0
        /// </summary>
        TfvcChangesetsGetWorkItems,

        /// <summary>
        /// GET https://{instance}/{collection}/{project}/_apis/tfvc/changesets?api-version=6.0
        /// GET https://{instance}/{collection}/{project}/_apis/tfvc/changesets?maxCommentLength={maxCommentLength}&$skip={$skip}&$top={$top}&$orderby={$orderby}&searchCriteria.author={searchCriteria.author}&searchCriteria.followRenames={searchCriteria.followRenames}&searchCriteria.fromDate={searchCriteria.fromDate}&searchCriteria.fromId={searchCriteria.fromId}&searchCriteria.includeLinks={searchCriteria.includeLinks}&searchCriteria.itemPath={searchCriteria.itemPath}&searchCriteria.toDate={searchCriteria.toDate}&searchCriteria.toId={searchCriteria.toId}&api-version=6.0
        /// </summary>
        TfvcChangesetsList,

        TfvcItemsGet,
        TfvcItemsGetBatched,
        TfvcItemsList,

        TfvcLabelsGet,
        TfvcLabelsGetItems,
        TfvcLabelsList,

        TfvcShelvesetsGet,
        TfvcShelvesetsGetChanges,
        TfvcShelvesetsGetWorkItems,
        TfvcShelvesetsList,

        WIQL,
        ChangesetDiscussion,
        ShelvesetDiscussion
    }
}
