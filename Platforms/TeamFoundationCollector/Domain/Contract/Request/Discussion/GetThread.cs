﻿using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Discussion;

public class GetThread
    : PresetRequest, IRequest
{
    public int Id { get; set; }

    public string RequestPath() => $"{Instance}/{Organization}/_apis/discussion/threads/{Id}";

    
}