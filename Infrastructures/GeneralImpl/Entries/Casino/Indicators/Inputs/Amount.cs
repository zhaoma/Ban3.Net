// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System.Collections.Generic;

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Inputs;
using Ban3.Infrastructures.ServiceCentre.Enums.Casino;

namespace Ban3.Infrastructures.GeneralImpl.Entries.Casino.Indicators.Inputs;

/// 成交量均线
public class Amount : Parameter, IAmount
{
    /// 
    public Amount()
    {
        IndicatorIs = IndicatorIs.AMOUNT;
    }

    /// 
    public Amount( IEnumerable<int> durations )
    {
        Durations = durations;
    }

    /// 
    public IEnumerable<int> Durations { get; set; } = new List<int> { 5, 10, 20, 30 };
}