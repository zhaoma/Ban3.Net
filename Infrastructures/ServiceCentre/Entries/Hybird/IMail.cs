// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Hybird;

/// <summary>
/// 邮件声明
/// </summary>
public interface IMail
{
    /// <summary>
    /// 收件人
    /// </summary>
    [JsonProperty("to")]
    IEnumerable<IMailTo> To { get; set; }

    /// <summary>
    /// 抄送
    /// </summary>
    [JsonProperty("cc")]
    IEnumerable<IMailTo> Cc { get; set; }

    /// <summary>
    /// 主题
    /// </summary>
    [JsonProperty("subject")]
    string Subject { get; set; }

    /// <summary>
    /// 正文
    /// </summary>
    [JsonProperty("body")]
    string Body { get; set; }

    /// <summary>
    /// 发件人
    /// </summary>
    [JsonProperty("from")]
    IMailTo From { get; set; }
}