//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Materials;
using System;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 
/// </summary>
public class Owner : IZero
{
    /// <summary>
    /// 编码
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// 显示名称
    /// </summary>
    public string DisplayName { get; set; }

    /// <summary>
    /// 令牌
    /// </summary>
    public string Token { get; set; }

    /// <summary>
    /// 刷新令牌
    /// </summary>
    public string RefreshToken { get; set; }

    /// <summary>
    /// 令牌生成时间
    /// </summary>
    public DateTime TokenGenerated { get; set; }

    /// <summary>
    /// 令牌过期时间
    /// </summary>
    public DateTime TokenExpires { get; set; }

    /// <summary>
    /// 上次同步时间
    /// </summary>
    public DateTime SynchroTime { get; set; }
}
