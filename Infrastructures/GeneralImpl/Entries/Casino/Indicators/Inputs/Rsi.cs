// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Inputs;
using Ban3.Infrastructures.ServiceCentre.Enums.Casino;

namespace Ban3.Infrastructures.GeneralImpl.Entries.Casino.Indicators.Inputs;

/// 相对强弱指标
public class Rsi : Parameter, IRsi
{
    /// 
    public Rsi()
    {
        IndicatorIs = IndicatorIs.RSI;
    }

    /// 
    public Rsi( int n1, int n2, int n3 )
    {
        N1 = n1;
        N2 = n2;
        N3 = n3;
    }

    /// 
    public int N1 { get; set; } = 6;

    /// 
    public int N2 { get; set; } = 12;

    /// 
    public int N3 { get; set; } = 24;
}