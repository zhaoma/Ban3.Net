// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Inputs;
using Ban3.Infrastructures.ServiceCentre.Enums.Casino;

namespace Ban3.Infrastructures.GeneralImpl.Entries.Casino.Indicators.Inputs;

/// 多空指标
public class Bbi : Parameter, IBbi
{
    /// 
    public Bbi()
    {
        IndicatorIs = IndicatorIs.BBI;
    }

    /// 
    public Bbi( int m1, int m2, int m3, int m4 )
    {
        M1 = m1;
        M2 = m2;
        M3 = m3;
        M4 = m4;
    }

    /// 
    public int M1 { get; set; } = 3;

    /// 
    public int M2 { get; set; } = 6;

    /// 
    public int M3 { get; set; } = 12;

    /// 
    public int M4 { get; set; } = 24;
}