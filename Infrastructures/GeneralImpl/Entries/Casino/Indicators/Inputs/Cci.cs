//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Inputs;
using Ban3.Infrastructures.ServiceCentre.Enums.Casino;

namespace Ban3.Infrastructures.GeneralImpl.Entries.Casino.Indicators.Inputs;

/// 商品路径指标
public class Cci : Parameter, ICci
{
    ///
    public Cci()
    {
        IndicatorIs = IndicatorIs.CCI;
    }

    ///
    public Cci( int n )
    {
        N = n;
    }

    ///
    public int N { get; set; } = 14;
}