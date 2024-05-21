//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Materials;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 传记信息
/// </summary>
public class Biographie : MetaBase,IZero
{
    /// <summary>
    /// 简短传记
    /// </summary>
    public string Type { get; set; } = string.Empty;
}
