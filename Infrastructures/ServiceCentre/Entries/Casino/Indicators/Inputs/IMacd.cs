// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Inputs;

public interface IMacd : IParameter
{
    [JsonProperty( "short" )]
    int SHORT { get; set; }

    /// <summary>
    /// LONG(长期)
    /// </summary>
    [JsonProperty( "long" )]
    int LONG { get; set; }

    /// <summary>
    /// M 天数
    /// </summary>
    [JsonProperty( "mid" )]
    int MID { get; set; }
}