using System.Diagnostics.Contracts;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Consoles;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Extensions;
using Ban3.Platforms.TeamFoundationCollector.Application.CollectAndReport;
using System.Xml;
using Ban3.Infrastructures.NetMail;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models;
using System;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.WorkItemTracking;

//var monitorJobs = Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Settings.MonitorBranchSpec.Jobs;

//monitorJobs.ForEach(
//    o=>
//    {
//        o.Subject.WriteColorLine(ConsoleColor.Red);
//        var success= DevOps.Reportor.Parse(o);
//        if (success)
//        {
//            "...success".WriteSuccessLine();
//        }
//        else
//        {
//            "...failed".WriteColorLine(ConsoleColor.DarkYellow);
//        }
//    });


var monitorJobs = Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Settings.MonitorBranchSpec.Jobs;

monitorJobs.ForEach(
    o =>
    {
        o.Subject.WriteColorLine(ConsoleColor.Red);
        var success = DevOps.Reportor.Parse(o);
        if (success)
        {
            "...success".WriteSuccessLine();
        }
        else
        {
            "...failed".WriteColorLine(ConsoleColor.DarkYellow);
        }
    });

/*


static bool sendEmailViaOutlook(string sendusermail, string mailtitle, string mailcontent)
{
    try
    {
        Microsoft.Office.Interop.Outlook.Application olApp = new Microsoft.Office.Interop.Outlook.Application();
        Microsoft.Office.Interop.Outlook.MailItem mailItem = (Microsoft.Office.Interop.Outlook.MailItem)olApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
        mailItem.To = sendusermail;
        mailItem.Subject = mailtitle;
        mailItem.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatHTML;
        mailItem.HTMLBody = mailcontent;
        ((Microsoft.Office.Interop.Outlook._MailItem)mailItem).Send();
        mailItem = null;
        olApp = null;
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
        return false;
    }
    return true;
}

var m = Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Settings.MonitorBranchSpec.Jobs;

Console.WriteLine(m.ObjToJson());

foreach (var monitorJob in m)
{
    var records = DevOps.Reportor.Tfvc.GetBranchSpecMonitorRecords(monitorJob);
    records.ObjToJson().WriteColorLine(ConsoleColor.Red);
}


var mailServer = new Ban3.Infrastructures.NetMail.Entries.TargetServer
{
    ServerEndpoint = "smtp.office365.com",
    ServerPort = 587,
    EnableSsl = true,
    UserName = "zhifeng.zhao.ext@siemens-healthineers.com",
    Password = "100Pi=314.15926!!!",

    TagName= "STARTTLS/smtp.office365.com"
};
 mailServer.SendByMailKit(new List<string> { "zhifeng.zhao.ext@siemens-healthineers.com" }, null, "SSME SMS monitor", "HEllo") ;
Console.ReadKey();

*/
/*

await Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums.ServerResource
    .WorkItemTrackingSendMail
    .ExecuteVoid(new SendMail
    {
        Body=new SendMailBody
        {
            Body=new MailMessage
            {
                Subject = "subject",
                Body = "body",
                To=new EmailRecipients{EmailAddresses = new List<string>(){"zhifeng.zhao.ext@siemens-healthineers.com"}},

            }
        }
    });
Console.ReadKey()
var allTeams = DevOps.Collector.Core.LoadTeams();

allTeams
    //.Where(o => o.Name.Contains("SSME"))
    .ToList()
    .ForEach(
    o=>
    {
        new Action(() => {
        DevOps.Collector.SyncOneTeamSummary(o.Id,false);
        }).ExecuteAndTiming($"{o.Name}[{o.Id}]");
    });

*/

/*



DevOps.Collector.PrepareForce();
var request = new Request.Tfvc.GetChangesets
{
    OrderBy="id asc",
Skip=100,
    SearchCriteria=new Request.SubCondition.SearchCriteria
    {
        IncludeLinks=true,
        Author="author"
    }
};

request.QueryString().WriteColorLine(ConsoleColor.Red);

request.RequestQuery().WriteColorLine(ConsoleColor.DarkBlue);

Console.ReadKey();
*/
