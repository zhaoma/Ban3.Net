//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Enums.Hybird;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Hybird;

/// <summary>
/// 互联网主机声明
/// </summary>
public interface IInternetHost
{
    /// <summary>
    /// 认证方式
    /// </summary>
    [JsonProperty( "authenticationType" )]
    [JsonConverter( typeof( StringEnumConverter ) )]
    AuthenticationType AuthenticationType { get; set; }

    /// <summary>
    /// 域
    /// </summary>
    [JsonProperty( "domain" )]
    string Domain { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty( "baseUrl" )]
    string BaseUrl { get; set; }

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