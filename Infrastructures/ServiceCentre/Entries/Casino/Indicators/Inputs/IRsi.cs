using System;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Inputs;

public interface IRsi : IParameter
{
    [JsonProperty("n1")]
    int N1 { get; set; }


    [JsonProperty("n2")]
    int N2 { get; set; }


    [JsonProperty("n3")]
    int N3 { get; set; }
}

