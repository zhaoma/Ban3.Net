//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

namespace Ban3.Infrastructures.Contracts.Entries.CasinoServer.IndicatorValues;

/// <summary>
/// 用5日线和20日线
/// DIF:EMA(CLOSE,SHORT)-EMA(CLOSE,LONG);
/// DEA:EMA(DIF,MID);
/// MACD:(DIF-DEA)*2,COLORSTICK;
/// </summary>
public interface IMA:IIndicatorValue
{
    decimal Short { get; set; }

    decimal Long { get; set; }
}
