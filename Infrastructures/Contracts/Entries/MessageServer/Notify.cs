//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Materials;
using System.Collections.Generic;

namespace Ban3.Infrastructures.Components.Entries.MessageServer;

/// <summary>
/// 消息
/// </summary>
public class Notify : IZero
{
    /// <summary>
    /// 通知来源
    /// </summary>
    public string From { get; set; } = string.Empty;

    /// <summary>
    /// 通知目标
    /// </summary>
    public string To { get; set; } = string.Empty;

    /// <summary>
    /// 控制码
    /// </summary>
    public string ControlCode { get; set; } = string.Empty;

    /// <summary>
    /// 通知主体
    /// </summary>
    public Dictionary<string, object> Body { get; set; }
}
