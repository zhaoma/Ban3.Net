using System;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Inputs;

public interface IEne
{
    [JsonProperty("n")]
    int N { get; set; }

    [JsonProperty("m1")]
    int M1 { get; set; }

    [JsonProperty("m2")]
    int M2 { get; set; }
}

