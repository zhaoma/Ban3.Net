using Ban3.Infrastructures.Consoles;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Extensions;
using Ban3.Platforms.TeamFoundationCollector.Application.CollectAndReport;
using Config= Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Config;
using Ban3.Infrastructures.Common.Extensions;

var teamName = args.Any() ? args[0] : Config.DefaultTeam;

switch (teamName)
{
    case "--all":
        DevOps.Collector.Core.PrepareTeams(true);
        break;

    case "--everyone":
        var all =
            DevOps.Collector.Core.LoadTeams()
                .GetIdentitiesFromTeams();

        DevOps.Parse(all);
        break;

    case "--key":
        var keys =
            DevOps.Collector.Core.LoadTeams()
                .Where(o => o.Name.Contains(args[1]))
                .ToList()
                .GetIdentitiesFromTeams();

        DevOps.Parse(keys);
        break;

    case "--default":
        var identities =
            DevOps.Collector.Core.LoadTeams()
                .Where(o => o.Name == Config.DefaultTeam)
                .ToList()
                .GetIdentitiesFromTeams();

        DevOps.Parse(identities);
        break;

    case "--others":
        var others =
            DevOps.Collector.Core.LoadTeams()
                .Where(o => o.Name != Config.DefaultTeam)
                .ToList()
                .GetIdentitiesFromTeams();

        DevOps.Parse(others);
        break;

    case "--p/invoke":
        new Action(() => Ban3.Infrastructures.PlatformInvoke.Helper.Prepare())
            .ExecuteAndTiming("Prepare Assemblies Data");
        break;

    case "--configs":
        new Action(Ban3.Infrastructures.SpringConfig.Helper.Prepare)
            .ExecuteAndTiming("Prepare SpringConfig Data");

        new Action(Ban3.Infrastructures.WxsConfig.Helper.Prepare)
            .ExecuteAndTiming("Prepare WxsConfig Data");

        break;

    default:
        $"args:   --default                   collect team : [ {Config.DefaultTeam} ]".WriteColorLine(ConsoleColor
            .DarkYellow);
        $"               --all :                           prepare all teams data".WriteColorLine(ConsoleColor
            .DarkYellow);
        $"              --everyone :            collect all teams".WriteColorLine(ConsoleColor.DarkYellow);
        $"              --key [keyword] : collect teams whose name contain [keyword]".WriteColorLine(ConsoleColor
            .DarkYellow);
        $"              --others :                  collect teams exclude [ {Config.DefaultTeam} ]".WriteColorLine(
            ConsoleColor.DarkYellow);
        $"              --p/invoke :              prepare assemblies data".WriteColorLine(ConsoleColor.DarkYellow);
        $"              --configs :                prepare configs data".WriteColorLine(ConsoleColor.DarkYellow);
        break;
}