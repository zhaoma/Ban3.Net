//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Materials;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

public class MetaData : IZero
{
    /// <summary>
    /// 主领域
    /// </summary>
    public bool Primary { get; set; }

    /// <summary>
    /// 验证该字段是否正确
    /// </summary>
    public bool Verified { get; set; }

    /// <summary>
    /// 该领域的来源
    /// </summary>
    public Source? Source { get; set; }
}
