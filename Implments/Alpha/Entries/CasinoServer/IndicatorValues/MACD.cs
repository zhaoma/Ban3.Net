//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Entries.CasinoServer.IndicatorValues;
using Ban3.Infrastructures.Contracts.Enums.CasinoServer;

namespace Ban3.Implements.Alpha.Entries.CasinoServer.IndicatorValues;

/// <summary>
/// 
/// </summary>
public class MACD : IMACD
{
    public IndexIs Index { get; set; } = IndexIs.MX;

    public decimal DIF { get; set; }

    public decimal DEA { get; set; }

    public decimal RefMACD { get; set; }
}
