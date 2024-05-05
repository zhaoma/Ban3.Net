//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

namespace Ban3.Infrastructures.Contracts.Entries.CasinoServer.IndicatorValues;

/// <summary>
/// 移动平均线,Moving Average
/// 5日线和20日线
/// </summary>
public class MA : IndicatorValue
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
