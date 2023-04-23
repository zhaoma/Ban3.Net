﻿using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Response.Tfvc;

public class GetShelvesetResult
    : TfvcShelveset,IResponse
{

    public bool Success { get; set; }
}