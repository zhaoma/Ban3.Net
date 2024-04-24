//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

namespace Ban3.Infrastructures.Contracts.Entries.CasinoServer.IndicatorValues;

/// <summary>
/// 成交量5日线和20日线
/// </summary>
public interface IAMOUNT
{
    decimal Short { get; set; }

    decimal Long { get; set; }
}
