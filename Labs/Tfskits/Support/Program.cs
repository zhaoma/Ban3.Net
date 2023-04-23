using System.Diagnostics.Contracts;
using System.Diagnostics.Metrics;
using System.Runtime.InteropServices.ComTypes;
using System.Text.Json.Serialization;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Consoles;
using Ban3.Infrastructures.NetHttp;
using Ban3.Infrastructures.NetHttp.Entries;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Extensions;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Core;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Tfvc;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Response.Tfvc;

var now = DateTime.Now;

10.Times(
    () =>
    {
        var teams = DevOps.Core.LoadTeams();
        Console.WriteLine(teams.Count);

        $"{DateTime.Now.Subtract(now).TotalMilliseconds} ms spent.".WriteSuccessLine();
        now = DateTime.Now;
    }
);
/*

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

