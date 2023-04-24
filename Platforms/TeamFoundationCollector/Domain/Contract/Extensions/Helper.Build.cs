using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces.Functions;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Build;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Response.Build;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Extensions;

public static partial class Helper
{
    public static CreateDefinitionResult CreateDefinition(this ICore _, CreateDefinition request)
        => ServerResource.BuildCreateDefinition.Execute<CreateDefinitionResult>(request).Result;

    public static DeleteBuildResult DeleteBuild(this ICore _, DeleteBuild request)
        => ServerResource.BuildDeleteBuild.Execute<DeleteBuildResult>(request).Result;

    public static DeleteDefinitionResult DeleteDefinition(this ICore _, DeleteDefinition request)
        => ServerResource.BuildDeleteDefinition.Execute<DeleteDefinitionResult>(request).Result;

    public static GetBuildResult GetBuild(this ICore _, GetBuild request)
        => ServerResource.BuildGetBuild.Execute<GetBuildResult>(request).Result;

    public static GetBuildChangesResult GetBuildChanges(this ICore _, GetBuildChanges request)
        => ServerResource.BuildGetBuildChanges.Execute<GetBuildChangesResult>(request).Result;

    public static GetBuildLogResult GetBuildLog(this ICore _, GetBuildLog request)
        => ServerResource.BuildGetBuildLog.Execute<GetBuildLogResult>(request).Result;

    public static GetBuildLogsResult GetBuildLogs(this ICore _, GetBuildLogs request)
        => ServerResource.BuildGetBuildLogs.Execute<GetBuildLogsResult>(request).Result;

    public static GetBuildWorkItemsRefsFromCommitsResult GetBuildWorkItemsRefsFromCommits(this ICore _,
        GetBuildWorkItemsRefsFromCommits request)
        => ServerResource.BuildGetBuildWorkItemsRefsFromCommits
            .Execute<GetBuildWorkItemsRefsFromCommitsResult>(request).Result;

    public static GetBuildWorkItemsRefsResult GetBuildWorkItemsRefs(this ICore _, GetBuildWorkItemsRefs request)
        => ServerResource.BuildGetBuildWorkItemsRefs.Execute<GetBuildWorkItemsRefsResult>(request).Result;

    public static GetChangesBetweenBuildsResult GetChangesBetweenBuilds(this ICore _,
        GetChangesBetweenBuilds request)
        => ServerResource.BuildGetChangesBetweenBuilds.Execute<GetChangesBetweenBuildsResult>(request).Result;

    public static GetControllerResult GetController(this ICore _, GetController request)
        => ServerResource.BuildGetController.Execute<GetControllerResult>(request).Result;

    public static GetDefinitionResult GetDefinition(this ICore _, GetDefinition request)
        => ServerResource.BuildGetDefinition.Execute<GetDefinitionResult>(request).Result;

    public static GetDefinitionRevisionsResult GetDefinitionRevisions(this ICore _, GetDefinitionRevisions request)
        => ServerResource.BuildGetDefinitionRevisions.Execute<GetDefinitionRevisionsResult>(request).Result;

    public static GetTimelineResult GetTimeline(this ICore _, GetTimeline request)
        => ServerResource.BuildGetTimeline.Execute<GetTimelineResult>(request).Result;

    public static GetWorkItemsBetweenBuildsResult GetWorkItemsBetweenBuilds(this ICore _,
        GetWorkItemsBetweenBuilds request)
        => ServerResource.BuildGetWorkItemsBetweenBuilds.Execute<GetWorkItemsBetweenBuildsResult>(request).Result;

    public static ListBuildsResult ListBuilds(this ICore _, ListBuilds request)
        => ServerResource.BuildListBuilds.Execute<ListBuildsResult>(request).Result;

    public static ListControllersResult ListControllers(this ICore _, ListControllers request)
        => ServerResource.BuildListControllers.Execute<ListControllersResult>(request).Result;

    public static ListDefinitionsResult ListDefinitions(this ICore _, ListDefinitions request)
        => ServerResource.BuildListDefinitions.Execute<ListDefinitionsResult>(request).Result;

    public static QueueBuildResult QueueBuild(this ICore _, QueueBuild request)
        => ServerResource.BuildQueueBuild.Execute<QueueBuildResult>(request).Result;

    public static RestoreDefinitionResult RestoreDefinition(this ICore _, RestoreDefinition request)
        => ServerResource.BuildRestoreDefinition.Execute<RestoreDefinitionResult>(request).Result;

    public static UpdateBuildResult UpdateBuild(this ICore _, UpdateBuild request)
        => ServerResource.BuildUpdateBuild.Execute<UpdateBuildResult>(request).Result;

    public static UpdateBuildsResult UpdateBuilds(this ICore _, UpdateBuilds request)
        => ServerResource.BuildUpdateBuilds.Execute<UpdateBuildsResult>(request).Result;

    public static UpdateDefinitionResult UpdateDefinition(this ICore _, UpdateDefinition request)
        => ServerResource.BuildUpdateDefinition.Execute<UpdateDefinitionResult>(request).Result;

}

