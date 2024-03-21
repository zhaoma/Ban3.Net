//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com   2023
//  WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System.ComponentModel;

namespace Ban3.Infrastructures.ServiceCentre.Enums.Casino;

/// <summary>
/// 股东持股变化类型
/// </summary>
public enum HoldChange
{
    /// <summary>
    /// 无变化
    /// </summary>
    [Description("未变")]
    None,

    /// <summary>
    /// 股东增持
    /// </summary>
    [Description("增持")]
    Increased,

    /// <summary>
    /// 股东减持
    /// </summary>
    [Description("减持")]
    Decreased
}

