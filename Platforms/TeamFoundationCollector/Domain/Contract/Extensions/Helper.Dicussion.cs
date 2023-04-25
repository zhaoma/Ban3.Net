using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces.Functions;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Discussion;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Response.Discussion;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Extensions;

public static partial class Helper
{
    public static GetThreadsResult GetThreads(this IDiscussion _, GetThreads request)
        => ServerResource.DiscussionGetThreads.Execute<GetThreadsResult>(request).Result;

    public static GetThreadsResult GetThreads(this IDiscussion _, int changesetId)
        => _.GetThreads(new GetThreads
        {
            Uri = new Entities.ArtifactUri(changesetId)
        });

    public static GetThreadsResult GetThreads(this IDiscussion _, string shelvesetId, string shelvesetOwner)
        => _.GetThreads(new GetThreads
        {
            Uri = new Entities.ArtifactUri(shelvesetId, shelvesetOwner)
        });
}