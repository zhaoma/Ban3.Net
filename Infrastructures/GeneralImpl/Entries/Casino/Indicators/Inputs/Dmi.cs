//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Inputs;
using Ban3.Infrastructures.ServiceCentre.Enums.Casino;

namespace Ban3.Infrastructures.GeneralImpl.Entries.Casino.Indicators.Inputs;

/// 趋向指标
public class Dmi : Parameter, IDmi
{
    /// 
    public Dmi()
    {
        IndicatorIs = IndicatorIs.DMI;
    }

    /// 
    public Dmi( int n, int m )
    {
        N = n;
        M = m;
    }

    /// 
    public int N { get; set; } = 14;

    /// 
    public int M { get; set; } = 6;
}