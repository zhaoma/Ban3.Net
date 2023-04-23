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

    public static CreateChangesetResult CreateChangeset(this ITfvc _, CreateChangeset request)
        => ServerResource.TfvcCreateChangeset.Execute<CreateChangesetResult>(request).Result;

    public static CreateChangesetResult CreateChangeset(this ITfvc _, CreateChangesetBody data)
        => _.CreateChangeset(new CreateChangeset { Body = data });

    public static GetBatchedChangesetsResult GetBatchedChangesets(this ITfvc _, GetBatchedChangesets request)
        => ServerResource.TfvcCreateChangeset.Execute<GetBatchedChangesetsResult>(request).Result;

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

    public static GetBatchedItemsResult GetBatchedChangesets(this ITfvc _, GetBatchedItems request)
        => ServerResource.TfvcGetBatchedItems.Execute<GetBatchedItemsResult>(request).Result;

    public static GetBranchesResult GetBranches(this ITfvc _, GetBranches request)
        => ServerResource.TfvcGetBranches.Execute<GetBranchesResult>(request).Result;
    
    public static GetBranchRefsResult GetBranchRefs(this ITfvc _, GetBranchRefs request)
        => ServerResource.TfvcGetBranchRefs.Execute<GetBranchRefsResult>(request).Result;

    public static GetBranchResult GetBranch(this ITfvc _, GetBranch request)
        => ServerResource.TfvcGetBranch.Execute<GetBranchResult>(request).Result;

    public static GetChangesetChangesResult GetChangesetChanges(this ITfvc _, GetChangesetChanges request)
        => ServerResource.TfvcGetChangesetChanges.Execute<GetChangesetChangesResult>(request).Result;

    public static GetChangesetResult GetChangeset(this ITfvc _, GetChangeset request)
        => ServerResource.TfvcGetBranchRefs.Execute<GetChangesetResult>(request).Result;

    public static GetChangesetsResult GetChangesets(this ITfvc _, GetChangesets request)
        => ServerResource.TfvcGetChangesets.Execute<GetChangesetsResult>(request).Result;

    public static GetChangesetWorkItemsResult GetChangesetWorkItems(this ITfvc _, GetChangesetWorkItems request)
        => ServerResource.TfvcGetChangesetWorkItems.Execute<GetChangesetWorkItemsResult>(request).Result;
    
    public static GetItemResult GetItem(this ITfvc _, GetItem request)
        => ServerResource.TfvcGetItem.Execute<GetItemResult>(request).Result;

    public static GetItemsResult GetItems(this ITfvc _, GetItems request)
        => ServerResource.TfvcGetItems.Execute<GetItemsResult>(request).Result;


}