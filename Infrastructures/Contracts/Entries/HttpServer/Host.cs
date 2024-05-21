//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Materials;

namespace Ban3.Infrastructures.Components.Entries.HttpServer;

/// <summary>
/// HTTP请求主机
/// </summary>
public class Host:IZero
{
    /// <summary>
    /// 匿名访问
    /// </summary>
    public bool Anonymous { get; set; }

    /// <summary>
    /// 主机地址
    /// </summary>
    public string BaseUrl { get; set; } = string.Empty;

    /// <summary>
    /// 用户名
    /// </summary>
    public string UserName { get; set; } = string.Empty;

    /// <summary>
    /// 密码
    /// </summary>
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// 域名
    /// </summary>
    public string Domain { get; set; } = string.Empty;

    /// <summary>
    /// 验证方式
    /// </summary>
    public string AuthenticationType { get; set; } = string.Empty;
}
