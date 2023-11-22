// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.GeneralImpl.Entries.Casino.Items;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators;

using System.Collections.Generic;

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;

namespace Ban3.Infrastructures.GeneralImpl.Entries.Casino.Indicators.Outputs;

/// <summary>
/// 乖离率
/// </summary>
public class Bias : StockValue, IEvaluation<Bias>
{
    /// 
    public decimal BIAS { get; set; }

    /// 
    public decimal BIASMA { get; set; }

    /// 
    public bool Judge( Bias previousValue, out int score, out IEnumerable<string> keys )
    {
        score = 0;
        keys = new List<string>();

        return true;
    }
}