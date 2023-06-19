﻿using System.Net;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Consoles;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Extensions;
using Ban3.Platforms.TeamFoundationCollector.Application.CollectAndReport;
using Config= Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Config;
using Ban3.Platforms.TeamFoundationCollector.Application.CollectAndReport.Extensions;

var teamName = args.Any() ? args[0] : Config.DefaultTeam;

switch (teamName)
{
    case "--all":
        DevOps.Collector.Core.PrepareTeams(true);
        break;

    case "--everyone":
        var all =
            DevOps.Collector.Core.LoadTeams()
                .ToList()
                .GetIdentitiesFromTeams();
        Console.WriteLine($"identity count={all.Count}");

        all.ParallelExecute(
            (identity) => { DevOps.Collector.SyncOneMemberSummary(identity.Id, true); },
            Config.MaxParallelTasks);
        break;

    case "--key":
        var keys =
            DevOps.Collector.Core.LoadTeams()
                .Where(o => o.Name.Contains(args[1]))
                .ToList()
                .GetIdentitiesFromTeams();
        Console.WriteLine($"identity count={keys.Count}");

        keys.ParallelExecute(
            (identity) =>
            {
                var now=DateTime.Now;
                DevOps.Collector.SyncOneMemberSummary(identity.Id, true);
                Console.WriteLine( $"{identity.DisplayName} spent {DateTime.Now.Subtract(now).TotalMilliseconds} ms.");
            },
            Config.MaxParallelTasks);
        break;
        
    case "--others":
        var others =
            DevOps.Collector.Core.LoadTeams()
                .Where(o => o.Name!= Config.DefaultTeam)
                .ToList()
                .GetIdentitiesFromTeams();
        Console.WriteLine($"identity count={others.Count}");

        others.ParallelExecute(
            (identity) =>
            {
                DevOps.Collector.SyncOneMemberSummary(identity.Id, true);
            },
            Config.MaxParallelTasks);
        break;

    case "--p/invoke":
        Ban3.Infrastructures.PlatformInvoke.Helper.Prepare();
        break;

    case "--default":
        var identities =
            DevOps.Collector.Core.LoadTeams()
                .Where(o => o.Name == Config.DefaultTeam)
                .ToList()
                .GetIdentitiesFromTeams();

        Console.WriteLine($"identity count={identities.Count}");

        identities.ParallelExecute(
            (identity) => { DevOps.Collector.SyncOneMemberSummary(identity.Id, true); },
            Config.MaxParallelTasks);
        break;

    default:
        $"args:   --default                   collect team : [ {Config.DefaultTeam} ]".WriteColorLine(ConsoleColor.DarkYellow);
        $"               --all :                           prepare all teams data".WriteColorLine(ConsoleColor.DarkYellow);
        $"              --everyone :            collect all teams".WriteColorLine(ConsoleColor.DarkYellow);
        $"              --key [keyword] : collect teams whose name contain [keyword]".WriteColorLine(ConsoleColor.DarkYellow);
        $"              --others :                  collect teams exclude [ {Config.DefaultTeam} ]".WriteColorLine(ConsoleColor.DarkYellow);
        $"              --p/invoke :              prepare assemblies data".WriteColorLine(ConsoleColor.DarkYellow);

      var r=  DevOps.Collector.WorkItemTracking.Query(@"Update System Set Title='[u]StartInfoPassedToWorklfowActivity' WHERE Id=768431");
        Console.WriteLine(r.ObjToJson());
        break;
}