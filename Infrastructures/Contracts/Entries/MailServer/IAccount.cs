//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

namespace Ban3.Infrastructures.Components.Entries.MailServer;

/// <summary>
/// 邮件发送账号
/// </summary>
public interface IAccount
{
    /// <summary>
    /// 服务器地址
    /// </summary>
    string ServerEndpoint { get; set; }

    /// <summary>
    /// 服务器端口
    /// </summary>
    int ServerPort { get; set; }

    /// <summary>
    /// SSL
    /// </summary>
    bool EnableSsl { get; set; }

    /// <summary>
    /// 账号
    /// </summary>
    string UserName { get; set; }

    /// <summary>
    /// 密码
    /// </summary>
    string Password { get; set; }

    string TagName { get; set; }
}
