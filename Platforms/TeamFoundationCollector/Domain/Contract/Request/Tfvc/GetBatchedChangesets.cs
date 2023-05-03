﻿using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Tfvc;

public class GetBatchedChangesets
    : PresetRequest, IRequest
{
    public GetBatchedChangesets() { Method = "Post"; }
    
    public GetBatchedChangesetsBody? Body { get; set; }
    
    public string RequestPath() => $"{Instance}/{Organization}/{Project}/_apis/tfvc/changesetsbatch";

    public override string RequestBody() => JsonConvert.SerializeObject(Body);
}