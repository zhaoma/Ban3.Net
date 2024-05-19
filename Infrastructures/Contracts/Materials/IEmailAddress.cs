//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

namespace Ban3.Infrastructures.Contracts.Materials;

/// <summary>
/// 邮件地址
/// Includes the name and SMTP address of the attendee.
/// https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/resources/emailaddress
/// </summary>
public interface IEmailAddress
{
    /// <summary>
    /// 显示名称
    /// The display name of the person or entity.
    /// </summary>
    [JsonProperty("name",NullValueHandling = NullValueHandling.Ignore )]
    string Name { get; set; }

    /// <summary>
    /// 邮件
    /// The email address of the person or entity.
    /// </summary>
    [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore )]
    string Address { get; set; }
}
