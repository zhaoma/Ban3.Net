// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System.Collections.Generic;

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;

namespace Ban3.Infrastructures.GeneralImpl.Entries.Casino.Indicators.Outputs;

/// <summary>
/// 价格均线指标
/// </summary>
public class Ma : StockValue, IEvaluation<Ma>
{
    /// 
    public IEnumerable<Line<decimal>> Lines { get; set; }

    /// 
    public bool Judge( Ma previousValue )
    {
        Score = 0;
        Keys = new List<string>();

        return true;
    }
}