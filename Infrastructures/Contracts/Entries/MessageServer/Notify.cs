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
    /// 交换器
    /// </summary>
    public string Exchange { get; set; } = string.Empty;

    /// <summary>
    /// 路由键名
    /// </summary>
    public string RoutingKey { get; set; } = string.Empty;

    /// <summary>
    /// 控制码
    /// </summary>
    public string ControlCode { get; set; } = string.Empty;

    /// <summary>
    /// 通知主体
    /// </summary>
    public Dictionary<string, object> Body { get; set; }
}
