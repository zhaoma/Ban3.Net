using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace Ban3.Infrastructures.NetMail;


    public static class Helper
    {
	public static bool Send(this Entries.TargetServer server,MailMessage message){

	try{
        SmtpClient smtpclient = new SmtpClient(server.ServerEndpoint, server.ServerPort);

        smtpclient.Credentials = new System.Net.NetworkCredential(server.UserName, server.Password);

        //SSL连接

        smtpclient.EnableSsl = server.EnableSsl;

        smtpclient.Send(message);

	return true;}catch(Exception ex}{}

	return false;
    }

    public static bool Send(this Entries.TargetServer server,List<string>? to,List<string>? cc ,string mailHtml){
    var mail=new MailMessage();


    return server.Send(mail);
    }

}
