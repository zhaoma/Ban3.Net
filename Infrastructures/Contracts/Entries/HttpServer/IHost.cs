//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

namespace Ban3.Infrastructures.Components.Entries.HttpServer;

/// <summary>
/// HTTP请求主机
/// </summary>
public interface IHost
{
    /// <summary>
    /// 匿名访问
    /// </summary>
    bool Anonymous { get; set; }

    /// <summary>
    /// 主机地址
    /// </summary>
    string BaseUrl { get; set; }

    /// <summary>
    /// 用户名
    /// </summary>
    string UserName { get; set; }

    /// <summary>
    /// 密码
    /// </summary>
    string Password { get; set; }

    /// <summary>
    /// 域名
    /// </summary>
    string Domain { get; set; }

    /// <summary>
    /// 验证方式
    /// </summary>
    string AuthenticationType { get; set; }
}
