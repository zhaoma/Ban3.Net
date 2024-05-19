using Ban3.Infrastructures.Contracts.Entries.CalendarServer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.Contracts.Materials;

public interface IOrganizer
{
    /// <summary>
    /// 显示名称
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "displayName")]
    string DisplayName { get; set; }

    /// <summary>
    /// 邮件
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "email")]
    string Email { get; set; }

    /// <summary>
    /// 配置文件ID
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "id")]
    string Id { get; set; }

    /// <summary>
    /// 是自己
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "self")]
    bool Self { get; set; }

    /// <summary>
    /// 邮箱(MS)
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "emailAddress")]
    IEmailAddress? EmailAddress { get; set; }
}
