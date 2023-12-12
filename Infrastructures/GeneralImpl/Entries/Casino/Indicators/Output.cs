// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System.Collections.Generic;

using Ban3.Infrastructures.GeneralImpl.Entries.Casino.Items;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;
using Ban3.Infrastructures.ServiceCentre.Enums.Casino;

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
    public IDictionary<AnalysisCycle, IEnumerable<IComputedResult>> ComputedResults { get; set; }
}