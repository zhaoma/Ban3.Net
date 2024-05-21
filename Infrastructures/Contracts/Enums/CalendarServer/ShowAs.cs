//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

namespace Ban3.Infrastructures.Contracts.Enums.CalendarServer;

/// <summary>
/// 状态显示
/// 可取值为：free、tentative、busy、oof、workingElsewhere、unknown。
/// </summary>
public enum ShowAs
{
    Free,

    Tentative,

    Busy,

    Oof,

    WorkingElsewhere,

    Unknown
}
