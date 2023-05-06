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

//DevOps.Reportor.ParseMonitorJobs();

var allTeams = DevOps.Collector.Core.LoadTeams();

allTeams
    .Where(o => o.Name.Contains("SSME"))
    .ToList()
    .ForEach(
    o=>
    {
        new Action(() => {
        DevOps.Collector.SyncOneTeamSummary(o.Id,true);
        }).ExecuteAndTiming($"{o.Name}[{o.Id}]");
    });

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
