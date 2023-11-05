using Newtonsoft.Json;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Inputs;

public interface ICci : IParameter
{
    [JsonProperty("n")]
    int N { get; set; }
}

