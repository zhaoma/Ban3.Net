using System;
using System.Collections.Generic;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.RuntimeCaching;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces.Functions;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Pipelines;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Response.Pipelines;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Extensions;

public static partial class Helper
{
    public static CreatePipelineResult CreatePipeline(this IPipelines _, CreatePipeline request)
        => ServerResource.PipelinesCreatePipeline.Execute<CreatePipelineResult>(request).Result;

    public static GetLogResult GetLog(this IPipelines _, GetLog request)
        => ServerResource.PipelinesGetLog.Execute<GetLogResult>(request).Result;

    /// <summary>
    /// Get Pipeline DetailInfo(Configuration)
    /// </summary>
    /// <param name="_"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    public static GetPipelineResult GetPipeline(this IPipelines _, GetPipeline request)
        => ServerResource.PipelinesGetPipeline.Execute<GetPipelineResult>(request).Result;

    public static GetPipelineResult GetPipeline(this IPipelines _, int pipelineId)
        => _.GetPipeline(new GetPipeline { PipelineId = pipelineId });

    public static GetRunResult GetRun(this IPipelines _, GetRun request)
        => ServerResource.PipelinesGetRun.Execute<GetRunResult>(request).Result;

    public static GetRunResult GetRun(this IPipelines _, int pipelineId, int runId)
        => _.GetRun(new GetRun { PipelineId = pipelineId, RunId = runId });

    public static ListLogsResult ListLogs(this IPipelines _, ListLogs request)
        => ServerResource.PipelinesListLogs.Execute<ListLogsResult>(request).Result;

    public static ListLogsResult ListLogs(this IPipelines _, int pipelineId, int runId)
        => _.ListLogs(new ListLogs { PipelineId = pipelineId, RunId = runId });

    public static ListPipelinesResult ListPipelines(this IPipelines _, ListPipelines request)
        => ServerResource.PipelinesListPipelines.Execute<ListPipelinesResult>(request).Result;

    public static bool PreparePipelines(this IPipelines _)
    {
        try
        {
            var pipelines = _.ListPipelines(new ListPipelines());

            if (pipelines is { Success: true, Value: { } })
            {
                var file = pipelines.Value.SetsFile();
                file.WriteFile(pipelines.Value.ObjToJson());
            }

            return true;
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }

        return false;
    }

    public static List<Pipeline> LoadPipelines(this IPipelines _)
    {
        var file = new List<Pipeline>().SetsFile();
        return file.LoadOrSetDefault(
            file.ReadFile().JsonToObj<List<Pipeline>>()!,
            file);
    }

    public static ListRunsResult ListRuns(this IPipelines _, ListRuns request)
        => ServerResource.PipelinesListRuns.Execute<ListRunsResult>(request).Result;

    public static ListRunsResult ListRuns(this IPipelines _, int pipelineId)
        => _.ListRuns(new ListRuns { PipelineId = pipelineId });

    public static RunPipelineResult RunPipeline(this IPipelines _, RunPipeline request)
        => ServerResource.PipelinesRunPipeline.Execute<RunPipelineResult>(request).Result;
}