// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

using System.Collections.Generic;

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators;

namespace Ban3.Infrastructures.GeneralImpl.Entries.Casino.Indicators;

/// <summary>
/// 公式声明
/// </summary>
public class Formulas : IFormulas
{
    /// 
    public IEnumerable<IParameter> Parameters { get; set; }

    /// 
    public int MaxScore { get; set; }
}