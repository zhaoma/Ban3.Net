using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Authentication;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Office.Interop.Outlook;
using MimeKit;
using Exception = System.Exception;
using SmtpClient = System.Net.Mail.SmtpClient;

namespace Ban3.Infrastructures.NetMail
{
    public static class Helper
    {
        public static bool SendByOffice365(this Entries.TargetServer server, MailMessage message)
        {
            try
            {
                SmtpClient smtpclient = new SmtpClient(server.ServerEndpoint, server.ServerPort);
                
                smtpclient.Credentials = new NetworkCredential(server.UserName, server.Password);

                //SSL连接

                if (!string.IsNullOrEmpty(server.TagName))
                    smtpclient.TargetName = server.TagName;
                smtpclient.EnableSsl = server.EnableSsl;

                //ServicePointManager.Expect100Continue = true;
                //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                //ServicePointManager.ServerCertificateValidationCallback = (s, c, h, e) => true;

                smtpclient.Send(message);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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

            return server.SendByOffice365(mail);
        }

        public static bool SendByOutlook(
            this Entries.TargetServer server, 
            List<string>? to, 
            List<string>? cc,
            string subject, 
            string mailHtml)
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
        public static  void SendByMailKit(this Entries.TargetServer server, List<string>? to, List<string>? cc, string subject, string mailHtml)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(server.UserName, server.UserName));

            if(to!=null)
                message.To.AddRange(to.Select(o=>new MailboxAddress(o,o)));

            if(cc!=null)
                message.Cc.AddRange(cc.Select(o => new MailboxAddress(o, o)));

            message.Subject = subject;
            //html or plain
            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = mailHtml
            };
            message.Body = bodyBuilder.ToMessageBody();

            using var client = new MailKit.Net.Smtp.SmtpClient
            {
                //SslProtocols = SslProtocols.Tls,
                //CheckCertificateRevocation = false,
                ServerCertificateValidationCallback = (s, c, h, e) => true
            };

             client.Connect(server.ServerEndpoint, server.ServerPort, SecureSocketOptions.StartTls);
             client.Authenticate
             (new SaslMechanismNtlm(new NetworkCredential(server.UserName,server.Password)));
                //(new SaslMechanismNtlmIntegrated()); 
            try
            {
                 client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (client.IsConnected) client.Disconnect(true);
            }
        }
    }
}

