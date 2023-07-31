/* -------------------------------------------------------------------------------------------------
   Copyright (C) Siemens Healthcare GmbH 2023, All rights reserved. Restricted.
   ------------------------------------------------------------------------------------------------- */

using System.Collections.Generic;
using System.Net.Mail;

namespace Ban3.Infrastructures.NetMail.Entries;

public class Mail
{
    public List<string>? To { get; set; }
    public List<string>? CC { get; set; }
    public string Subject { get; set; }
    public string HtmlBody { get; set; }

    public string From
    {
        get;
        set;
    }

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