// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System.ComponentModel;

namespace Ban3.Infrastructures.ServiceCentre.Enums.Casino;

/// <summary>
/// 交易所
/// </summary>
public enum BoardIs
{
    /// <summary />
    [Description("深证A股")]
    SZA = 11,

    /// <summary />
    [Description("中小板")]
    SZZ = 12,

    /// <summary />
    [Description("创业板")]
    SZC = 13,

    /// <summary />
    [Description("上证A股")]
    SHA = 21,

    /// <summary />
    [Description("科创板")]
    SHK = 22,

    /// <summary />
    [Description("其它")]
    Other = 10
}

