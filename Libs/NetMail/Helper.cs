using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using MailKit.Security;
using Microsoft.Office.Interop.Outlook;
using MimeKit;
using Exception = System.Exception;

namespace Ban3.Infrastructures.NetMail
{


    public static class Helper
    {
        public static bool Send(this Entries.TargetServer server, MailMessage message)
        {
            try
            {
                SmtpClient smtpclient = new SmtpClient(server.ServerEndpoint, server.ServerPort);
                
                smtpclient.Credentials = new System.Net.NetworkCredential(server.UserName, server.Password);

                //SSL连接

                smtpclient.EnableSsl = server.EnableSsl;

                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                smtpclient.Send(message);

                return true;
            }
            catch (Exception ex)
            {

            }

            return false;
        }

        public static bool Send(this Entries.TargetServer server, List<string>? to, List<string>? cc,string subject, string mailHtml)
        {
            var mail = new MailMessage();

            mail.Subject = subject;
            mail.Body = mailHtml;
            mail.From = new MailAddress(server.UserName);
            if(to != null)
                foreach (var address in to)
                {
                    mail.To.Add(address);
                }

            if(cc!=null)
                foreach (var address in cc)
                {
                    mail.CC.Add(address);
                }

            return server.Send(mail);
        }

        public static bool SendByOutlook(this Entries.TargetServer server, List<string>? to, List<string>? cc, string subject, string mailHtml)
        {
            var application = new Application();
            MailItem mailItem = (MailItem)application.CreateItem(OlItemType.olMailItem);
            if(to!=null)
            mailItem.To = string.Join(";", to);
            if(cc!=null)
            mailItem.CC = string.Join(";", cc);
            mailItem.Subject = subject;
            mailItem.BodyFormat = OlBodyFormat.olFormatHTML;
            mailItem.HTMLBody = mailHtml;
            mailItem.Send();

            return true;
        }

        /// <summary>
        /// SmtpCommandException: 5.7.139 Authentication unsuccessful, SmtpClientAuthentication is disabled for the Tenant.
        /// Visit https://aka.ms/smtp_auth_disabled for more information.
        /// </summary>
        /// <param name="server"></param>
        /// <param name="to"></param>
        /// <param name="cc"></param>
        /// <param name="subject"></param>
        /// <param name="mailHtml"></param>
        /// <returns></returns>
        public static bool SendByMailKit(this Entries.TargetServer server, List<string>? to, List<string>? cc, string subject, string mailHtml)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(server.UserName, server.UserName));

            if(to!=null)
                message.To.AddRange(to.Select(o=>new MailboxAddress(o,o)));

            if(cc!=null)
                message.Cc.AddRange(cc.Select(o => new MailboxAddress(o, o)));

            message.Subject = subject;
            //html or plain
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = mailHtml;
            bodyBuilder.TextBody = mailHtml;
            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                //smtp服务器，端口，是否开启ssl
                client.Connect(server.ServerEndpoint, server.ServerPort, SecureSocketOptions.StartTls);
                client.Authenticate(server.UserName, server.Password);
                client.Send(message);
                client.Disconnect(true);
            }

            return true;
        }
    }
}

