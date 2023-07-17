using System;
using System.Collections.Generic;
using Ban3.Infrastructures.Indicators.Inputs;
using Ban3.Infrastructures.Indicators.Outputs;
using Newtonsoft.Json;

namespace Ban3.Productions.Casino.Contracts.Entities;

public class CompositeRecords
{
    [JsonProperty("profile", NullValueHandling = NullValueHandling.Ignore)]
    public Profile Profile { get; set; }

    [JsonProperty("records", NullValueHandling = NullValueHandling.Ignore)]
    public List<StockOperationRecord> Records { get; set; }

    [JsonProperty("rightKeys", NullValueHandling = NullValueHandling.Ignore)]
    public Dictionary<string,int> RightKeys { get; set; }

    [JsonProperty("wrongKeys", NullValueHandling = NullValueHandling.Ignore)]
    public Dictionary<string,int> WrongKeys { get; set; }
}

