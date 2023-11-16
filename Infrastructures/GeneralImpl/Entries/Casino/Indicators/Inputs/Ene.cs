// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Inputs;
using Ban3.Infrastructures.ServiceCentre.Enums.Casino;

namespace Ban3.Infrastructures.GeneralImpl.Entries.Casino.Indicators.Inputs;

/// 轨道线
public class Ene : Parameter, IEne
{
    /// 
    public Ene()
    {
        IndicatorIs = IndicatorIs.ENE;
    }

    /// 
    public Ene( int n, int m1, int m2 )
    {
        N = n;
        M1 = m1;
        M2 = m2;
    }

    /// 
    public int N { get; set; } = 10;

    /// 
    public int M1 { get; set; } = 11;

    /// 
    public int M2 { get; set; } = 9;
}