//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Enums.CasinoServer;
using System.Collections.Generic;

namespace Ban3.Implements.Alpha.Entries.CasinoServer.IndicatorParameters;

/// <summary>
/// 移动平均线参数
/// </summary>
public class MA : Infrastructures.Contracts.Entries.CasinoServer.IndicatorParameter
{
    /// <summary>
    /// 
    /// </summary>
    public MA()
    {
        Index = IndexIs.MA;
        Parameters = new Dictionary<string, int>
        {
            {"SHORT",5 },
            {"LONG",20 }
        };
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="shortPeriod"></param>
    /// <param name="longPeriod"></param>
    public MA(int shortPeriod, int longPeriod)
    {
        Index = IndexIs.MA;
        Parameters = new Dictionary<string, int>
        {
            {"SHORT",shortPeriod },
            {"LONG",longPeriod }
        };
    }
}
