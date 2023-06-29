using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.RuntimeCaching;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces.Functions;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Core;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Response.Core;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Extensions;
public static partial class Helper
{
    public static CreateTeamResult CreateTeam(this ICore _, CreateTeam request)
        => ServerResource.CoreGetTeams.Execute<CreateTeamResult>(request).Result;

    public static GetTeamsResult GetTeams(this ICore _, GetTeams request)
        => ServerResource.CoreGetTeams.Execute<GetTeamsResult>(request).Result;

    public static GetTeamsResult GetTeams(this ICore _)
        => _.GetTeams(new GetTeams
        {
            ExpandIdentity = false,
            Top = 10000
        });

    public static GetTeamMembersResult GetTeamMembers(this ICore _, GetTeamMembers request)
        => ServerResource.CoreGetTeamMembers.Execute<GetTeamMembersResult>(request).Result;

    public static GetTeamMembersResult GetTeamMembers(this ICore _, WebApiTeam team)
        => _.GetTeamMembers(new GetTeamMembers
        {
            ProjectId = team.ProjectId,
            TeamId = team.Id,
            Top = 1000
        });

    public static GetPortraitResult GetPortrait(this ICore _, string id, GetPortrait request)
    {
        var localStorage = Infrastructures.Common.Config.LocalStorage;

        var path = Path.Combine(localStorage.RootPath, "Portraits");
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        var fileSaved = ServerResource.CoreGetPortrait.Download(request, Path.Combine(path, id + ".png"));
        var result = new GetPortraitResult
        {
            Success = !string.IsNullOrEmpty(fileSaved.Result)
        };

        if (result.Success)
            result.SavedPath = $"{localStorage.RootUrl}/Portraits/{id}.png";

        return result;
    }

    public static GetPortraitResult GetPortrait(this ICore _, IdentityRef identityRef)
        => _.GetPortrait(identityRef.Id, new GetPortrait { Descriptor = identityRef.Descriptor });

    public static bool PrepareTeams(this ICore _, bool refreshPortrait = false)
    {
        try
        {
            var r = 1;
            var teams = _.GetTeams(new GetTeams
            {
                ExpandIdentity = false,
                Top = 10000
            });

            if (teams is { Success: true, Value: { } })
            {
                teams.Value
                    .AsParallel()
                    .WithDegreeOfParallelism(Environment.ProcessorCount / 2)
                    .ForAll(o =>
                    {
                        Logger.Debug($"parse {r}/{teams.Value.Count} : {o.Name}");
                        var members = _.GetTeamMembers(o);
                        if (!members.Success || members.Value == null) return ;

                        o.Members = members.Value;
                        if (refreshPortrait)
                            foreach (var teamMember in o.Members)
                            {
                                teamMember.Identity!.Portrait = _.GetPortrait(teamMember.Identity).SavedPath;
                            }

                        r++;
                    });

                var file = teams.Value.SetsFile();
                file.WriteFile(teams.Value.ObjToJson());
            }

            return true;
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }

        return false;
    }

    public static List<WebApiTeam> LoadTeams(this ICore _)
    => Config.CacheKey<WebApiTeam>()
        .LoadOrSetDefault<List<WebApiTeam>>(typeof(WebApiTeam).LocalFile());

    public static WebApiTeam? LoadTeamByName(this ICore _, string name)
    {
        return _.LoadTeams()
            .FindLast(o => o.Name == name);
    }

    public static List<IdentityRef> GetIdentitiesFromTeams(this List<WebApiTeam> teams)
    {
        var result = new List<IdentityRef>();

        foreach (var newList in
                 from webApiTeam in teams
                 where webApiTeam.Members != null && webApiTeam.Members.Any()
                 select webApiTeam.Members
                     .Where(o => o.Identity != null)
                     .Select(o => o.Identity!)
                     .Where(x => result!.All(y => y.Id != x.Id)))
        {
            result = result.Union(newList)
                .ToList();
        }

        return result;
    }

    public static IdentityRef? LoadIdentityRef(this ICore _, string identityGuid)
    {
        var allIdentities = _.LoadTeams()
            .GetIdentitiesFromTeams();

        return allIdentities
            .FindLast(o => o.Id.StringEquals( identityGuid));
    }
}