// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.GeneralImpl.Entries.Casino.Items;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators;

using System.Collections.Generic;

namespace Ban3.Infrastructures.GeneralImpl.Entries.Casino.Indicators.Outputs;

public class Dmi : StockValue, IEvaluation<Dmi>
{
    /// 
    public decimal PDI { get; set; }

    /// 
    public decimal MDI { get; set; }

    /// 
    public decimal ADX { get; set; }

    /// 
    public decimal ADXR { get; set; }

    /// 
    public bool Judge( Dmi previousValue, out int score, out IEnumerable<string> keys )
    {
        score = 0;
        keys = new List<string>();

        return true;
    }
}