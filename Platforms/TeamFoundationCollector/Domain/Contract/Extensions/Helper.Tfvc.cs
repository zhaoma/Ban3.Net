using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces.Functions;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Tfvc;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Response.Tfvc;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Extensions;

public static partial class Helper
{

    /*
     *  CreateChangeset
     *  GetBatchedChangesets
     *  GetBatchedItems
     *  GetBranches
     *  GetBranchRefs
     *  GetBranch
     *  GetChangesetChanges
     *  GetChangeset
     *  GetChangesets
     *  GetChangesetWorkItems
     *  GetItem
     *  GetItems
     *  GetLabelItems
     *  GetLabel
     *  GetLabels
     *  GetShelvesetChanges
     *  GetShelveset
     *  GetShelvesets
     *  GetShelvesetWorkItems
     */

    public static CreateChangesetResult CreateChangeset(
        this ITfvc _, 
        CreateChangesetBody data)
    {
        var request = new CreateChangeset { Body = data };
        return ServerResource.TfvcCreateChangeset.Execute<CreateChangesetResult>(request);
    }

    public static GetBatchedChangesetsResult GetBatchedChangesets(
        this ITfvc _, 
        GetBatchedChangesets request)
    {
        return ServerResource.TfvcCreateChangeset.Execute<GetBatchedChangesetsResult>(request);
    }

    public static GetBatchedChangesetsResult GetBatchedChangesets(
        this ITfvc _, 
        List<int> changesetIds,
        int commentLength = 1000, 
        bool includeLinks = true)
    {
        return _.GetBatchedChangesets(new GetBatchedChangesets
        {
            Body=new GetBatchedChangesetsBody
            {
                ChangesetIds = changesetIds,
                CommentLength = commentLength,
                IncludeLinks = includeLinks
            }
        });
    }



    public static GetBranchesResult GetBranches(
        this ITfvc _, 
        GetBranches request)
    {
        return ServerResource.TfvcGetBranches.Execute<GetBranchesResult>(request);
    }

}