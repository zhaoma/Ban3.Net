/* -------------------------------------------------------------------------------------------------
   Copyright (C) Siemens Healthcare GmbH 2023, All rights reserved. Restricted.
   ------------------------------------------------------------------------------------------------- */

using System.Collections.Generic;
using System.Net.Mail;

namespace Ban3.Infrastructures.NetMail.Entries;

/// <summary>
/// 
/// </summary>
public class Mail
{
    /// <summary>
    /// 收件人
    /// </summary>
    public List<string>? To { get; set; }

    /// <summary>
    /// 抄送
    /// </summary>
    public List<string>? CC { get; set; }

    /// <summary>
    /// 主题
    /// </summary>
    public string Subject { get; set; }

    /// <summary>
    /// 邮件正文
    /// </summary>
    public string HtmlBody { get; set; }

    /// <summary>
    /// 发件人
    /// </summary>
    public string From
    {
        get;
        set;
    }

    /// 
    public Mail()
    {
        To = null;
        CC = null;
        Subject = string.Empty;
        HtmlBody = string.Empty;
        From = string.Empty;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <param name="cc"></param>
    /// <param name="subject"></param>
    /// <param name="htmlBody"></param>
    public Mail(
        string from,
        string to, 
        string cc,
        string subject, 
        string htmlBody)
    {
        From = from;
        To = new List<string> { to };
        if (!string.IsNullOrEmpty(cc))
            CC = new List<string> { cc };
        Subject = subject;
        HtmlBody = htmlBody;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <param name="cc"></param>
    /// <param name="subject"></param>
    /// <param name="htmlBody"></param>
    public Mail(
        string from,
        List<string> to,
        List<string>? cc, string subject, string htmlBody)
    {
        From = from;
        To = to;
        CC = cc;
        Subject = subject;
        HtmlBody = htmlBody;
    }

    /// <summary>
    /// 转MailMessage
    /// </summary>
    /// <returns></returns>
    public MailMessage MailMessage()
    {
        var mail = new MailMessage
        {
            Subject = Subject,
            Body = HtmlBody,
            From = new MailAddress(From)
        };

        if (To != null)
        {
            foreach (var address in To)
            {
                mail.To.Add(address);
            }
        }

        if (CC != null)
        {
            foreach (var address in CC)
            {
                mail.CC.Add(address);
            }
        }

        return mail;
    }
}