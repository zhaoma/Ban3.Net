﻿using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;
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

    public static GetPipelineResult GetPipeline(this IPipelines _, GetPipeline request)
        => ServerResource.PipelinesGetPipeline.Execute<GetPipelineResult>(request).Result;

    public static GetRunResult GetRun(this IPipelines _, GetRun request)
        => ServerResource.PipelinesGetRun.Execute<GetRunResult>(request).Result;

    public static ListLogsResult ListLogs(this IPipelines _, ListLogs request)
        => ServerResource.PipelinesListLogs.Execute<ListLogsResult>(request).Result;

    public static ListPipelinesResult ListPipelines(this IPipelines _, ListPipelines request)
        => ServerResource.PipelinesListPipelines.Execute<ListPipelinesResult>(request).Result;

    public static ListRunsResult ListRuns(this IPipelines _, ListRuns request)
        => ServerResource.PipelinesListRuns.Execute<ListRunsResult>(request).Result;

    public static RunPipelineResult RunPipeline(this IPipelines _, RunPipeline request)
        => ServerResource.PipelinesRunPipeline.Execute<RunPipelineResult>(request).Result;
}