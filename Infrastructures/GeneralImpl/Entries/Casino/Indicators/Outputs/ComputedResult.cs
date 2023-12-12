//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI . 2023-12-10
//  ————————————————————————————————————————————————————————————————————————————

using System.Collections.Generic;

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Outputs;
using Ban3.Infrastructures.ServiceCentre.Enums.Casino;

namespace Ban3.Infrastructures.GeneralImpl.Entries.Casino.Indicators.Outputs;

public class ComputedResult : StockValue, IComputedResult
{
    public ComputedResult() {}

    public IEnumerable<IStockValue> Values { get; set; }

    public IndicatorIs IndicatorIs { get; set; }
}