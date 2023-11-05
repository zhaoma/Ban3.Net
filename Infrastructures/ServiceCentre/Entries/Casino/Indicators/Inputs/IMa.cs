using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Inputs;

public interface IMa : IParameter
{
    [JsonProperty("durations")]
    IEnumerable<int> Durations { get; set; }
}

