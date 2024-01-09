//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Inputs;
using Ban3.Infrastructures.ServiceCentre.Enums.Casino;

namespace Ban3.Infrastructures.GeneralImpl.Entries.Casino.Indicators.Inputs;

/// 乖离率
public class Bias : Parameter, IBias
{
    /// 
    public Bias()
    {
        IndicatorIs = IndicatorIs.BIAS;
    }

    /// 
    public Bias( int n, int m )
    {
        N = n;
        M = m;
    }

    /// 
    public int N { get; set; } = 6;

    /// 
    public int M { get; set; } = 6;
}