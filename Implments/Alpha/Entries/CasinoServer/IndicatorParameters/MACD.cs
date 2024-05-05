//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Enums.CasinoServer;
using System.Collections.Generic;

namespace Ban3.Implements.Alpha.Entries.CasinoServer.IndicatorParameters;

/// <summary>
/// 指数平滑异同移动平均线参数
/// DIF:EMA(CLOSE,SHORT)-EMA(CLOSE,LONG);
/// DEA:EMA(DIF,MID);
/// MACD:(DIF-DEA)*2,COLORSTICK;
/// </summary>
public class MACD : Infrastructures.Contracts.Entries.CasinoServer.IndicatorParameter
{
    /// <summary>
    /// 
    /// </summary>
    public MACD()
    {
        Index = IndexIs.MACD;
        Parameters = new Dictionary<string, int>
        {
            {"SHORT",12 },
            {"LONG",26 },
            {"MID",9 }
        };
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="shortPeriod"></param>
    /// <param name="longPeriod"></param>
    /// <param name="midPeriod"></param>
    public MACD(int shortPeriod, int longPeriod, int midPeriod)
    {
        Index = IndexIs.MACD;
        Parameters = new Dictionary<string, int>
        {
            {"SHORT",shortPeriod },
            {"LONG",longPeriod },
            {"midPeriod",9 }
        };
    }
}
