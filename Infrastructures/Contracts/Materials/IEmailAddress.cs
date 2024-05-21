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
public interface IEmailAddress : IZero
{
    /// <summary>
    /// 显示名称
    /// The display name of the person or entity.
    /// </summary>
    string Name { get; set; }

    /// <summary>
    /// 邮件
    /// The email address of the person or entity.
    /// </summary>
    string Address { get; set; }
}
