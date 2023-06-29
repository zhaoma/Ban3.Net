using System;
using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces.Functions;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models.TfvcReports;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Discussion;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Response.Discussion;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Extensions;

public static partial class Helper
{
    public static GetThreadsResult GetThreads(this IDiscussion _, GetThreads request)
        => ServerResource.DiscussionGetThreads.Execute<GetThreadsResult>(request).Result;

    public static GetThreadResult GetThread(this IDiscussion _, GetThread request)
        => ServerResource.DiscussionGetThread.Execute<GetThreadResult>(request).Result;

    public static GetThreadResult GetThread(this IDiscussion _, int id)
        => _.GetThread(new GetThread { Id = id });

    public static void PrepareThreads(this IDiscussion _, int id = 1)
    {
        var thread = _.GetThread(id);
        while (thread.Success)
        {
            if (thread.Id > 0)
            {
                id.DataFile<DiscussionThread>()
                    .PersistFileOnDemand(thread);
            }

            id++;
            thread = _.GetThread(id);
        }
    }

    public static DiscussionThread? LoadThread(this IDiscussion _, int threadId)
    {
        var file = threadId.DataFile<DiscussionThread>();
        return file.ReadFile()
            .JsonToObj<DiscussionThread>();
    }

    public static GetThreadsResult GetThreads(this IDiscussion _, int changesetId)
        => _.GetThreads(new GetThreads
        {
            ArtifactUri = new Entities.ArtifactUri(changesetId)
        });

    public static GetThreadsResult GetThreads(this IDiscussion _, string shelvesetId, string shelvesetOwner)
        => _.GetThreads(new GetThreads
        {
            ArtifactUri = new Entities.ArtifactUri(shelvesetId, shelvesetOwner)
        });
    
    public static List<CompositeThread>? GetCompositeThreads(this GetThreadsResult responseResult)
    {
        if (responseResult is { Success: true, Value: { } } && responseResult.Value.Any())
            return responseResult.Value.Select(o => new CompositeThread(o)).ToList();

        return null;
    }


}