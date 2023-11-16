// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System.Collections.Generic;

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Inputs;
using Ban3.Infrastructures.ServiceCentre.Enums.Casino;

namespace Ban3.Infrastructures.GeneralImpl.Entries.Casino.Indicators.Inputs;

/// 收盘价均线
public class Ma : Parameter, IMa
{
    /// 
    public Ma()
    {
        IndicatorIs = IndicatorIs.MA;
    }

    /// 
    public Ma( IEnumerable<int> durations )
    {
        Durations = durations;
    }

    /// 
    public IEnumerable<int> Durations { get; set; } = new List<int> { 5, 10, 20, 30 };
}