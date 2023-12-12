// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System.Collections.Generic;

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;

namespace Ban3.Infrastructures.GeneralImpl.Entries.Casino.Indicators.Outputs;

public class Macd : StockValue, IEvaluation<Macd>
{
    /// 
    public decimal DIF { get; set; }

    /// 
    public decimal DEA { get; set; }

    /// 
    public decimal MACD { get; set; }

    /// 
    public bool Judge( Macd previousValue )
    {
        Score = 0;
        Keys = new List<string>();

        return true;
    }
}