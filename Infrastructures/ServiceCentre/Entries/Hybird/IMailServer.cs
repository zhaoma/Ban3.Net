//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Hybird;

/// <summary>
/// 邮件服务器声明
/// </summary>
public interface IMailServer
{
    /// <summary>
    /// 地址
    /// </summary>
    [JsonProperty( "serverEndpoint" )]
    string ServerEndpoint { get; set; }

    /// <summary>
    /// 端口
    /// </summary>
    [JsonProperty( "serverPort" )]
    int ServerPort { get; set; }

    /// <summary>
    /// 使用SSL
    /// </summary>
    [JsonProperty( "enableSsl" )]
    bool EnableSsl { get; set; }

    /// <summary>
    /// 使用授权
    /// </summary>
    [JsonProperty( "useDefaultCredentials" )]
    bool UseDefaultCredentials { get; set; }

    /// <summary>
    /// 账号
    /// </summary>
    [JsonProperty( "userName" )]
    string UserName { get; set; }

    /// <summary>
    /// 密码
    /// </summary>
    [JsonProperty( "password" )]
    string Password { get; set; }
}