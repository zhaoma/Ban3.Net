// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System.ComponentModel;

namespace Ban3.Infrastructures.ServiceCentre.Enums.Casino;

/// <summary>
/// 周期定义，日周月，M60
/// </summary>
public enum AnalysisCycle
{
    /// <summary />
    [Description("日线")]
    Daily = 1,

    /// <summary />
    [Description("周线")]
    Weekly = 2,

    /// <summary />
    [Description("月线")]
    Monthly = 3
}

