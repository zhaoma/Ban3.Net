//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System.Collections.Generic;

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;

namespace Ban3.Infrastructures.GeneralImpl.Entries.Casino.Indicators.Outputs;

/// <summary>
/// Energy Envelope
/// </summary>
public class Ene : StockValue, IEvaluation<Ene>
{
    /// 
    public decimal UPPER { get; set; }

    /// 
    public decimal ENE { get; set; }

    /// 
    public decimal LOWER { get; set; }

    /// 
    public bool Judge( Ene previousValue, IStockPrice price )
    {
        Score = 0;
        Keys = new List<string>();

        return true;
    }
}