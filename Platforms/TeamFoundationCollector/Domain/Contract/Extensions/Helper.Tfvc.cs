using Ban3.Infrastructures.Common.Extensions;
using Ban3.Libs.RuntimeCaching;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces.Functions;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.SubCondition;
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

    public static bool PrepareBranches(this ITfvc _)
    {
        try
        {
            var branches = _.GetBranches(new GetBranches());

            if (branches is { Success: true, Value: { } })
            {
                var file = branches.Value.SetsFile();
                file.WriteFile(branches.Value.ObjToJson());
            }

            return true;
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }

        return false;
    }

    public static List<TfvcBranch> LoadBranches(this ICore _)
    {
        var file = new List<TfvcBranch>().SetsFile();
        return file.LoadOrSetDefault(
            file.ReadFile().JsonToObj<List<TfvcBranch>>(),
            file
        );
    }

    public static GetBranchRefsResult GetBranchRefs(this ITfvc _, GetBranchRefs request)
        => ServerResource.TfvcGetBranchRefs.Execute<GetBranchRefsResult>(request).Result;

    public static GetBranchResult GetBranch(this ITfvc _, GetBranch request)
        => ServerResource.TfvcGetBranch.Execute<GetBranchResult>(request).Result;

    public static GetChangesetChangesResult GetChangesetChanges(this ITfvc _, GetChangesetChanges request)
        => ServerResource.TfvcGetChangesetChanges.Execute<GetChangesetChangesResult>(request).Result;

    public static GetChangesetResult GetChangeset(this ITfvc _, GetChangeset request)
        => ServerResource.TfvcGetBranchRefs.Execute<GetChangesetResult>(request).Result;

    public static GetChangesetResult GetChangeset(this ITfvc _, int changesetId)
        => _.GetChangeset(new GetChangeset { Id = changesetId });

    public static bool GetChangesetAndSave(this ITfvc _, TfvcChangesetRef changesetRef)
    {
        try
        {
            Logger.Debug($"SAVE Changeset {changesetRef.ChangesetId}");
            var now= DateTime.Now;
            var changeset = _.GetChangeset(changesetRef.ChangesetId);
            var t1 = DateTime.Now.Subtract(now).TotalMilliseconds;
            now = DateTime.Now;

            if (changeset.Success)
            {
                changeset.ChangesetId.DataFile<TfvcChangeset>()
                    .WriteFile(changeset.ObjToJson());
            }

            var t2=DateTime.Now.Subtract(now).TotalMilliseconds;

            Logger.Debug($"read:{t1} ms;save:{t2} ms");
            Console.WriteLine($"read:{t1} ms;save:{t2} ms");
            return true;
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }

        return false;
    }

    public static TfvcChangeset LoadChangeset(this ITfvc _, int changesetId)
    {
        var file = changesetId.DataFile<TfvcChangeset>();
        return file.ReadFile()
            .JsonToObj<TfvcChangeset>();
    }

    public static GetChangesetsResult GetChangesets(this ITfvc _, GetChangesets request)
        => ServerResource.TfvcGetChangesets.Execute<GetChangesetsResult>(request).Result;

    public static GetChangesetsResult GetChangesets(this ITfvc _, int days)
        => _.GetChangesets(new GetChangesets
        {
            SearchCriteria = new SearchCriteria
            {
                FromDate = DateTime.Now.AddDays(-days).ToString("yyyy-MM-dd"),
                ToDate = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd")
            }
        });

    public static GetChangesetsResult GetChangesets(this ITfvc _,int pageNo, int pageSize)
    {
        var request = new GetChangesets
        {
            OrderBy = "id asc",
            Top = pageSize,
            Skip = (pageNo - 1) * pageSize
        };
        return _.GetChangesets(request);
    }

    public static void PrepareChangesets(this ITfvc _,int start=1)
    {
        var pageSize = 20;
        var pageNo =Math.Max(1, start);

        var changesets = _.GetChangesets(pageNo, pageSize);
        while (changesets is { Success: true, Value: { } })
        {
            Console.WriteLine($"{DateTime.Now}:parse page {pageNo}");
            changesets.Value
                .AsParallel()
                .WithDegreeOfParallelism(Environment.ProcessorCount / 2)
                .ForAll(o =>
                {
                    _.GetChangesetAndSave(o);
                });

            pageNo++;
            changesets = _.GetChangesets(pageNo, pageSize);
        }
    }

    public static GetChangesetWorkItemsResult GetChangesetWorkItems(this ITfvc _, GetChangesetWorkItems request)
        => ServerResource.TfvcGetChangesetWorkItems.Execute<GetChangesetWorkItemsResult>(request).Result;
    
    public static GetItemResult GetItem(this ITfvc _, GetItem request)
    {
        var html=ServerResource.TfvcGetItem.ReadHtml(request).Result;
        return new GetItemResult
        {
            Content = html
        };
    }

    public static string GetItem(this ITfvc _, string path)
        => ServerResource.TfvcGetItem.ReadHtml(new GetItem
        {
            Path = path
        }).Result;

    public static GetItemsResult GetItems(this ITfvc _, GetItems request)
        => ServerResource.TfvcGetItems.Execute<GetItemsResult>(request).Result;

    public static GetLabelItemsResult  GetLabelItems(this ITfvc _, GetLabelItems request)
        => ServerResource.TfvcGetLabelItems.Execute<GetLabelItemsResult>(request).Result;
    
    public static GetLabelResult GetLabel(this ITfvc _, GetLabel request)
        => ServerResource.TfvcGetLabel.Execute<GetLabelResult>(request).Result;
    
    public static GetLabelsResult GetLabels(this ITfvc _, GetLabels request)
        => ServerResource.TfvcGetLabels.Execute<GetLabelsResult>(request).Result;

    public static GetShelvesetChangesResult GetShelvesetChanges(this ITfvc _, GetShelvesetChanges request)
        => ServerResource.TfvcGetShelvesetChanges.Execute<GetShelvesetChangesResult>(request).Result;
    
    public static GetShelvesetResult GetShelveset(this ITfvc _, GetShelveset request)
        => ServerResource.TfvcGetShelveset.Execute<GetShelvesetResult>(request).Result;
    
    public static GetShelvesetsResult GetShelvesets(this ITfvc _, GetShelvesets request)
        => ServerResource.TfvcGetShelvesets.Execute<GetShelvesetsResult>(request).Result;
    
    public static GetShelvesetWorkItemsResult GetShelvesetWorkItems(this ITfvc _, GetShelvesetWorkItems request)
        => ServerResource.TfvcGetShelvesetWorkItems.Execute<GetShelvesetWorkItemsResult>(request).Result;
}