// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.GeneralImpl.Entries.Casino.Items;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;

using System.Collections.Generic;

namespace Ban3.Infrastructures.GeneralImpl.Entries.Casino.Indicators;

/// <summary>
/// 计算输出结果声明
/// </summary>
public class Output : StockCode, IOutput
{
    /// 
    public int Score { get; set; }

    /// 
    public IEnumerable<string> Keys { get; set; }

    /// 
    public IStockData<IComputedResult> ComputedResults { get; set; }
}