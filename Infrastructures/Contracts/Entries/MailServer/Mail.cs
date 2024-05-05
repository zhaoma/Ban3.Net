//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System.Collections.Generic;

namespace Ban3.Infrastructures.Components.Entries.MailServer;

/// <summary>
/// 邮件发送目标邮件
/// </summary>
public class Mail
{
    /// <summary>
    /// 收件人
    /// </summary>
    public Dictionary<string, string> To { get; set; }

    /// <summary>
    /// 抄送
    /// </summary>
    public Dictionary<string, string> CC { get; set; }

    /// <summary>
    /// 主题
    /// </summary>
    public string Subject { get; set; } = string.Empty;

    /// <summary>
    /// 正文
    /// </summary>
    public string HtmlBody { get; set; } = string.Empty;

    /// <summary>
    /// 发件人
    /// </summary>
    public KeyValuePair<string, string> From { get; set; }
}
