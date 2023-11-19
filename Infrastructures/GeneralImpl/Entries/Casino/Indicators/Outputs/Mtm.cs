// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.GeneralImpl.Entries.Casino.Items;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators;

using System.Collections.Generic;

namespace Ban3.Infrastructures.GeneralImpl.Entries.Casino.Indicators.Outputs;

/// <summary>
/// 动量指标,Momentum Index
/// </summary>
public class Mtm : StockValue, IEvaluation<Mtm>
{
    /// 
    public decimal MTM { get; set; }

    /// 
    public decimal MAMTM { get; set; }

    /// 
    public bool Judge( Mtm previousValue, out int score, out IEnumerable<string> keys )
    {
        score = 0;
        keys = new List<string>();

        return true;
    }
}