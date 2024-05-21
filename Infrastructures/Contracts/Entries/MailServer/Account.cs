//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Materials;

namespace Ban3.Infrastructures.Components.Entries.MailServer;

/// <summary>
/// 邮件发送账号
/// </summary>
public class Account : IZero
{
    /// <summary>
    /// 服务器地址
    /// </summary>
    public string ServerEndpoint { get; set; } = string.Empty;

    /// <summary>
    /// 服务器端口
    /// </summary>
    public int ServerPort { get; set; }

    /// <summary>
    /// SSL
    /// </summary>
    public bool EnableSsl { get; set; }

    /// <summary>
    /// 账号
    /// </summary>
    public string UserName { get; set; } = string.Empty;

    /// <summary>
    /// 密码
    /// </summary>
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public string TagName { get; set; } = string.Empty;
}
