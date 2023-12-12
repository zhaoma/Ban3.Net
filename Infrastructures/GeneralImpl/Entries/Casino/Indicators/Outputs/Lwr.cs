// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System.Collections.Generic;

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;

namespace Ban3.Infrastructures.GeneralImpl.Entries.Casino.Indicators.Outputs;

public class Lwr : StockValue, IEvaluation<Lwr>
{
    /// 
    public decimal LWR1 { get; set; }

    /// 
    public decimal LWR2 { get; set; }

    /// 
    public bool Judge( Lwr previousValue )
    {
        Score = 0;
        Keys = new List<string>();

        return true;
    }
}