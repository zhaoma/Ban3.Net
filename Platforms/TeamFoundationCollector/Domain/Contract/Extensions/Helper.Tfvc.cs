using System;
using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.RuntimeCaching;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces.Functions;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.SubCondition;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Tfvc;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Response.Tfvc;
using System.Xml;
using Ban3.Infrastructures.NetHttp;
using Ban3.Infrastructures.NetHttp.Entries;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models.BranchSpec;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models.TfvcReports;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Extensions;

public static partial class Helper
{
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

    public static List<TfvcBranch> LoadBranches(this ITfvc _)
    {
        var file = new List<TfvcBranch>().SetsFile();
        return file.LoadOrSetDefault(
            file.ReadFile().JsonToObj<List<TfvcBranch>>()!,
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
            var changeset = _.GetChangeset(changesetRef.ChangesetId);

            if (changeset.Success)
            {
                changeset.ChangesetId.DataFile<TfvcChangeset>()
                    .WriteFile(changeset.ObjToJson());
            }
            
            return true;
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }

        return false;
    }

    public static TfvcChangeset? LoadChangeset(this ITfvc _, int changesetId)
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

    public static TfvcChangesetRef? GetLatestRIChangesetRef(this ITfvc _,int days,string itemPath,string keyword)
    {
        var result = _.GetChangesets(new GetChangesets
        {
            SearchCriteria=new SearchCriteria
            {
                ItemPath=itemPath,
                FromDate = DateTime.Now.AddDays(-days).ToString("yyyy-MM-dd"),
                ToDate = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd")
            }
        });
        if (result is { Success: true, Value: { } } && result.Value.Any())
        {
            return result.Value.FirstOrDefault(o=>o.Comment.Contains(keyword));
        }

        return null;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="_"></param>
    /// <param name="id">authorId(GUID)</param>
    /// <param name="pageNo"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    public static GetChangesetsResult GetChangesets(this ITfvc _,string id,int days,int pageNo, int pageSize)
    {
        var request = new GetChangesets
        {
            Top = pageSize,
            Skip = (pageNo - 1) * pageSize
        };

        if (days > 0)
        {
            request.SearchCriteria = new SearchCriteria
            {
                FromDate = DateTime.Now.AddDays(-days).ToString("yyyy-MM-dd"),
                ToDate = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd")
            };
        }

        if (!string.IsNullOrEmpty(id))
            request.SearchCriteria = new SearchCriteria { Author = id };

        return _.GetChangesets(request);
    }

    public static List<CompositeChangeset> PrepareChangesets(this ITfvc _, string id,int days=0, bool getDetail = false,
        int start = 1)
    {
        var result = new List<CompositeChangeset>();

        var pageSize = Config.MaxParallelTasks;
        var pageNo = Math.Max(1, start);

        var changesets = _.GetChangesets(id,days, pageNo, pageSize);
        while (changesets is { Success: true, Value: { } } && changesets.Value.Any())
        {
            Logger.Debug($"{DateTime.Now}:parse page {pageNo}");

            result.AddRange(changesets.Value
                .Where(o=>!o.Comment.IsIgnored())
                .Select(o => new CompositeChangeset(o)));

            if (getDetail)
                changesets.Value
                    .AsParallel()
                    //.WithDegreeOfParallelism(Environment.ProcessorCount / 2)
                    .ForAll(o => { _.GetChangesetAndSave(o); });

            pageNo++;
            changesets = _.GetChangesets(id, days,pageNo, pageSize);
        }

        return result;
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

    public static string GetItem(this ITfvc _, string path,string? version=null)
        => ServerResource.TfvcGetItem.ReadHtml(new GetItem
        {
            Path = path,
            VersionDescriptor=new VersionDescriptor { Version=version}
        }).Result;

    public static Dictionary<int, string>? GetItem(this ITfvc _, ReportRef reportRef, string fileId, DiscussionProperties? properties)
    {
        if (properties == null || string.IsNullOrEmpty(properties?.ItemPath)) return null;

        var changes = reportRef == ReportRef.Changeset
            ? fileId.DataFile<TfvcChangeset>().ReadFile().JsonToObj<TfvcChangeset>()?.Changes
            : fileId.DataFile<TfvcShelveset>().ReadFile().JsonToObj<TfvcShelveset>()?.Changes;

        if (changes == null) return null;

        var change = changes.FindLast(o => o.Item?.Path == properties?.ItemPath);

        if (change == null) return null;

        var content = Config.Host.ReadContent(new TargetResource { Url = change.Item?.Url }).Result;

        var lines = new Dictionary<int, string>();

        var allLines = (content + "").Split(new[] { "\r\n" }, StringSplitOptions.None);

        var fromRow = Math.Max(1, properties!.StartLine - 5);
        var toRow = Math.Min(allLines.Length, properties!.EndLine + 5);

        for (var i = fromRow - 1; i < toRow; i++)
        {
            lines.Add(i, allLines[i]);
        }

        return lines;
    }

    public static List<Dependency> GetBranchSpecDependencies(this ITfvc _, string path,string branchName)
    {
        var result = new List<Dependency>();

        var content = _.GetItem(path);
        
        var xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(content);

        var nodes = xmlDoc.SelectNodes("//Dependency");

        if (!string.IsNullOrEmpty(branchName))
        {

            nodes = xmlDoc.FindBranchNode(branchName)
                .SelectNodes("Dependencies/Dependency");
        }

        if (nodes?.Count > 0)
        {
            foreach (XmlNode node in nodes)
            {
                result.Add(new Dependency(node));
            }
        }
        
        return result;
    }

    private static XmlNode FindBranchNode(this XmlDocument xmlDoc, string branchName)
    {
        var ns = xmlDoc.SelectNodes("//Branch");

        if (ns == null) return null;
        foreach (XmlNode n in ns)
        {
            if (n.TryGetAttribute("Name") == branchName)
                return n;
        }

        return ns[ns.Count - 1];
    }

    public static List<MonitorRecord> GetBranchSpecMonitorRecords(this ITfvc _, MonitorSection jobSection)
    {
        var records = _.GetBranchSpecDependencies( jobSection.Target.Value, jobSection.SectionName)
            .Select(o=>new MonitorRecord
            {
                Name=o.Name,
                Version = o.Version,
                GuidelineVersions = new ()
            }).ToList();

        foreach (var jobGuideline in jobSection.Guidelines)
        {
            _.FulfillMonitorRecords(records,jobGuideline.Key,jobGuideline.Value);
        }

        return records;
    }

    static void FulfillMonitorRecords(this ITfvc _, List<MonitorRecord> records, string guidelineId,
        string guidelinePath)
    {
        var dependencies = _.GetBranchSpecDependencies(guidelinePath,string.Empty);
        if (dependencies.Any())
        {
            foreach (var monitorRecord in records)
            {
                var g = dependencies.FindLast(o => o.Name == monitorRecord.Name);
                if (g != null)
                {
                    if (monitorRecord.GuidelineVersions.ContainsKey(guidelineId))
                    {
                        monitorRecord.GuidelineVersions[guidelineId] = g.Version;
                    }
                    else
                    {
                        monitorRecord.GuidelineVersions.Add(guidelineId, g.Version);
                    }
                }
            }
        }
    }

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

    public static GetShelvesetResult GetShelveset(this ITfvc _, string shelvesetId)
        => _.GetShelveset(new GetShelveset
        {
            ShelvesetId = shelvesetId,
            RequestData=new Request.SubCondition.RequestData()
        });
    
    public static bool GetShelvesetAndSave(this ITfvc _, TfvcShelvesetRef shelvesetRef)
    {
        try
        {
            var shelveset = _.GetShelveset(shelvesetRef.Id);

            if (shelveset.Success)
            {
                Console.WriteLine($"{shelveset.Id} => {shelveset.Id.MD5String()}");
                shelveset.Id.MD5String().DataFile<TfvcShelveset>()
                    .WriteFile(shelveset.ObjToJson());
            }

            return true;
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }

        return false;
    }


    public static GetShelvesetsResult GetShelvesets(this ITfvc _, GetShelvesets request)
        => ServerResource.TfvcGetShelvesets.Execute<GetShelvesetsResult>(request).Result;

    public static GetShelvesetsResult GetShelvesets(this ITfvc _, string id, int pageNo, int pageSize)
    {
        var request = new GetShelvesets
        {
            Top = pageSize,
            Skip = (pageNo - 1) * pageSize
        };
        if (!string.IsNullOrEmpty(id))
            request.RequestData = new RequestData { Owner = id };

        return _.GetShelvesets(request);
    }

    public static List<CompositeShelveset> PrepareShelvesets(this ITfvc _, string id, bool getDetail = false,
        int start = 1)
    {
        var result = new List<CompositeShelveset>();

        var pageSize = Config.MaxParallelTasks; ;
        var pageNo = Math.Max(1, start);

        var shelvesets = _.GetShelvesets(id, pageNo, pageSize);
        while (shelvesets is { Success: true, Value: { } } && shelvesets.Value.Any())
        {
            Logger.Debug($"{DateTime.Now}:parse page {pageNo}");

            result.AddRange(shelvesets.Value

                .Where(o => !o.Comment.IsIgnored())
                .Select(o => new CompositeShelveset(o)));
            if (getDetail)
                shelvesets.Value
                    .AsParallel()
                    //.WithDegreeOfParallelism(Environment.ProcessorCount / 2)
                    .ForAll(o => { _.GetShelvesetAndSave(o); });

            pageNo++;
            shelvesets = _.GetShelvesets(id, pageNo, pageSize);
        }

        return result;
    }

    public static GetShelvesetWorkItemsResult GetShelvesetWorkItems(this ITfvc _, GetShelvesetWorkItems request)
        => ServerResource.TfvcGetShelvesetWorkItems.Execute<GetShelvesetWorkItemsResult>(request).Result;
}