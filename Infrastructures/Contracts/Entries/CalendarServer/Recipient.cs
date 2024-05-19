//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 收信人
/// https://developers.google.com/calendar/v3/reference/events#resource-representations
/// </summary>
[Serializable, DataContract]
public class Recipient
{
    /// <summary>
    /// 显示名称
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "displayName")]
    public string DisplayName { get; set; }

    /// <summary>
    /// 邮件
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "email")]
    public string Email { get; set; }

    /// <summary>
    /// 配置文件ID
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "id")]
    public string Id { get; set; }

    /// <summary>
    /// 是自己
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "self")]
    public bool Self { get; set; }

    /// <summary>
    /// 邮箱(MS)
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "emailAddress")]
    public EmailAddress EmailAddress { get; set; }
}
