using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.NetMail;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models.BranchSpec;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models.BuildReports;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models.TfvcReports;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Reports;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Response;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Response.Reports;
using NPOI.HSSF.UserModel;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Extensions;

public static partial class Helper
{
    #region SendEmail

    public static bool SendMail(this IReportService _, List<string>? to, List<string>? cc, string? subject,
        string? mailHtml)
    {
        new Ban3.Infrastructures.NetMail.Entries.TargetServer()
            .SendByOutlook(to, cc, subject, mailHtml);
        return true;
    }

    #endregion

    #region Tfvc Report

    public static TfvcFilterResult GetTfvcReport(this IReportService _, TfvcFilter filter)
    {
        var result = new TfvcFilterResult
        {
            Filter = filter,
        };

        var identities = _.GetIdentities(filter);

        if (filter.LimitIdentityIds != null && filter.LimitIdentityIds.Any())
        {
            identities = identities
                .Where(o => filter.LimitIdentityIds.Any(x => x == o.Id))
                .ToList();
        }

        identities.ForEach(o => { _.FulfillTfvcFilterResult(result, filter, o); });

        result.Rows.AddRange(result.Changesets.ChangesetsToShowRows());
        result.Rows.AddRange(result.Shelvesets.ShelvesetsToShowRows());

        result.Rows = result.Rows.OrderByDescending(o => o.CreatedDate).ToList();

        result.PagedRows = result.Rows.Skip((filter.PageNo - 1) * filter.PageSize).Take(filter.PageSize).ToList();

        result.PagedRows.ForEach(o =>
        {
            if (o.ReportRef == ReportRef.Changeset)
            {
                o.Changes = o.FileId.DataFile<TfvcChangeset>()
                    .ReadFile()
                    .JsonToObj<TfvcChangeset>()?
                    .Changes;
            }

            if (o.ReportRef == ReportRef.Shelveset)
            {
                o.Changes = o.FileId.DataFile<TfvcShelveset>()
                    .ReadFile()
                    .JsonToObj<TfvcShelveset>()?
                    .Changes;
            }
        });

        return result;
    }

    public static List<IdentityRef> GetIdentities(this IReportService _, TfvcFilter filter)
    {
        var teams = _.Core.LoadTeams()
            .Where(o => filter.LimitTeamNames != null && filter.LimitTeamNames.Any(x => x == o.Name))
            .ToList();

        return teams.GetIdentitiesFromTeams();
    }

    public static void FulfillTfvcFilterResult(
        this IReportService _,
        TfvcFilterResult result,
        TfvcFilter filter,
        IdentityRef identityRef)
    {
        bool found = false;
        var identitySummary = _.LoadOneAuthorSummary(identityRef.Id);

        var changesets =
            filter.Ref == ReportRef.All || filter.Ref == ReportRef.Changeset
                ? identitySummary?.GetCompositeChangesets(filter)
                : new List<CompositeChangeset>();
        var shelvesets =
            filter.Ref == ReportRef.All || filter.Ref == ReportRef.Shelveset
                ? identitySummary?.GetCompositeShelvesets(filter)
                : new List<CompositeShelveset>();

        if (changesets != null && changesets.Any())
        {
            found = true;
            result.Changesets = result.Changesets.Union(changesets)
                .ToList();
        }

        if (shelvesets != null && shelvesets.Any())
        {
            found = true;
            result.Shelvesets = result.Shelvesets.Union(shelvesets)
                .ToList();
        }

        if (found && result.Identities.All(o => o.Id != identityRef.Id))
        {
            result.Identities.Add(identityRef);
        }
    }

    private static List<ShowRow> ChangesetsToShowRows(this List<CompositeChangeset> changesets)
    {
        return changesets.Select(o => new ShowRow
        {
            ReportRef = ReportRef.Changeset,
            Id = o.Id + "",
            FileId = o.FileId,
            AuthorGuid = o.AuthorGuid,
            AuthorName = o.AuthorName,
            CreatedDate = o.CreatedDate,
            Comment = o.Comment,
            Url =
                $"{Config.Target.Instance}/{Config.Target.Organization}/{Config.Target.Project}/_versionControl/changeset/{o.Id}",
            Threads = o.Threads

        }).ToList();
    }

    private static List<ShowRow> ShelvesetsToShowRows(this List<CompositeShelveset> shelvesets)
    {
        return shelvesets.Select(o => new ShowRow
        {
            ReportRef = ReportRef.Shelveset,
            Id = o.Id + "",
            FileId = o.FileId,
            AuthorGuid = o.AuthorGuid,
            AuthorName = o.AuthorName,
            CreatedDate = o.CreatedDate,
            Comment = o.Comment,
            Url =
                $"{Config.Target.Instance}/{Config.Target.Organization}/{Config.Target.Project}/_versionControl/shelveset?ss={WebUtility.UrlEncode(o.Id + ";" + o.AuthorGuid)}",
            Threads = o.Threads

        }).ToList();
    }

    private static List<CompositeChangeset> GetCompositeChangesets(
        this IdentitySummary identitySummary,
        TfvcFilter filter)
    {
        if (identitySummary.Changesets == null || !identitySummary.Changesets.Any())
            return new();

        var changesets = new List<CompositeChangeset>();

        changesets.AddRange(identitySummary.Changesets.Select(o => o.Value));

        changesets = changesets.Where(o =>
            (!filter.HasComments || (o.Threads != null && o.Threads.Any()))
            && (string.IsNullOrEmpty(filter.CommentAuthor) || o.Threads.ThreadsHasAuthor(filter.CommentAuthor))
            && o.CreatedDate.DateGE(filter.FromDate)
            && o.CreatedDate.DateLE(filter.ToDate)
            && (o.Comment.StringExists(filter.Keyword) || o.Threads.ThreadsHasKeywords(filter.Keyword))
        ).ToList();

        return changesets;
    }

    private static List<CompositeShelveset> GetCompositeShelvesets(
        this IdentitySummary identitySummary,
        TfvcFilter filter)
    {
        if (identitySummary.Shelvesets == null || !identitySummary.Shelvesets.Any())
            return new();

        var shelvesets = new List<CompositeShelveset>();

        shelvesets.AddRange(identitySummary.Shelvesets.Select(o => o.Value));

        shelvesets = shelvesets.Where(o =>
            (!filter.HasComments || (o.Threads != null && o.Threads.Any()))
            && (string.IsNullOrEmpty(filter.CommentAuthor) || o.Threads.ThreadsHasAuthor(filter.CommentAuthor))
            && o.CreatedDate.DateGE(filter.FromDate)
            && o.CreatedDate.DateLE(filter.ToDate)
            && (o.Comment.StringExists(filter.Keyword)||o.Threads.ThreadsHasKeywords(filter.Keyword))
        ).ToList();

        return shelvesets;
    }

    private static bool ThreadsHasAuthor(this List<CompositeThread>? threads, string commentAuthor)
    {
        if (string.IsNullOrEmpty(commentAuthor)) return true;
        if (threads == null || !threads.Any()) return false;

        return threads.Any(o =>
            o.Comments != null
            && o.Comments.Any(x => x.AuthorName.Contains(commentAuthor)));
    }

    private static bool ThreadsHasKeywords(this List<CompositeThread>? threads, string keywords)
    {
        if (string.IsNullOrEmpty(keywords)) return true;
        if (threads == null || !threads.Any()) return true;

        return threads.Any(o =>
            o.Comments != null
            && o.Comments.Any(x => x.Content.StringExists(keywords)));
    }

    public static IdentitySummary? LoadOneAuthorSummary(this IReportService _, string identityGuid)
    {
        return identityGuid
            .DataFile<IdentitySummary>()
            .ReadFile()
            .JsonToObj<IdentitySummary>();
    }

    #endregion

    #region Excel Export

    public static MemoryStream GetTfvcExcel(this IReportService _, TfvcFilter filter)
    {
        var ms = new MemoryStream();

        var result = _.GetTfvcReport(filter);
        var workbook = new HSSFWorkbook();
        workbook.AddSheet(result.Changesets);
        workbook.AddSheet(result.Shelvesets);

        workbook.Write(ms);
        ms.Flush();
        ms.Position = 0;

        workbook.Close();
        workbook = null;

        return ms;
    }

    private static void AddSheet(this HSSFWorkbook workbook, List<CompositeShelveset> shelvesets)
    {
        if (!shelvesets.Any()) return;

        var sheet = workbook.CreateSheet();

        var headerRow = sheet.CreateRow(0);

        // handling header.

        headerRow.CreateCell(0).SetCellValue("ShelvesetId");
        headerRow.CreateCell(1).SetCellValue("Owner");
        headerRow.CreateCell(2).SetCellValue("Date");
        headerRow.CreateCell(3).SetCellValue("Content");

        // handling value.
        var rowIndex = 1;

        foreach (var row in shelvesets)
        {
            var dataRow = sheet.CreateRow(rowIndex);

            dataRow.CreateCell(0).SetCellValue(row.Id);
            dataRow.CreateCell(1).SetCellValue(row.AuthorName);
            dataRow.CreateCell(2).SetCellValue(row.CreatedDate);
            dataRow.CreateCell(3).SetCellValue(row.Comment);

            rowIndex++;

            if (row.Threads == null || !row.Threads.Any()) continue;
            foreach (var thread in row.Threads)
            {
                if (thread.Comments == null) continue;
                foreach (var threadComment in thread.Comments)
                {
                    var dataComment = sheet.CreateRow(rowIndex);

                    dataComment.CreateCell(0).SetCellValue("");
                    dataComment.CreateCell(1).SetCellValue(threadComment.AuthorName);
                    dataComment.CreateCell(2).SetCellValue(threadComment.PublishedDate);
                    dataComment.CreateCell(3).SetCellValue(threadComment.Content);

                    rowIndex++;
                }
            }
        }
    }

    private static void AddSheet(this HSSFWorkbook workbook, List<CompositeChangeset> changesets)
    {
        if (!changesets.Any()) return;
        var sheet = workbook.CreateSheet();

        var headerRow = sheet.CreateRow(0);

        // handling header.

        headerRow.CreateCell(0).SetCellValue("ChangesetID");
        headerRow.CreateCell(1).SetCellValue("Author");
        headerRow.CreateCell(2).SetCellValue("Date");
        headerRow.CreateCell(3).SetCellValue("Content");

        // handling value.
        var rowIndex = 1;

        foreach (var row in changesets)
        {
            var dataRow = sheet.CreateRow(rowIndex);

            dataRow.CreateCell(0).SetCellValue(row.Id);
            dataRow.CreateCell(1).SetCellValue(row.AuthorName);
            dataRow.CreateCell(2).SetCellValue(row.CreatedDate);
            dataRow.CreateCell(3).SetCellValue(row.Comment);

            rowIndex++;

            if (row.Threads == null || !row.Threads.Any()) continue;
            foreach (var thread in row.Threads)
            {
                if (thread.Comments == null) continue;
                foreach (var threadComment in thread.Comments)
                {
                    var dataComment = sheet.CreateRow(rowIndex);

                    dataComment.CreateCell(0).SetCellValue("");
                    dataComment.CreateCell(1).SetCellValue(threadComment.AuthorName);
                    dataComment.CreateCell(2).SetCellValue(threadComment.PublishedDate);
                    dataComment.CreateCell(3).SetCellValue(threadComment.Content);

                    rowIndex++;
                }
            }
        }
    }

    #endregion

    #region ParseMonitorJobs

    public static void ParseMonitorJobs(this IReportService _)
    {
        var monitorJobs = Settings.MonitorBranchSpec.Jobs;
        monitorJobs.ForEach(
            o => { Console.WriteLine($"{o.Subject} ... success:{_.ParseMonitorJob(o)}"); });
    }

    public static bool ParseMonitorJob(this IReportService _, MonitorJob job)
    {
        var html = new StringBuilder();
        job.Sections.ForEach(o => { html.AppendLine(_.RenderMonitorSection(o)); });

        return _.SendMail(job.Subscribed, null, job.Subject, html.ToString());
    }

    static string RenderMonitorSection(this IReportService _, MonitorSection section)
    {
        var records = _.Tfvc.GetBranchSpecMonitorRecords(section);
        return section.RenderMonitorSectionHtml(records);
    }

    public static string RenderMonitorSectionHtml(this MonitorSection section, List<MonitorRecord> records)
    {
        var sb = new StringBuilder();
        sb.Append($"<h3>{section.SectionName}</h3>");
        sb.AppendLine(
            "<table  align=\"center\" cellpadding=\"0\" cellspacing=\"2\" style=\"background-color: #666; width: 600px; font-size: 14px; font-family: 'Microsoft YaHei'; \">");

        sb.AppendLine(
            $"<tr><td style='width:30%;padding:5px;background-color:#FFF;font-weight:bold;'>Dependency</td><td style='width:30%;padding:5px;background-color:#FFF;font-weight:bold;'>{section.Target.Key}</td>");

        foreach (var jobGuideline in section.Guidelines)
        {
            sb.Append($"<td style='padding:5px;background-color:#FFF;font-weight:bold'>{jobGuideline.Key}</td>");
        }

        sb.Append("</tr>");

        records.Where(o => o.NotSame)
            .ToList()
            .ForEach(
                o =>
                {
                    sb.Append(
                        $"<tr><td style='padding:5px;background-color:#FFF;font-weight:bold'>{o.Name}</td><td style='padding:5px;background-color:#FFF'>{o.Version}</td>");

                    foreach (var jobGuideline in section.Guidelines)
                    {
                        if (o.GuidelineVersions.ContainsKey(jobGuideline.Key))
                        {
                            sb.Append(
                                $"<td style='padding:5px;background-color:#FFF'>{o.GuidelineVersions[jobGuideline.Key]}</td>");
                        }
                        else
                        {
                            sb.Append("<td style='padding:5px;background-color:#FFF'>&nbsp;</td>");
                        }
                    }

                    sb.Append("</tr>");
                }
            );

        sb.AppendLine("</table>");

        sb.AppendLine("<br/><br/><div style=\"font-size: 12px; font-family: 'Microsoft YaHei';\">");
        sb.AppendLine(
            $" <a href='https://demeter.healthcare.siemens.com/tfs/CT/CTS/_versionControl?path={section.Target.Value}' target='_blank' style='color:#AAA;'>{section.Target.Key} ; {section.Target.Value}</a><br/>");
        foreach (var jobGuideline in section.Guidelines)
        {
            sb.AppendLine(
                $" <a href='https://demeter.healthcare.siemens.com/tfs/CT/CTS/_versionControl?path={jobGuideline.Value}' target='_blank' target='_blank' style='color:#AAA;text-decoration:none;'>{jobGuideline.Key} ; {jobGuideline.Value}</a><br/>");
        }

        sb.AppendLine("</div>");

        return sb.ToString();
    }

    #endregion

    public static bool ParseBuildReport(this IReportService _, ReportDefine reportDefine)
    {
        return _.SendMail(reportDefine.Subscribed, reportDefine.CC, reportDefine.Subject,
            _.RenderBuildReportHtml(reportDefine));
    }

    public static string RenderBuildReportHtml(this IReportService _, ReportDefine reportDefine)
    {
        var sb = new StringBuilder();        
        sb.AppendLine(@"<style>
.issuesTable table tr td:first-child{width:80px;}
            .Succeeded {
                color: #22B14C;
            }
            .PartiallySucceeded {
                color: #FFC90E;
            }
            .Failed {
                color: #ED1C24;
            }
        </style>");
        reportDefine.Sections
            .AsParallel()
            .ForAll(o =>
            {
                switch (o.Type)
                {
                    case BuildReportType.Definition:
                        o.Html=new ReportSectionForDefinition(o).GenerateHtml(_);
                        break;
                    case BuildReportType.WorkItems:
                        o.Html = new ReportSectionForWorkItems(o).GenerateHtml(_);
                        break;
                }
            });

        reportDefine.Sections.ForEach(o => { sb.AppendLine(o.Html); });
        
        return sb.ToString();
    }
}

