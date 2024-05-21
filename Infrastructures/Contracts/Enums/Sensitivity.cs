//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

namespace Ban3.Infrastructures.Contracts.Enums;

/// <summary>
/// 信息敏感度
/// 可能的值是：normal、personal、private、confidential。
/// </summary>
public enum Sensitivity
{
    Normal,

    Personal,

    Private,

    Confidential
}
