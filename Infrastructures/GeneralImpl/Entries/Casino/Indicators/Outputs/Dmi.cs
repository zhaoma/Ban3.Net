//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System.Collections.Generic;

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;

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
    public bool Judge( Dmi previousValue, IStockPrice price )
    {
        Score = 0;
        Keys = new List<string>();

        return true;
    }
}