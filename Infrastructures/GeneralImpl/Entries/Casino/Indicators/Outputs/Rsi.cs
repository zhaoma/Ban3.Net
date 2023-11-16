// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.GeneralImpl.Entries.Casino.Items;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators;

using System.Collections.Generic;

namespace Ban3.Infrastructures.GeneralImpl.Entries.Casino.Indicators.Outputs;

public class Rsi : StockFeature, IEvaluation<Rsi>
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
    public bool Judge( Rsi previousValue, out int score, out IEnumerable<string> keys )
    {
        score = 0;
        keys = new List<string>();

        return true;
    }
}