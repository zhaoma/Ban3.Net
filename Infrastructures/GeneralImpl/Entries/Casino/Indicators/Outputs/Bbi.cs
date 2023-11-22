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
/// 多空指标,Bull And Bear Index
/// </summary>
public class Bbi : StockValue, IEvaluation<Bbi>
{
    /// 
    public decimal BBI { get; set; }

    /// 
    public bool Judge( Bbi previousValue, out int score, out IEnumerable<string> keys )
    {
        score = 0;
        keys = new List<string>();

        return true;
    }
}