// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Enums.Casino;

using System.Collections.Generic;

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators;

#nullable enable
namespace Ban3.Infrastructures.GeneralImpl.Entries.Casino.Indicators;

/// <summary>
/// 筛选条件
/// </summary>
public class StockCondition : IStockCondition
{
    /// 
    public AnalysisCycle? AnalysisCycle { get; set; }

    /// 
    public IEnumerable<string>? IncludeKeys { get; set; }

    /// 
    public IEnumerable<string>? ExcludeKeys { get; set; }
}