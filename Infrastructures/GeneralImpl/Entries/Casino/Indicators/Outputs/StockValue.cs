// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System.Collections.Generic;

using Ban3.Infrastructures.GeneralImpl.Entries.Casino.Items;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;

namespace Ban3.Infrastructures.GeneralImpl.Entries.Casino.Indicators.Outputs;

/// <summary>
/// 标的特征声明
/// </summary>
public class StockValue : StockRecord, IStockValue
{
    /// 
    public int Score { get; set; }

    /// 
    public IEnumerable<string> Keys { get; set; }
}