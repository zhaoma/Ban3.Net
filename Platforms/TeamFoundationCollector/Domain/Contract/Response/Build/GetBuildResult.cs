﻿using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Response.Build;

public class GetBuildResult
:Entities.Build,IResponse
{
    public bool Success { get; set; }
}