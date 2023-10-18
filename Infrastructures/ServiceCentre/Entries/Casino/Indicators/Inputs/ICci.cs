using Newtonsoft.Json;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Inputs;

public interface ICci
{
    [JsonProperty("n")]
    int N { get; set; }
}

