﻿//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Inputs;
using Ban3.Infrastructures.ServiceCentre.Enums.Casino;

namespace Ban3.Infrastructures.GeneralImpl.Entries.Casino.Indicators.Inputs;

/// 动量指标
public class Mtm : Parameter, IMtm
{
    /// 
    public Mtm()
    {
        IndicatorIs = IndicatorIs.MTM;
    }

    /// 
    public Mtm( int n, int m )
    {
        N = n;
        M = m;
    }

    /// 
    public int N { get; set; } = 6;

    /// 
    public int M { get; set; } = 10;
}