using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Diagnostics.Metrics;
using System.Drawing.Text;
using System.Runtime.InteropServices.ComTypes;
using System.Text.Json.Serialization;
using Ban3.Infrastructures.Common.Attributes;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Consoles;
using Ban3.Infrastructures.NetHttp;
using Ban3.Infrastructures.NetHttp.Entries;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Extensions;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Build;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Core;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Pipelines;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.SubCondition;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Tfvc;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.WorkItemTracking;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Response.Tfvc;

//DevOps.Discussion
//    .PrepareThreads(39332);
    //.GetThread(39332);

//var ps=DevOps.Pipelines.ListPipelines(new ListPipelines());
//ps.ObjToJson().WriteSuccessLine();

//(ps.Value.Count+" pipelines found").WriteColorLine(ConsoleColor.Red);

//var p=ps.Value.Where(o=>o.Name.Contains("SHA.SERV"));
//p.ObjToJson().WriteSuccessLine();

DevOps.SendMail(new SendMail
{
    Body=new SendMailBody
    {
        Body = new MailMessage
        {
            To=new EmailRecipients{EmailAddresses = new (){"zhifeng.zhao.ext@siemens-healthineers.com"}},
            Body = "send from azure devops service",
            Subject = "send from azure devops service"
        }
    }
});

Console.ReadKey();

var pid = 1775;
//var pipelinInfo = DevOps.Pipelines.GetPipeline(new GetPipeline { PipelineId = pid });
//pipelinInfo.ObjToJson().WriteColorLine(ConsoleColor.Yellow);

//var runs = DevOps.Pipelines.ListRuns(pid);
//runs.ObjToJson().WriteColorLine(ConsoleColor.Yellow);

var runId = 926202;
//var r = DevOps.Pipelines.GetRun(pid, runId);
//r.ObjToJson().WriteSuccessLine();

//var ls = DevOps.Pipelines.ListLogs(pid, runId);
//ls.ObjToJson().WriteColorLine(ConsoleColor.Blue);

//var branches = DevOps.Tfvc.LoadBranches();
//foreach (var tfvcBranch in branches)
//{
//    tfvcBranch.Path.WriteSuccessLine();
//    tfvcBranch.ObjToJson().WriteColorLine(ConsoleColor.Red);
//}

var branchPath = @"$/CTS/Development/ICS/SHA.SERV";

//var b = DevOps.Tfvc.GetBranch(new GetBranch { Path = branchPath });
//b.ObjToJson().WriteSuccessLine();

//var builds = DevOps.Build.ListBuilds(new ListBuilds
//{
//    Top = 1,
//    BranchName = branchPath
//});
//builds.ObjToJson().WriteSuccessLine();

var buildId = 926979;
//var bb = DevOps.Build.GetBuild(buildId);
//bb.ObjToJson().WriteColorLine(ConsoleColor.Red);

//$"{buildId}:{bb.BuildNumber}->{bb.StartTime}-{bb.FinishTime}<-{bb.Status}".WriteColorLine(ConsoleColor.Red);

//var buildObj = DevOps.Build.GetBuildLogs(buildId );
////buildObj.ObjToJson().WriteSuccessLine();
//Console.WriteLine(buildObj.Value!.Count);
//foreach (var buildLog in buildObj.Value)
//{
//    $"{buildLog.Id}({buildLog.LineCount})@{buildLog.CreatedOn}-{buildLog.LastChangedOn}".WriteSuccessLine();
//    Console.WriteLine();
//}

//var log=DevOps.Build.GetBuildLog(new GetBuildLog
//{
//    BuildId=buildId,
//    LogId = 22
//});

//log.WriteSuccessLine();

//DevOps.Build.GetBuildLog(buildId,22,5,10)
//    .WriteColorLine(ConsoleColor.Red);

//var definitions = DevOps.Build.ListDefinitions(new ListDefinitions{Top = 1});
//definitions.ObjToJson().WriteErrorLine();

//var definitions = DevOps.Build.ListDefinitions(new ListDefinitions());
//definitions.Value!.ForEach(o =>
//{
//    o.ObjToJson().WriteSuccessLine();
//    Console.WriteLine();
//});


/*
var id = "be8e66c2-1a5d-42b2-b5ac-3db32fe25b84";

var cs = DevOps.Tfvc.GetChangesets(id, 1, 1);
cs.ObjToJson().WriteSuccessLine();

var cd = DevOps.Discussion.GetThreads(cs.Value.FirstOrDefault().ChangesetId);
cd.ObjToJson().WriteColorLine(ConsoleColor.Yellow);

var ss = DevOps.Tfvc.GetShelvesets(id, 1, 2);
ss.ObjToJson().WriteColorLine(ConsoleColor.DarkMagenta);

var ssss = ss.Value.Last();

var shelvesetId =ssss.Id;
shelvesetId.WriteColorLine(ConsoleColor.Red);
var shelvesetName = ssss.Name;
shelvesetName.WriteColorLine(ConsoleColor.Green);


var s = DevOps.Tfvc.GetShelveset(shelvesetId);
s.ObjToJson().WriteSuccessLine();

var sd = DevOps.Discussion.GetThreads(shelvesetName, id);
sd.ObjToJson().WriteColorLine(ConsoleColor.DarkGreen);

*/

//changesets.ObjToJson().WriteSuccessLine();


//var wi = DevOps.Tfvc.GetChangesetWorkItems(new GetChangesetWorkItems { Id = changesetId });
//wi.ObjToJson().WriteSuccessLine();

//var cc = DevOps.Tfvc.GetChangesetChanges(new GetChangesetChanges { Id = changesetId });
//cc.ObjToJson().WriteSuccessLine();

/*
var changesets = DevOps.Tfvc.GetChangesets(
    new GetChangesets
    {
        MaxCommentLength = 10000,
        SearchCriteria = new SearchCriteria
        {
            FromDate = now.AddDays(-1).ToString("yyyy-MM-dd"),
            ToDate = now.AddDays(1).ToString("yyyy-MM-dd"),
            IncludeLinks = true
        }
    }
);

changesets.ObjToJson().WriteSuccessLine();
var changesetId = 411825;
var c = DevOps.Tfvc.GetChangeset(changesetId);
c.ObjToJson().WriteSuccessLine();

Console.WriteLine();

var item = c.Changes[0].Item;

item.Path.WriteSuccessLine();

var ti = DevOps.Tfvc.GetItem(new GetItem
{
    IncludeContent = false,
    Path = item.Path
});

ti.ObjToJson().WriteSuccessLine();
(DevOps.Tfvc.PrepareBranches() ? "Branches ready" : "Branches prepare failed.").WriteErrorLine();
var branches = DevOps.Tfvc.GetBranches(new GetBranches());
branches.ObjToJson().WriteSuccessLine();

foreach (var branch in branches?.Value.OrderBy(o=>o.Path))
{
    $"{branch.Path}--{branch.Owner?.DisplayName}".WriteColorLine(ConsoleColor.DarkMagenta);
}

10.Times(
    () =>
    {
        var teams = DevOps.Core.LoadTeams();
        Console.WriteLine(teams.Count);

        $"{DateTime.Now.Subtract(now).TotalMilliseconds} ms spent.".WriteSuccessLine();
        now = DateTime.Now;
    }
);
var teams=DevOps.Core.GetTeams(new GetTeams
{
    ExpandIdentity = false,
    Top=10000
});

if (teams is { Success: true, Value: { } })
{
    var r = 1;
    (teams.Count + ".teams found.").WriteSuccessLine();
    
    teams.Value
        .AsParallel()
        .WithDegreeOfParallelism(Environment.ProcessorCount / 2)
        .ForAll(o =>
        {
            $"parse {r}/{teams.Value.Count} : {o.Name}".WriteColorLine(ConsoleColor.Blue);
            var members = DevOps.Core.GetTeamMembers(o);
            if (!members.Success || members.Value == null) return;

            o.Members = members.Value;

            //foreach (var teamMember in o.Members)
            //{
            //    teamMember.Identity!.Portrait = DevOps.Core.GetPortrait(teamMember.Identity).SavedPath;
            //}

            r++;
        });

    teams.ObjToJson().WriteSuccessLine();

    var file = teams.Value.SetsFile();
    $"write to [{file}]".WriteWarningLine();
    file.WriteFile(teams.ObjToJson());
}
else
{
    "GetTeams failure.".WriteErrorLine();
}

var focusTeam=teams.Value.FirstOrDefault(o=>o.Name== "SERVICE-SMS_SSME");
if (focusTeam != null)
{
    focusTeam.Name.WriteSuccessLine();
    focusTeam.ObjToJson().WriteSuccessLine();

    var members = DevOps.Core.GetTeamMembers(focusTeam);
    members.ObjToJson().WriteColorLine(ConsoleColor.DarkMagenta);

    foreach (var member in members.Value)
    {
        member.Identity.DisplayName.WriteSuccessLine();
        var downloaded=DevOps.Core.GetPortrait(member.Identity);
        downloaded.SavedPath.WriteSuccessLine();
        Console.WriteLine();
    }
}

DevOps
 DevOps.Pipelines.Get()
var r=Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums.ServerResource.TfvcGetChangeset.Execute<GetChangesetResult>(
    new GetChangeset
    {
        Id = 411095
    }
    );

Console.WriteLine(r.ObjToJson());

5.Times(()=>{
Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Config.Target.ObjToJson().WriteSuccessLine();
});

var host = new Ban3.Infrastructures.NetHttp.Entries.TargetHost
{
    BaseUrl = "https://tfs-cr.healthcare.siemens.com:8090",
    AuthenticationType = "NTLM",
    UserName = "zhifeng.zhao.ext@siemens-healthineers.com",
    Password = "100Pi=314.15926!!!"
};

var url =
    $"{host.BaseUrl}/tfs/CT/_apis/tfvc/items/$/CTS/Development/ICS/SHA.SERV/CT.Serv/Tst/BE.Impl/XrayPath/XrayPathConfig.cs?versionType=Latest&versionOptions=None";

var resource=new TargetResource
{
    Url=url
};

host.Send(resource).ContinueWith(task =>
{
    var result = task.Result.Content.ReadAsStringAsync().Result;
    Console.WriteLine(result);
});

Console.ReadKey();

var result = host.Request(resource);
Console.WriteLine(result.Content.ReadAsStringAsync().Result);
*/

