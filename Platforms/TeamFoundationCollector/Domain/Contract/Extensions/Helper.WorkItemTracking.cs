using System;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces.Functions;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.WorkItemTracking;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Response.WorkItemTracking;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Ban3.Infrastructures.Common.Extensions;
using Newtonsoft.Json;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Extensions;

public static partial class Helper
{
    public static QueryResult Query(this IWorkItemTracking _, Query request)
        => ServerResource.WorkItemTrackingWiqlQuery.Execute<QueryResult>(request).Result;

    public static QueryResult Query(this IWorkItemTracking _, string query)
        => _.Query(new Query
        {
            Body = new Wiql { Query = query }
        });

    public static ListWorkItemsResult ListWorkItems(this IWorkItemTracking _, ListWorkItems request)
        => ServerResource.WorkItemTrackingListWorkItems.Execute<ListWorkItemsResult>(request).Result;

    public static ListWorkItemsResult ListWorkItems(
        this IWorkItemTracking _, 
        IEnumerable<int> ids,
        IEnumerable<string> fields)
        => _.ListWorkItems(new ListWorkItems(ids, fields));

    public static DataTable? GetWorkItemsDataTable(
        this QueryResult queryResult,
        ListWorkItemsResult listWorkItemsResult)
    {
        if (!queryResult.Success || queryResult.Columns == null) return null;

        var result = new DataTable();
        
        result.Columns.AddRange(
            queryResult.Columns.Select(o=>new DataColumn(o.Name)).ToArray()
            );

        if (listWorkItemsResult is { Success: true, Value: { } } && listWorkItemsResult.Value.Any())
        {
            foreach (var workItem in listWorkItemsResult.Value)
            {
                var row = result.NewRow();
                
                queryResult.Columns.ForEach(x =>
                {
                    if (workItem.Fields != null && workItem.Fields.ContainsKey(x.ReferenceName!))
                    {
                        var val = workItem.Fields[x.ReferenceName!].ToString();
                        switch (x.ReferenceName)
                        {
                            case "System.Id":
                                row[x.Name!] = Convert.ToInt32(val);
                                break;

                            case "System.AssignedTo":
                                row[x.Name!] = JsonConvert.DeserializeObject<IdentityRef>(val)?.DisplayName.ShowName();
                                break;
                            default:
                                row[x.Name!] = val;
                                break;
                        }
                    }
                });

                result.Rows.Add(row);
            }
        }

        return result;
    }
}