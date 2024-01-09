//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System.Collections.Generic;

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;

namespace Ban3.Infrastructures.GeneralImpl.Entries.Casino.Indicators.Outputs;

/// <summary>
/// 顺势指标
/// </summary>
public class Cci : StockValue, IEvaluation<Cci>
{
    /// 
    public decimal CCI { get; set; }

    /// 
    public bool Judge( Cci previousValue, IStockPrice price )
    {
        Score = 0;
        Keys = new List<string>();

        return true;
    }
}