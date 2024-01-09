//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System.Collections.Generic;

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Inputs;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;
using Ban3.Infrastructures.ServiceCentre.Enums.Casino;

namespace Ban3.Infrastructures.GeneralImpl.Entries.Casino.Indicators;

/// <summary>
/// 计算输入条件声明
/// </summary>
public class Input : IInput
{
    ///
    public IStock Stock { get; set; }

    ///
    public IDictionary<AnalysisCycle, IEnumerable<IStockPrice>> StockPrices { get; set; }

    /// 
    public IFormulas Formulas { get; set; }
}