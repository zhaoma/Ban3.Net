// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

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
    public bool Judge( Bbi previousValue )
    {
        Score = 0;
        Keys = new List<string>();

        return true;
    }
}