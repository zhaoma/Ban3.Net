using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Ban3.Productions.Casino.Contracts.Entities;

public class DotRecord
{
    public DotRecord() { }

    public DotRecord(DotInfo info) {
        Code = info.Code;
        ChangePercent = info.ChangePercent;
        SetKeys = info.SetKeys.ToList();
    }

    [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
    public string Code
    {
        get; set;
    }

    [JsonProperty("changePercent", NullValueHandling = NullValueHandling.Ignore)]
    public float ChangePercent { get; set; }


    [JsonProperty("setKeys", NullValueHandling = NullValueHandling.Ignore)]
    public List<string> SetKeys { get; set; }
}
