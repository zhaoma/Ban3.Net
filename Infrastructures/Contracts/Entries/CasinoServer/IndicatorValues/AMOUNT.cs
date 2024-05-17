//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

namespace Ban3.Infrastructures.Contracts.Entries.CasinoServer.IndicatorValues;

/// <summary>
/// 成交量5日线和20日线
/// </summary>
public class AMOUNT : IndicatorValue
{
    /// <summary>
    /// 短期线
    /// </summary>
    [JsonProperty("short")]
    public decimal Short { get; set; }

    /// <summary>
    /// 长期线
    /// </summary>
    [JsonProperty("long")]
    public decimal Long { get; set; }
}
