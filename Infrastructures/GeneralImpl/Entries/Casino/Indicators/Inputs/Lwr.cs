// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Inputs;
using Ban3.Infrastructures.ServiceCentre.Enums.Casino;

namespace Ban3.Infrastructures.GeneralImpl.Entries.Casino.Indicators.Inputs;

/// 威廉指标
public class Lwr : Parameter, ILwr
{
    /// 
    public Lwr()
    {
        IndicatorIs = IndicatorIs.LWR;
    }

    /// 
    public Lwr( int n, int m1, int m2 )
    {
        N = n;
        M1 = m1;
        M2 = m2;
    }

    /// 
    public int N { get; set; } = 9;

    /// 
    public int M1 { get; set; } = 3;

    /// 
    public int M2 { get; set; } = 3;
}