using System.Text;
using Ban3.Infrastructures.Common.Attributes;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Extensions;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces.Functions;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.WorkItemTracking;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract;

public static class DevOps
{
    public static IReportService Report;

    public static IBuild Build;

    public static ICore Core;

    public static IDiscussion Discussion;

    public static IPipelines Pipelines;

    public static ITfvc Tfvc;

    public static void PrepareForce()
    {
        // refresh teams ; identities and download portraits
        Core.PrepareTeams(true);


        Discussion.PrepareThreads();

    }

    public static async void SendMail(SendMail request)
    {
        await ServerResource.WorkItemTrackingSendMail
            .ExecuteVoid(request);
    }

    public static void SyncOneTeamSummary(string teamGuid, bool forceOverwrite = true)
    {
        var team = DevOps.Core.LoadTeams().FirstOrDefault(o => o.Id == teamGuid);

        if (team != null)
        {
            if (team.Members != null && team.Members.Any())
            {
                team.Members?.AsParallel()
                    .ForAll(o =>
                    {
                        var memberId = o.Identity?.Id + "";

                        new Action(() => { SyncOneMemberSummary(memberId, forceOverwrite); })
                            .ExecuteAndTiming($" {o.Identity?.DisplayName}");
                    });
            }
        }
    }

    public static void SyncOneMemberSummary(string identityGuid, bool forceOverwrite = true)
    {
        var file = identityGuid.DataFile<IdentitySummary>();
        if (!forceOverwrite && File.Exists(file)) return;

        var result = new IdentitySummary
        {
            Id = identityGuid
        };
        
        result.AppendChangesets(Tfvc.PrepareChangesets(identityGuid).FulfilDiscussion());
        result.AppendShelvesets(Tfvc.PrepareShelvesets(identityGuid).FulfilDiscussion(identityGuid));

        file
            .WriteFile(result.ObjToJson());
    }

    public static IdentitySummary? LoadOneAuthorSummary(string identityGuid)
    {
        return identityGuid
            .DataFile<IdentitySummary>()
            .ReadFile()
            .JsonToObj<IdentitySummary>();
    }

    private static List<CompositeChangeset> FulfilDiscussion(this List<CompositeChangeset> changesets)
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
                            o => { o.Threads = Discussion.GetThreads(o.Id).GetCompositeThreads(); });
                }).ExecuteAndTiming($"parse page {pageNo} changesets discussion.");
            });
        return changesets;
    }

    private static List<CompositeShelveset> FulfilDiscussion(this List<CompositeShelveset> shelvesets,
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
                        o => { o.Threads = Discussion.GetThreads(o.Id, authorGuid).GetCompositeThreads(); });
                }).ExecuteAndTiming($"parse page {pageNo} shelvesets discussion.");
            });

        return shelvesets;
    }
}