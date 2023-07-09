using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using log4net;
using Microsoft.Office.Interop.Outlook;

namespace Ban3.Infrastructures.NetMail;

/// <summary>
/// 邮件扩展
/// </summary>
public static class Helper
{
    private static readonly ILog Logger = LogManager.GetLogger(typeof(Helper));

    /// <summary>
    /// 发送邮件
    /// </summary>
    /// <param name="server"></param>
    /// <param name="to"></param>
    /// <param name="cc"></param>
    /// <param name="subject"></param>
    /// <param name="mailHtml"></param>
    /// <returns></returns>
    public static bool Send(
	    this Entries.TargetServer server, 
        List<string>? to, 
        List<string>? cc, 
        string subject,
        string mailHtml)
    {
        var mail = new MailMessage
        {
            Subject = subject,
            Body = mailHtml,
            From = new MailAddress(server.UserName)
        };

        if (to != null)
        {
            foreach (var address in to)
            {
                mail.To.Add(address);
            }
        }

        if (cc != null)
        {
            foreach (var address in cc)
            {
                mail.CC.Add(address);
            }
        }

        return server.SendByOffice365(mail);
    }

    /// <summary>
    /// 用smtp服务器发送邮件
    /// </summary>
    /// <param name="server"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    public static bool SendByOffice365(
	    this Entries.TargetServer server, 
        MailMessage message)
    {
        try
        {
            var smtpclient = new SmtpClient(server.ServerEndpoint, server.ServerPort)
            {
                Credentials = new NetworkCredential(server.UserName, server.Password)
            };

            //SSL连接

            if (!string.IsNullOrEmpty(server.TagName))
            {
                smtpclient.TargetName = server.TagName;
            }

            smtpclient.EnableSsl = server.EnableSsl;

            //ServicePointManager.Expect100Continue = true;
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            //ServicePointManager.ServerCertificateValidationCallback = (s, c, h, e) => true;

            smtpclient.Send(message);

            return true;
        }
        catch (System.Exception ex)
        {
            Logger.Error(ex);
        }

        return false;
    }

    /// <summary>
    /// 用outlook发送邮件
    /// </summary>
    /// <param name="server"></param>
    /// <param name="to"></param>
    /// <param name="cc"></param>
    /// <param name="subject"></param>
    /// <param name="mailHtml"></param>
    /// <returns></returns>
    public static bool SendByOutlook(
        this Entries.TargetServer server,
        List<string>? to,
        List<string>? cc,
        string? subject,
        string? mailHtml)
    {
        try
        {
            var application = new Application();

            MailItem mailItem = (MailItem)application.CreateItem(OlItemType.olMailItem);

            if (to != null)
                mailItem.To = string.Join(";", to);

            if (cc != null)
                mailItem.CC = string.Join(";", cc);

            mailItem.Subject = subject;
            mailItem.BodyFormat = OlBodyFormat.olFormatHTML;
            mailItem.HTMLBody = mailHtml;
            mailItem.Send();

            return true;
        }
        catch (System.Exception ex)
        {
            Logger.Error(ex);
        }

        return false;
    }
}