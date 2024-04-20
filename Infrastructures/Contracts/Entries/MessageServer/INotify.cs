//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System.Collections.Generic;

namespace Ban3.Infrastructures.Components.Entries.MessageServer;

/// <summary>
/// 消息
/// </summary>
public interface INotify
{
    /// <summary>
    /// 通知来源
    /// </summary>
    string From { get; set; }

    /// <summary>
    /// 通知目标
    /// </summary>
    string To { get; set; }

    /// <summary>
    /// 控制码
    /// </summary>
    string ControlCode { get; set; }

    /// <summary>
    /// 通知主体
    /// </summary>
    Dictionary<string,object> Body { get; set; }
}
