//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System.Runtime.Serialization;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 链接地址
/// </summary>
public class Url:MetaValue
{
    /// <summary>
    /// URL的类型
    /// </summary>
    
    public string Type { get; set; }

    /// <summary>
    /// 查看账户的只读类型
    /// </summary>
    
    public string FormattedType { get; set; }
}
