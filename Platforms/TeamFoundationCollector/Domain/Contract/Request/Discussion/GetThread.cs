﻿using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Discussion;

public class GetThread
    : PresetRequest, IRequest
{
    [JsonProperty("method")]
    public string Method { get; set; } = "Get";

    [JsonProperty("id")]
    public int Id { get; set; }

    public string RequestPath() => $"{Instance}/{Organization}/_apis/discussion/threads/{Id}";

    public string RequestQuery() =>string.Empty;

    public string RequestBody() => string.Empty;
}