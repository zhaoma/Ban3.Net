using System.Net;
using System.Text.RegularExpressions;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Platforms.TeamFoundationCollector.Application.CollectAndReport.Functions;
using Ban3.Platforms.TeamFoundationCollector.Application.CollectAndReport.Interfaces;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Extensions;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces.Functions;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models.TfvcReports;
using Microsoft.Office.Interop.Outlook;
using Action = System.Action;
using Build = Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities.Build;

namespace Ban3.Platforms.TeamFoundationCollector.Application.CollectAndReport.Extensions;

public static partial class Helper
{
    public static void PrepareForce(this ICollectService _)
    {
        _.Core.PrepareTeams(true);
        _.SyncTfvc();
    }

    #region Build

    public static Build? DefinitionsLastBuild(this ICollectService _, int definitionId)
        => _.Build.GetLastBuildForDefinition(definitionId);



    #endregion

    #region Tfvc

    public static void SyncTfvc(this ICollectService _)
    {
        var teams = _.Core.LoadTeams();

        teams.ParallelExecute(
            (team) =>
            {
                _.SyncOneTeamSummary(team.Id, true);
            }, Config.MaxParallelTasks
        );
    }

    public static void SyncOneTeamSummary(this ICollectService _,string teamGuid, bool forceOverwrite = true)
    {
        var team = _.Core.LoadTeams().FirstOrDefault(o => o.Id == teamGuid);

        if (team != null)
        {
            if (team.Members != null && team.Members.Any())
            {
                team.Members!
                    .AsParallel()
                    .ForAll(o =>
                    {
                        var memberId = o.Identity?.Id + "";

                        new Action(() => { _.SyncOneMemberSummary(memberId, forceOverwrite); })
                            .ExecuteAndTiming($"{o.Identity?.DisplayName}");
                    });
            }
        }
    }

    public static void SyncOneMemberSummary(this ICollectService _, string identityGuid, bool forceOverwrite = true)
    {
        var file = identityGuid.DataFile<IdentitySummary>();
        if (!forceOverwrite && File.Exists(file)) return;

        var result = new IdentitySummary
        {
            Id = identityGuid
        };

        result.AppendChangesets(_.FulfillDiscussion(_.Tfvc.PrepareChangesets(identityGuid,0,true)));
        result.AppendShelvesets(_.FulfillDiscussion(_.Tfvc.PrepareShelvesets(identityGuid,true),identityGuid));
        
        file
            .WriteFile(result.ObjToJson());
    }

    private static List<CompositeChangeset> FulfillDiscussion(
        this ICollectService _, 
        List<CompositeChangeset> changesets)
    {
        var pageSize = Config.MaxParallelTasks;
        var p = changesets.Count % pageSize > 0 ? changesets.Count / pageSize + 1 : changesets.Count / pageSize;

        Enumerable.Range(1, p)
            .ToList()
            .ForEach(pageNo =>
            {
                new Action(() =>
                {
                    changesets
                        .Skip((pageNo - 1) * pageSize)
                        .Take(pageSize).ToList()
                        .AsParallel()
                        .ForAll(
                            o =>
                            {
                                o.Threads = _.Discussion.GetThreads(o.Id).GetCompositeThreads();
                            });


                }).ExecuteAndTiming($"parse page {pageNo} changesets discussion.");
            });

        return changesets;
    }

    private static List<CompositeShelveset> FulfillDiscussion(
        this ICollectService _, 
        List<CompositeShelveset> shelvesets,
        string authorGuid)
    {
        var pageSize = Config.MaxParallelTasks;
        var p = shelvesets.Count % pageSize > 0 ? shelvesets.Count / pageSize + 1 : shelvesets.Count / pageSize;

        Enumerable.Range(1, p)
            .ToList()
            .ForEach(pageNo =>
            {
                new Action(() =>
                {
                    shelvesets
                    .Skip((pageNo - 1) * pageSize)
                    .Take(pageSize)
                    .ToList()
                    .AsParallel()
                    .ForAll(
                        o =>
                        {
                            o.Threads = _.Discussion.GetThreads(o.Id, authorGuid).GetCompositeThreads();
                        });
                }).ExecuteAndTiming($"parse page {pageNo} shelvesets discussion.");
            });

        return shelvesets;
    }

    #endregion

    public static string RegexParse(this string content)
    {
        var r=new Regex(@"(<(.*?)>)");
        content = r.Replace(content, Html);

        r = new Regex(@"@(<(.*?)>)");
        content = r.Replace(content, IdentityName);

        r = new Regex(@"(\[(.+?)\])(\(\b(?:https?:\/\/|www\.).\S+\b\))");
        content = r.Replace(content, SubjectAndUrl);

        // r = new Regex(@"\b(?:https?://|www\.)\S+\b");
        // content = r.Replace(content, HttpUrl);

        return content;
    }

    static string IdentityName( Match m)
    {
        var guid=m.Groups[2].Value;

        if (guid.Length == 36)
        {
            var name = new Core().LoadIdentityRef(guid)?.DisplayName.ShowName() + "";
            return $"<b style='color:rgba(16, 110, 190,1);text-decoration-line:underline;'>@{name}</b>";
        }

        return "";
    }

    static string Html(Match m)
    {
        var content= m.Groups[2].Value;
        if (content.Length != 36)
            return WebUtility.HtmlEncode(m.Value);

        return m.Value;
    }

    static string HttpUrl(Match m)
    {
        var url = m.Value;
        var text =
            url.Length > 100
                ? url.Substring(0, 100) + "..."
                : url;

        return $"<a href='{url}' target='_blank' style='color:rgba(0,90,158,1);text-decoration-line:underline;'>{text}</a>";
    }

    static string SubjectAndUrl(Match m)
    {
        var url = m.Groups[3].Value;
        var text = m.Groups[2].Value;

        return $"<a href='{url}' target='_blank' style='color:rgba(0,90,158,1);text-decoration-line:underline;'>{text}</a>";
    }
}
