using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.NetHttp;
using Ban3.Infrastructures.RuntimeCaching;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces.Functions;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Build;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Pipelines;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Response.Build;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Extensions;

public static partial class Helper
{
    public static CreateDefinitionResult CreateDefinition(this IBuild _, CreateDefinition request)
        => ServerResource.BuildCreateDefinition.Execute<CreateDefinitionResult>(request).Result;

    public static DeleteBuildResult DeleteBuild(this IBuild _, DeleteBuild request)
        => ServerResource.BuildDeleteBuild.Execute<DeleteBuildResult>(request).Result;

    public static DeleteDefinitionResult DeleteDefinition(this IBuild _, DeleteDefinition request)
        => ServerResource.BuildDeleteDefinition.Execute<DeleteDefinitionResult>(request).Result;

    public static GetBuildResult GetBuild(this IBuild _, GetBuild request)
        => ServerResource.BuildGetBuild.Execute<GetBuildResult>(request).Result;

    public static GetBuildResult GetBuild(this IBuild _, int buildId)
        => _.GetBuild(new GetBuild { BuildId = buildId });

    public static Build? GetLastBuildForDefinition(this IBuild _, int definitionId)
    {
        var result = _.ListBuilds(definitionId, 1);
        if(result is { Success: true, Value: { } } && result.Value.Any())
            return result.Value[0];

        return null;
    }

    public static string BuildDuration(this Build build)
    {
        var seconds = build.FinishTime.ToDateTime()
            .Subtract(build.StartTime.ToDateTime())
            .TotalSeconds;

        var result = "";

        var h = (int)seconds / (60 * 60);
        var m = (int)seconds % (60 * 60) / 60;
        var s = (int)seconds % 60;

        if (h > 0) result += $" {h} h";
        if (m > 0) result += $" {m} m";
        if (s > 0) result += $" {s} s";

        return result;
    }

    public static GetBuildChangesResult GetBuildChanges(this IBuild _, GetBuildChanges request)
        => ServerResource.BuildGetBuildChanges.Execute<GetBuildChangesResult>(request).Result;

    public static GetBuildChangesResult GetBuildChanges(this IBuild _, int buildId)
        => _.GetBuildChanges(new GetBuildChanges { BuildId = buildId });

    public static GetBuildLogResult GetBuildLog(this IBuild _, GetBuildLog request)
    {
        var content=ServerResource.BuildGetBuildLog.ReadHtml(request).Result;
        return new GetBuildLogResult
        {
            Success = !string.IsNullOrEmpty(content),
            Content = content
        };
    }

    public static GetBuildLogResult GetBuildLog(
        this IBuild _, 
        int buildId, 
        int logId, 
        long? startLine = null,
        long? endLine = null)
        => _.GetBuildLog(new GetBuildLog
        {
            BuildId = buildId,
            LogId = logId,
            StartLine = startLine,
            EndLine = endLine
        });

    public static GetBuildLogsResult GetBuildLogs(this IBuild _, GetBuildLogs request)
        => ServerResource.BuildGetBuildLogs.Execute<GetBuildLogsResult>(request).Result;

    public static GetBuildLogsResult GetBuildLogs(this IBuild _, int buildId)
        => _.GetBuildLogs(new GetBuildLogs { BuildId = buildId });

    public static GetBuildWorkItemsRefsFromCommitsResult GetBuildWorkItemsRefsFromCommits(this IBuild _,
        GetBuildWorkItemsRefsFromCommits request)
        => ServerResource.BuildGetBuildWorkItemsRefsFromCommits
            .Execute<GetBuildWorkItemsRefsFromCommitsResult>(request).Result;

    public static GetBuildWorkItemsRefsResult GetBuildWorkItemsRefs(this IBuild _, GetBuildWorkItemsRefs request)
        => ServerResource.BuildGetBuildWorkItemsRefs.Execute<GetBuildWorkItemsRefsResult>(request).Result;

    public static GetChangesBetweenBuildsResult GetChangesBetweenBuilds(this IBuild _,
        GetChangesBetweenBuilds request)
        => ServerResource.BuildGetChangesBetweenBuilds.Execute<GetChangesBetweenBuildsResult>(request).Result;

    public static GetControllerResult GetController(this IBuild _, GetController request)
        => ServerResource.BuildGetController.Execute<GetControllerResult>(request).Result;

    public static GetDefinitionResult GetDefinition(this IBuild _, GetDefinition request)
        => ServerResource.BuildGetDefinition.Execute<GetDefinitionResult>(request).Result;

    public static GetDefinitionRevisionsResult GetDefinitionRevisions(this IBuild _, GetDefinitionRevisions request)
        => ServerResource.BuildGetDefinitionRevisions.Execute<GetDefinitionRevisionsResult>(request).Result;

    public static GetReportResult GetReport(this IBuild _, GetReport request)
    {
        var content = ServerResource.BuildGetReport.ReadHtml(request,"text/html").Result;
        return new GetReportResult
        {
            Success = !string.IsNullOrEmpty(content),
            Html = content
        };
    }

    public static string GetBuildIssues(this IBuild _, int buildId)
    {
        var issues = "";
        /*
        var report = _.GetReport(buildId);
        if (report.Success)
        {
            var symbol = "<h3>Issues</h3>";
            if (report.Html.Contains(symbol))
            {
                var start = report.Html.IndexOf(symbol) + symbol.Length;
                issues = report.Html.Substring(start, report.Html.Length - start);
                issues = issues.Substring(0, issues.IndexOf("</div>") + 6);
            }
        }
        */

        var records = _.GetTimelineForBuildIssues(buildId);
        if (records.Any())
        {
            records
                .OrderBy(o => o.Order)
                .ToList()
                .ForEach(o =>
                    {
                        var url =
                            $"https://demeter.healthcare.siemens.com/tfs/CT/CTS/_build/results?buildId={buildId}&view=logs&j={o.ParentId}&t={o.Id}";
                        issues += $"<a href='{url}' target='_blank'><h4 style='color:#AAA'>timeline step {o.Order} : {o.Name}</h4></a>";
                        o.Issues?.ForEach(x =>
                        {
                            issues += $"{x.Message}<br/>";
                        });
                    }
                );
        }

        return issues;
    }

    public static GetReportResult GetReport(this IBuild _, int buildId)
        => _.GetReport(new GetReport { BuildId = buildId });

    public static GetTimelineResult GetTimeline(this IBuild _, GetTimeline request)
        => ServerResource.BuildGetTimeline.Execute<GetTimelineResult>(request).Result;

    public static List<TimelineRecord> GetTimelineForBuildIssues(this IBuild _, int buildId)
    {
        var timeline = _.GetTimeline(new GetTimeline { BuildId = buildId });
        if (timeline is { Success: true, Records: { } } && timeline.Records.Any())
            return timeline.Records.FindAll(o => o.ErrorCount > 0).ToList();

        return new List<TimelineRecord>();
    }

    public static GetWorkItemsBetweenBuildsResult GetWorkItemsBetweenBuilds(this IBuild _,
        GetWorkItemsBetweenBuilds request)
        => ServerResource.BuildGetWorkItemsBetweenBuilds.Execute<GetWorkItemsBetweenBuildsResult>(request).Result;
    
    public static ListArtifactsResult ListArtifacts(this IBuild _,ListArtifacts request)
        => ServerResource.BuildListArtifacts.Execute<ListArtifactsResult>(request).Result;

    public static ListArtifactsResult ListArtifacts(this IBuild _, int buildId)
        => _.ListArtifacts(new ListArtifacts { BuildId = buildId });

    public static List<BuildArtifactContent>? ListArtifactsForBuild(this IBuild _, int buildId)
    {
        var result = _.ListArtifacts(buildId);
        if (result is { Success: true, Value: { } } && result.Value.Any())
        {
            var contents = new List<BuildArtifactContent>();

            result.Value
                .ForEach(o =>
                {
                    var temp = o.BuildArtifactContent();
                    if (temp != null)
                        contents.AddRange(temp);
                });

            return contents;
        }

        return null;
    }

    private static List<BuildArtifactContent>? BuildArtifactContent(this BuildArtifact buildArtifact)
    {
        if (buildArtifact.Resource != null)
        {
            var file = Path.Combine(buildArtifact.Resource.Data, @"SiemensTestSummary.md");
            if (File.Exists(file))
            {
                var fileLocation = string.Empty;
                var lines = file.ReadFile2Rows();

                return lines.Select(o =>
                {
                    var content = o.Replace("\\AnyCPU", "");

                    if (!string.IsNullOrEmpty(content) && content.Contains(buildArtifact.Resource.Data))
                    {
                        var fileStart = content.IndexOf(buildArtifact.Resource.Data);
                        var temp = content.Substring(fileStart, content.Length.ToInt() - fileStart);
                        fileLocation = temp.Substring(0, temp.IndexOf(")"));
                    }

                    return new BuildArtifactContent
                    {
                        Content = content,
                        FileLocation = fileLocation
                    };
                }).ToList();
            }
        }

        return null;
    }
    
    public static ListBuildsResult ListBuilds(this IBuild _, ListBuilds request)
        => ServerResource.BuildListBuilds.Execute<ListBuildsResult>(request).Result;

    public static ListBuildsResult ListBuilds(this IBuild _, int definitionId, int num=1)
        => _.ListBuilds(new ListBuilds { Definitions = definitionId + "", Top = num });

    public static ListControllersResult ListControllers(this IBuild _, ListControllers request)
        => ServerResource.BuildListControllers.Execute<ListControllersResult>(request).Result;

    public static bool PrepareControllers(this IBuild _)
    {
        try
        {
            var controllers = _.ListControllers(new ListControllers());

            if (controllers is { Success: true, Value: { } })
            {
                var file = controllers.Value.SetsFile();
                file.WriteFile(controllers.Value.ObjToJson());
            }

            return true;
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }

        return false;
    }

    public static List<BuildController> LoadControllers(this IBuild _)
    {
        var file = new List<BuildController>().SetsFile();
        return file.LoadOrSetDefault(
            file.ReadFile().JsonToObj<List<BuildController>>()!,
            file);
    }
    
    public static ListDefinitionsResult ListDefinitions(this IBuild _, ListDefinitions request)
        => ServerResource.BuildListDefinitions.Execute<ListDefinitionsResult>(request).Result;
    
    public static bool PrepareDefinitions(this IBuild _)
    {
        try
        {
            var definitions = _.ListDefinitions(new ListDefinitions());

            if (definitions is { Success: true, Value: { } })
            {
                var file = definitions.Value.SetsFile();
                file.WriteFile(definitions.Value.ObjToJson());
            }

            return true;
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }

        return false;
    }

    public static List<BuildDefinitionReference> LoadDefinitionRefs(this IBuild _)
    {
        var file = new List<BuildDefinitionReference>().SetsFile();
        return file.LoadOrSetDefault(
            file.ReadFile().JsonToObj<List<BuildDefinitionReference>>()!,
            file);
    }

    public static ListFoldersResult ListFolders(this IBuild _, ListFolders request)
        => ServerResource.BuildListFolders.Execute<ListFoldersResult>(request).Result;

    public static bool PrepareFolders(this IBuild _)
    {
        try
        {
            var folders = _.ListFolders(new ListFolders());

            if (folders is { Success: true, Value: { } })
            {
                var file = folders.Value.SetsFile();
                file.WriteFile(folders.Value.ObjToJson());
            }

            return true;
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }

        return false;
    }

    public static List<Folder> LoadFolders(this IBuild _)
    {
        var file = new List<Folder>().SetsFile();
        return file.LoadOrSetDefault(
            file.ReadFile().JsonToObj<List<Folder>>()!,
            file);
    }

    public static QueueBuildResult QueueBuild(this IBuild _, QueueBuild request)
        => ServerResource.BuildQueueBuild.Execute<QueueBuildResult>(request).Result;

    public static RestoreDefinitionResult RestoreDefinition(this IBuild _, RestoreDefinition request)
        => ServerResource.BuildRestoreDefinition.Execute<RestoreDefinitionResult>(request).Result;

    public static UpdateBuildResult UpdateBuild(this IBuild _, UpdateBuild request)
        => ServerResource.BuildUpdateBuild.Execute<UpdateBuildResult>(request).Result;

    public static UpdateBuildsResult UpdateBuilds(this IBuild _, UpdateBuilds request)
        => ServerResource.BuildUpdateBuilds.Execute<UpdateBuildsResult>(request).Result;

    public static UpdateDefinitionResult UpdateDefinition(this IBuild _, UpdateDefinition request)
        => ServerResource.BuildUpdateDefinition.Execute<UpdateDefinitionResult>(request).Result;

}

