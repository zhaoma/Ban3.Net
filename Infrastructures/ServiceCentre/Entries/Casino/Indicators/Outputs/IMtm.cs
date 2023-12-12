// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;

/// <summary>
/// 动量指标,Momentum Index
/// </summary>
public interface IMtm : IEvaluation<IMtm>
{
    /// <summary>
    /// MTM:CLOSE-REF(CLOSE,N);
    /// </summary>
    [JsonProperty( "mtm" )]
    decimal MTM { get; set; }

    /// <summary>
    /// MAMTM:MA(MTM, M);
    /// </summary>
    [JsonProperty( "mamtm" )]
    decimal MAMTM { get; set; }
}