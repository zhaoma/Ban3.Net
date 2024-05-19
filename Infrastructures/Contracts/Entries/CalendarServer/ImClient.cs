//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 即时通讯客户端
/// </summary>
public class ImClient
{
    /// <summary>
    /// 客户端使用名
    /// </summary>
    
    public string Username { get; set; }

    /// <summary>
    /// 客户端的类型
    /// </summary>
    
    public string Type { get; set; }

    /// <summary>
    /// 翻译或格式化
    /// </summary>
    
    public string FormattedType { get; set; }

    /// <summary>
    /// 客户机的协议
    /// </summary>
    
    public string Protocol { get; set; }

    /// <summary>
    /// 查看账户时的只读协议
    /// </summary>
    
    public string FormattedProtocol { get; set; }
}
