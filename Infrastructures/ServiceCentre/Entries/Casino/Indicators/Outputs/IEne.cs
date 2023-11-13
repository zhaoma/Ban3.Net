// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;

/// <summary>
/// Energy Envelope
/// </summary>
public interface IEne : IStockRecord, IEvaluation<IEne>
{
    /// <summary>
    /// 上轨
    /// </summary>
    [JsonProperty("upper")]
    decimal UPPER { get; set; }

    /// <summary>
    /// 中轨
    /// </summary>
    [JsonProperty("ene")]
    decimal ENE { get; set; }

    /// <summary>
    /// 下轨
    /// </summary>
    [JsonProperty("lower")]
    decimal LOWER { get; set; }
}
