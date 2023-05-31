using Ban3.Infrastructures.Common.Extensions;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Extensions;
using Ban3.Platforms.TeamFoundationCollector.Application.CollectAndReport;
using Config= Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Config;
using Ban3.Platforms.TeamFoundationCollector.Application.CollectAndReport.Extensions;

    var teamName = args.Any() ? args[0]: Config.DefaultTeam;

    var identities =
        DevOps.Collector.Core.LoadTeams()
            .Where(o => o.Name == teamName)
            .ToList()
            .GetIdentitiesFromTeams();

    Console.WriteLine($"identity count={identities.Count}");

    await identities.ParallelExecuteAsync((identity) => { DevOps.Collector.SyncOneMemberSummary(identity.Id, true); },
        Config.MaxParallelTasks);
    Ban3.Infrastructures.PlatformInvoke.Helper.Prepare();

