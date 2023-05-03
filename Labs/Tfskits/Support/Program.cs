using Ban3.Infrastructures.Common.Extensions;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Extensions;
using Ban3.Infrastructures.Consoles;

using Request = Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request;

/*
var allTeams = DevOps.Core.LoadTeams();

allTeams
    .Where(o => o.Name.Contains("SSME"))
    .ToList()
    .ForEach(
    o=>
    {
        new Action(() => {
        DevOps.SyncOneTeamSummary(o.Id,false);
        }).ExecuteAndTiming($"{o.Name}[{o.Id}]");
    });

DevOps.Collector.PrepareForce();
*/
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
