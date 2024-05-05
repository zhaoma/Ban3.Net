//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

namespace Ban3.Infrastructures.Contracts.Entries.CasinoServer.IndicatorValues;

/// <summary>
/// 成交量5日线和20日线
/// </summary>
public class AMOUNT : IndicatorValue
{
    /// <summary>
    /// 短期线
    /// </summary>
    public decimal Short { get; set; }

    /// <summary>
    /// 长期线
    /// </summary>
    public decimal Long { get; set; }
}
