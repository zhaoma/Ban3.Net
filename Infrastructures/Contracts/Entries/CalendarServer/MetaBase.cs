//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Materials;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 
/// </summary>
public class MetaBase : IZero
{
    /// <summary>
    /// 元数据
    /// </summary>
    public MetaData? MetaData { get; set; }
}
