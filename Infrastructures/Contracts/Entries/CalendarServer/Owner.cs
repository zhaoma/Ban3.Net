//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;
using System;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 
/// </summary>
public class Owner
{
    /// <summary>
    /// 编码
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "code")]
    public string Code { get; set; }

    /// <summary>
    /// 显示名称
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "displayName")]
    public string DisplayName { get; set; }

    /// <summary>
    /// 令牌
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "token")]
    public string Token { get; set; }

    /// <summary>
    /// 刷新令牌
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "refreshToken")]
    public string RefreshToken { get; set; }

    /// <summary>
    /// 令牌生成时间
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "tokenGenerated")]
    public DateTime TokenGenerated { get; set; }

    /// <summary>
    /// 令牌过期时间
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "tokenExpires")]
    public DateTime TokenExpires { get; set; }

    /// <summary>
    /// 上次同步时间
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "synchroTime")]
    public DateTime SynchroTime { get; set; }
}
