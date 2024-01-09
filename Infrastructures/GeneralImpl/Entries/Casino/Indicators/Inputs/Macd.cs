//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Inputs;
using Ban3.Infrastructures.ServiceCentre.Enums.Casino;

namespace Ban3.Infrastructures.GeneralImpl.Entries.Casino.Indicators.Inputs;

/// 平滑异同平均线
public class Macd : Parameter, IMacd
{
    /// 
    public Macd()
    {
        IndicatorIs = IndicatorIs.MACD;
    }

    /// 
    public Macd( int shortParam, int longParam, int midParam )
    {
        SHORT = shortParam;
        LONG = longParam;
        MID = midParam;
    }

    /// 
    public int SHORT { get; set; } = 12;

    /// 
    public int LONG { get; set; } = 26;

    /// 
    public int MID { get; set; } = 9;
}