using System;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Inputs;

public interface IKd
{
    [JsonProperty("n")]
    int N { get; set; }

    [JsonProperty("m")]
    int M { get; set; }
}

