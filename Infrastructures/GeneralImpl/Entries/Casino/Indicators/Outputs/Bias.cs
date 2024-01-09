//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System.Collections.Generic;

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;

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
    public bool Judge( Bias previousValue, IStockPrice price )
    {
        Score = 0;
        Keys = new List<string>();

        return true;
    }
}