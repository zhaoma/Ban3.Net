using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 邮件地址
/// Includes the name and SMTP address of the attendee.
/// https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/resources/emailaddress
/// </summary>
public class EmailAddress
{
    /// <summary>
    /// 显示名称
    /// The display name of the person or entity.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "name")]
    public string Name { get; set; }

    /// <summary>
    /// 邮件
    /// The email address of the person or entity.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "address")]
    public string Address { get; set; }

    /// <summary>
    /// 构造函数
    /// </summary>
    public EmailAddress()
    {

    }

    /// <summary>
    /// 实例化
    /// </summary>
    /// <param name="email"></param>
    /// <param name="name"></param>
    public EmailAddress(string email, string name)
    {
        Name = name;
        Address = email;
    }
}
