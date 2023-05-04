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

/*
var m = Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Settings.MonitorBranchSpec.Jobs;

Console.WriteLine(m.ObjToJson());

m.ForEach(job =>
{
    var targets = DevOps.Collector.Tfvc.GetBranchSpecDependencies(job.TargetPath);
    var guidelines= DevOps.Collector.Tfvc.GetBranchSpecDependencies(job.GuidelinePath);

    targets.ObjToJson().WriteColorLine(ConsoleColor.Green);
    guidelines.ObjToJson().WriteColorLine(ConsoleColor.Blue);

    var ns = targets.Where(x => guidelines.Any(y => y.Name == x.Name && y.Version != x.Version));
    if (ns.Any())
    {
        $"SEND warning".WriteColorLine(ConsoleColor.Red);
        ns.ObjToJson().WriteColorLine(ConsoleColor.Red);
    }
    else
    {
        $"All Match".WriteColorLine(ConsoleColor.Yellow);
    }
});
*/
var mailServer = new Ban3.Infrastructures.NetMail.Entries.TargetServer
{
    ServerEndpoint = "smtp.office365.com",
    ServerPort = 587,
    EnableSsl = true,
    UserName = "zhifeng.zhao.ext@siemens-healthineers.com",
    Password = "100Pi=314.15926!!!"
};
(mailServer.SendByMailKit(new List<string> { "zhifeng.zhao.ext@siemens-healthineers.com" }, null, "SSME SMS monitor", "HEllo") ? "ok" : "failured")
    .WriteWarningLine();

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
