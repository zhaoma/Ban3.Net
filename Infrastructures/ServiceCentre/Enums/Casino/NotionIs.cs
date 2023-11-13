// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System.ComponentModel;

namespace Ban3.Infrastructures.ServiceCentre.Enums.Casino;

/// <summary>
/// 题材分组
/// </summary>
public enum NotionIs
{
    /// <summary />
    [Description("概念")]
    Concept = 1,

    /// <summary />
    [Description("地区")]
    Region = 3,

    /// <summary />
    [Description("行业")]
    Industry = 4
}

