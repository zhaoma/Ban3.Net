﻿using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Pipelines;

/// <summary>
/// Create a pipeline.
/// https://learn.microsoft.com/en-us/rest/api/azure/devops/pipelines/pipelines/create?view=azure-devops-rest-7.0#createpipelineparameters
/// </summary>
public class CreatePipeline
    : PresetRequest, IRequest
{
    public CreatePipeline() { Method = "Post"; }

    public CreatePipelineParameters? Body { get; set; }

    public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/pipelines";

    public override string RequestBody() => JsonConvert.SerializeObject(Body);
}

