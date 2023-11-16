// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.GeneralImpl.Entries.Casino.Items;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators;

using System.Collections.Generic;

namespace Ban3.Infrastructures.GeneralImpl.Entries.Casino.Indicators.Outputs;

/// <summary>
/// Energy Envelope
/// </summary>
public class Ene : StockFeature, IEvaluation<Ene>
{
    /// 
    public decimal UPPER { get; set; }

    /// 
    public decimal ENE { get; set; }

    /// 
    public decimal LOWER { get; set; }

    /// 
    public bool Judge( Ene previousValue, out int score, out IEnumerable<string> keys )
    {
        score = 0;
        keys = new List<string>();

        return true;
    }
}