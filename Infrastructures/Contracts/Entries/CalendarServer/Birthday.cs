//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System;
using System.Runtime.Serialization;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 生日信息
/// </summary>
public class Birthday:MetaBase
{
    /// <summary>
    /// 生日日期
    /// </summary>
    
    public DateTime Date { get; set; }

    /// <summary>
    ///生日的自由格式
    /// </summary>
    
    public string Text { get; set; }
}
