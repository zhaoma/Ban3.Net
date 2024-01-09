//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Inputs;
using Ban3.Infrastructures.ServiceCentre.Enums.Casino;

namespace Ban3.Infrastructures.GeneralImpl.Entries.Casino.Indicators.Inputs;

/// 随机指标
public class Kd : Parameter, IKd
{
    public Kd()
    {
        IndicatorIs = IndicatorIs.KD;
    }

    public Kd( int n, int m )
    {
        N = n;
        M = m;
    }

    public int N { get; set; } = 9;

    public int M { get; set; } = 3;
}