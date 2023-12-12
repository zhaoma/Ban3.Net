// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System.Collections.Generic;

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;

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
    public bool Judge( Mtm previousValue )
    {
        Score = 0;
        Keys = new List<string>();

        return true;
    }
}