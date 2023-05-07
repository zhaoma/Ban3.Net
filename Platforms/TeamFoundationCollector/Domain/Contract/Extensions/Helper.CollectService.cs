﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces.Functions;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models.TfvcReports;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Extensions;

public static partial class Helper
{
    public static void PrepareForce(this ICollectService _)
    {
        // refresh teams ; identities and download portraits
        _.Core.PrepareTeams(true);

    }


    public static void SyncOneTeamSummary(this ICollectService _,string teamGuid, bool forceOverwrite = true)
    {
        var team = _.Core.LoadTeams().FirstOrDefault(o => o.Id == teamGuid);

        if (team != null)
        {
            if (team.Members != null && team.Members.Any())
            {
                team.Members?.AsParallel()
                    .ForAll(o =>
                    {
                        var memberId = o.Identity?.Id + "";

                        new Action(() => { _.SyncOneMemberSummary(memberId, forceOverwrite); })
                            .ExecuteAndTiming($" {o.Identity?.DisplayName}");
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

        result.AppendChangesets(_.FulfillDiscussion(_.Tfvc.PrepareChangesets(identityGuid)));
        result.AppendShelvesets(_.FulfillDiscussion(_.Tfvc.PrepareShelvesets(identityGuid),identityGuid));

        file
            .WriteFile(result.ObjToJson());
    }

    private static List<CompositeChangeset> FulfillDiscussion(this ICollectService _, List<CompositeChangeset> changesets)
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
                            o => { o.Threads = _.Discussion.GetThreads(o.Id).GetCompositeThreads(); });
                }).ExecuteAndTiming($"parse page {pageNo} changesets discussion.");
            });
        return changesets;
    }

    private static List<CompositeShelveset> FulfillDiscussion(this ICollectService _, List<CompositeShelveset> shelvesets,
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
                        o => { o.Threads = _.Discussion.GetThreads(o.Id, authorGuid).GetCompositeThreads(); });
                }).ExecuteAndTiming($"parse page {pageNo} shelvesets discussion.");
            });

        return shelvesets;
    }
}