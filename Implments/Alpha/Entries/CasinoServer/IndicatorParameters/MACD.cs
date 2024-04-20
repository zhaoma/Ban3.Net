//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Entries.CasinoServer;
using Ban3.Infrastructures.Contracts.Enums.CasinoServer;
using System.Collections.Generic;

namespace Ban3.Implements.Alpha.Entries.CasinoServer;

/// <summary>
/// MACD 参数
/// DIF:EMA(CLOSE,SHORT)-EMA(CLOSE,LONG);
/// DEA:EMA(DIF,MID);
/// MACD:(DIF-DEA)*2,COLORSTICK;
/// </summary>
public class MACD : IIndicatorParameter
{
    public IndexIs Index { get; set; } = IndexIs.MACD;

    public Dictionary<string, int> Parameters { get; set; }
        = new Dictionary<string, int>
        {
            {"SHORT",12 },
            {"LONG",26 },
            {"MID",9 }
        };
}
