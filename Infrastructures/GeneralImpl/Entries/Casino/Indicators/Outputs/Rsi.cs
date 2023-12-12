// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System.Collections.Generic;

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;

namespace Ban3.Infrastructures.GeneralImpl.Entries.Casino.Indicators.Outputs;

public class Rsi : StockValue, IEvaluation<Rsi>
{
    /// 
    public decimal LC { get; set; }

    /// 
    public decimal RSI1 { get; set; }

    /// 
    public decimal RSI2 { get; set; }

    /// 
    public decimal RSI3 { get; set; }

    /// 
    public bool Judge( Rsi previousValue )
    {
        Score = 0;
        Keys = new List<string>();

        return true;
    }
}