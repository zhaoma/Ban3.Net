﻿//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Enums.CasinoServer;
using System.Collections.Generic;

namespace Ban3.Implements.Alpha.Entries.CasinoServer.IndicatorParameters;

/// <summary>
/// 买卖线参数
/// </summary>
public class MX : Infrastructures.Contracts.Entries.CasinoServer.IndicatorParameter
{
    /// <summary>
    /// 
    /// </summary>
    public MX()
    {
        Index = IndexIs.MX;
        Parameters = new Dictionary<string, int>
        {
            {"N",2 },
            {"M",4 }
        };
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="n"></param>
    /// <param name="m"></param>
    public MX(int n, int m)
    {
        Index = IndexIs.MX;
        Parameters = new Dictionary<string, int>
        {
            {"N",n },
            {"M",m }
        };
    }
}
