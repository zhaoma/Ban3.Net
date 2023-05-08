using System.Diagnostics.Contracts;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Consoles;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Extensions;
using Ban3.Platforms.TeamFoundationCollector.Application.CollectAndReport;
using System.Xml;
using Ban3.Infrastructures.NetMail;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models;
using System;
using Ban3.Infrastructures.Consoles.Entries;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Build;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Reports;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.WorkItemTracking;
using Config= Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Config;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Pipelines;

//DevOps.Reportor.ParseMonitorJobs();

//var allTeams = DevOps.Collector.Core.LoadTeams();

//allTeams
//    //.Where(o => o.Name.Contains(Config.DefaultTeam))
//    .ToList()
//    .ForEach(
//    o =>
//    {
//        new Action(() =>
//        {
//            DevOps.Collector.SyncOneTeamSummary(o.Id, true);
//        }).ExecuteAndTiming($"{o.Name}[{o.Id}]");
//    });

//var id = "be8e66c2-1a5d-42b2-b5ac-3db32fe25b84";
//var r=DevOps.Collector.Tfvc.GetChangesets(id,1,1);
//r.ObjToJson().WriteColorLine(ConsoleColor.Red);

var definitionRefs = DevOps.Reportor.Build.LoadDefinitionRefs();

//.ListDefinitions(new ListDefinitions());

var tb = new ConsoleTable
{
    Columns = new List<string> { "Id", "Name","Path","CreatedDate" },
    Rows = definitionRefs
        .Where(o=>o.QueueStatus== DefinitionQueueStatus.Enabled)
        .Select(
        o=>new []
        {
            o.Id+"",o.Name,o.Path,o.CreatedDate
        }
        ).ToList()
};

tb.Writer(ConsoleColor.Blue);

var r = definitionRefs.FindLast(o => o.Id == 1455);
r.ObjToJson().WriteSuccessLine();

var ar = DevOps.Reportor.Build.PrepareFolders();
if (ar)
{
    var fs = DevOps.Reportor.Build.LoadFolders();
    Console.WriteLine(fs.Count);
    new ConsoleTable
    {
        Columns = new List<string> { "Path", "CreatedDate" },
        Rows = fs.Select(o => new[]
        {
            o.Path, o.CreatedOn
        }).ToList()
    }.Writer(ConsoleColor.DarkMagenta);

}

var build = DevOps.Reportor.Build.GetLastBuildForDefinition(1922);
$"Id={build?.Id}".ToString().WriteColorLine(ConsoleColor.Red);
$"Result={build?.Result}".ToString().WriteColorLine(ConsoleColor.Red);

$"Status={build?.Status}".ToString().WriteColorLine(ConsoleColor.Red);

$"BuildNumber={build?.BuildNumber}".ToString().WriteColorLine(ConsoleColor.Red);
$"QueueTime={build?.QueueTime}".ToString().WriteColorLine(ConsoleColor.Red);
$"StartTime={build?.StartTime}".ToString().WriteColorLine(ConsoleColor.Red);
$"FinishTime={build?.FinishTime}".ToString().WriteColorLine(ConsoleColor.Red);
DevOps.Reportor.Pipelines.PreparePipelines();
var pipelines = DevOps.Reportor.Pipelines.LoadPipelines();
(pipelines.Count+". pps").WriteColorLine(ConsoleColor.Yellow);

pipelines[0].ObjToJson().WriteSuccessLine();

new ConsoleTable
{
    Columns = new List<string>{"Id","Name","Folder"},
    Rows = pipelines.Select(o=>new []
    {
        o.Id, o.Name,o.Folder
    }).ToList()}.Writer();

var aaaas = DevOps.Reportor.Build.ListArtifacts(build!.Id);
aaaas.ObjToJson().WriteColorLine(ConsoleColor.Red);

foreach (var buildArtifact in aaaas.Value)
{
    var content=
    Path.Combine(buildArtifact.Resource.Data, @"SiemensTestSummary.md")
        .ReadFile();

    content.WriteSuccessLine();
}

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
