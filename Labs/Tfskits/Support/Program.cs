using Ban3.Infrastructures.Common.Extensions;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Extensions;
using Ban3.Platforms.TeamFoundationCollector.Application.CollectAndReport;
using Config= Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Config;
using Ban3.Platforms.TeamFoundationCollector.Application.CollectAndReport.Extensions;

var identities =
    DevOps.Collector.Core.LoadTeams()
        .Where(o => o.Name==Config.DefaultTeam)
        .ToList()
        .GetIdentitiesFromTeams();

Console.WriteLine($"identity count={identities.Count}");

identities.ParallelExecute((identity) =>
{
    DevOps.Collector.SyncOneMemberSummary(identity.Id,true);
},Config.MaxParallelTasks);

/*

DevOps.Reportor.ParseMonitorJobs();

var job = Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Settings.MonitorBuildReports.Jobs
    .FindLast(o => o.Id == "1");

Console.WriteLine(DevOps.Reportor.ParseBuildReport(job));

*/