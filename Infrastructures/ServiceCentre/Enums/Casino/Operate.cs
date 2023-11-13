// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System.ComponentModel;

namespace Ban3.Infrastructures.ServiceCentre.Enums.Casino;

/// <summary>
/// 建议操作
/// </summary>
public enum Operate
{
    /// <summary />
    [Description("买进")]
    Buy = 1,

    /// <summary />
    [Description("持有")]
    Keep = 2,

    /// <summary />
    [Description("卖出")]
    Sell = 3,

    /// <summary />
    [Description("舍弃")]
    Left = 4
}

