//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

namespace Ban3.Infrastructures.Contracts.Entries.CasinoServer.IndicatorValues;

/// <summary>
/// DIF:EMA(CLOSE,SHORT)-EMA(CLOSE,LONG);
/// DEA:EMA(DIF,MID);
/// MACD:(DIF-DEA)*2,COLORSTICK;
/// </summary>
public interface IMACD : IIndicatorValue
{
    decimal DIF { get; set; }

    decimal DEA { get; set; }

    decimal RefMACD { get; set; }
}
