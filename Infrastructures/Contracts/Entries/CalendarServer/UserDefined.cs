//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System.Runtime.Serialization;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 自定义数据项
/// </summary>
public class UserDefined
{
    /// <summary>
    /// 用户指定的键.
    /// </summary>
    
    public string Key { get; set; }
}
