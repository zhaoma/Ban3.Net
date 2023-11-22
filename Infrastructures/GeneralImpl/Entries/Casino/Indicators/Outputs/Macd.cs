// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.GeneralImpl.Entries.Casino.Items;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators;

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
    public bool Judge( Macd previousValue, out int score, out IEnumerable<string> keys )
    {
        score = 0;
        keys = new List<string>();

        return true;
    }
}