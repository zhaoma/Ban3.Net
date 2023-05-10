using System;
using System.Data;
using System.Linq;
using System.Text;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Extensions;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models.BuildReports;

public class ReportSectionForWorkItems
    : ReportSection
{
    public ReportSectionForWorkItems(int rank, string subject)
    {
        Rank = rank;
        Type = BuildReportType.WorkItems;
        Subject = subject;
    }

    public ReportSectionForWorkItems(ReportSection reportSection)
    {
        Rank = reportSection.Rank;
        Sql = reportSection.Sql;
        Type = reportSection.Type;
        Subject = reportSection.Subject;
    }

    public override string GenerateHtml(IReportService reportService)
    {
        var sb = new StringBuilder();

        var queryResult = reportService.WorkItemTracking.Query(Sql);
        if (queryResult is { Success: true, WorkItems: { }, Columns: { } })
        {
            var listWorkItemsResult = reportService.WorkItemTracking.ListWorkItems(
                queryResult.WorkItems?.Select(o => o.Id!.Value)!,
                queryResult.Columns?.Select(o => o.ReferenceName)!
            );

            var table = queryResult.GetWorkItemsDataTable(listWorkItemsResult);
            if (table is { Rows.Count: > 0 })
            {
                sb.AppendLine("<table align=\"center\" cellpadding=\"0\" cellspacing=\"2\" style=\"width:100%;background-color: #666; font-size: 14px; font-family: 'Microsoft YaHei';\"><tr>");
                foreach (DataColumn col in table.Columns)
                {
                    sb.Append($"<th style='padding:5px;color: #FFF'>{col.ColumnName}</th>");
                }
                sb.Append("</tr>");

                foreach (DataRow row in table.Rows)
                {
                    sb.Append("<tr>");
                    var id = table.Columns.Contains("Id") ? Convert.ToInt32(row["Id"]) : 0;
                    foreach (DataColumn col in table.Columns)
                    {
                        if (id > 0)
                        {
                            sb.Append(
                                $"<td style='padding:5px;background-color: #FFF'><a href='https://demeter.healthcare.siemens.com/tfs/CT/CTS/_workitems/edit/{id}/' style='color:#000;text-decoration:none;' target='_blank'>{row[col.ColumnName]}</a></td>");
                        }
                        else
                        {
                            sb.Append(
                                $"<td style='padding:5px;background-color: #FFF'>{row[col.ColumnName]}</td>");
                        }
                    }
                    sb.Append("</tr>");
                }

                sb.AppendLine("</table><br/><br/>");
            }
        }

        return sb.ToString();
    }
}