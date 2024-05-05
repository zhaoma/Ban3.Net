//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Enums.CasinoServer;
using System.Collections.Generic;

namespace Ban3.Implements.Alpha.Entries.CasinoServer.IndicatorParameters;

/// <summary>
/// 成交量参数
/// </summary>
public class AMOUNT : Infrastructures.Contracts.Entries.CasinoServer.IndicatorParameter
{
    /// <summary>
    /// 
    /// </summary>
    public AMOUNT()
    {
        Index = IndexIs.AMOUNT;
        Parameters = new Dictionary<string, int>
        {
            {"SHORT",5 },
            {"LONG",10 }
        };
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="shortPeriod"></param>
    /// <param name="longPeriod"></param>
    public AMOUNT(int shortPeriod, int longPeriod)
    {
        Index = IndexIs.AMOUNT;
        Parameters = new Dictionary<string, int>
        {
            {"SHORT",shortPeriod },
            {"LONG",longPeriod }
        };
    }
}
