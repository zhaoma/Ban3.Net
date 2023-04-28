using Ban3.Infrastructures.Common.Extensions;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Extensions;

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