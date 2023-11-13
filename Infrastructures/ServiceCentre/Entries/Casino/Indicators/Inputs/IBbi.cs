// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Inputs;

public interface IBbi : IParameter
{
    [JsonProperty("m1")]
    int M1 { get; set; }

    [JsonProperty("m2")]
    int M2 { get; set; }

    [JsonProperty("m3")]
    int M3 { get; set; }

    [JsonProperty("m4")]
    int M4 { get; set; }
}

