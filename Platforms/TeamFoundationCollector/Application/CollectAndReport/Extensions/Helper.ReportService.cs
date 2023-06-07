using System.Data;
using System.Net;
using System.Text;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.NetMail;
using Ban3.Infrastructures.PlatformInvoke.Entries;
using Ban3.Infrastructures.SpringConfig;
using Ban3.Infrastructures.SpringConfig.Entries;
using Ban3.Platforms.TeamFoundationCollector.Application.CollectAndReport.Interfaces;
using Ban3.Platforms.TeamFoundationCollector.Application.CollectAndReport.Request;
using Ban3.Platforms.TeamFoundationCollector.Application.CollectAndReport.Response;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Entities;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Extensions;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models.BranchSpec;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models.BuildReports;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models.TfvcReports;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Reports;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Response.Reports;
using log4net;
using NPOI.HSSF.UserModel;
using NPOI.SS.Formula.Functions;

namespace Ban3.Platforms.TeamFoundationCollector.Application.CollectAndReport.Extensions;

public static partial class Helper
{
    private static readonly ILog Logger = LogManager.GetLogger(typeof(Helper));

    #region SendEmail

    public static bool SendMail(this IReportService _, List<string>? to, List<string>? cc, string? subject,
        string? mailHtml)
    {
        return new Infrastructures.NetMail.Entries.TargetServer()
            .SendByOutlook(to, cc, subject, mailHtml);
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

        if (result.Rows.Count < (filter.PageNo - 1) * filter.PageSize)
        {
            filter.PageNo = 1;
            result.Filter.PageNo = 1;
        }

        result.PagedRows = result.Rows.Skip((filter.PageNo - 1) * filter.PageSize).Take(filter.PageSize).ToList();

        /*
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
        if (o.Threads != null && o.Threads.Any())
        {
            o.Threads.ForEach(x =>
            {
                x.Code = _.Tfvc.GetItem(o.ReportRef, o.FileId, x.Properties);
            });
        }

    });
        */

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
            && (o.Comment.StringExists(filter.Keyword) || o.Threads.ThreadsHasKeywords(filter.Keyword))
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
    
    /// && !cs.All(x=>x.Value.Comment.IsIgnored()
    public static bool TeamHasChangesets(this WebApiTeam team)
    {
        return team.Members != null
               && team.Members
                   .Any(o =>
                   {
                       var cs = o.Identity?.Id
                           .DataFile<IdentitySummary>()
                           .ReadFileAs<IdentitySummary>()?
                           .Changesets;
                       return cs != null && cs.Any();
                   });
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
        var monitorJobs = Domain.Contract.Settings.MonitorBranchSpec.Jobs;
        monitorJobs.ForEach(
            o => { Logger.Debug($"{o.Subject} ... success:{_.ParseMonitorJob(o)}"); });
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

    #region BuildReport

    public static bool ParseBuildReport(this IReportService _, ReportDefine reportDefine)
    {
        var mailBody = _.RenderBuildReportHtml(reportDefine);

        mailBody =
            $"<div style='padding:20px;margin:0 auto;background-color:rgb(194, 189, 189);'><div style='width:900px;background: #fff; table-layout:fixed;'>{mailBody}</div></div>";

        return _.SendMail(reportDefine.Subscribed, reportDefine.CC, reportDefine.Subject, mailBody);
    }

    public static string RenderBuildReportHtml(this IReportService _, ReportDefine reportDefine)
    {
        var sb = new StringBuilder();
        sb.AppendLine(@"<style>
            .issuesTable table tr td:first-child{width:80px;}
            .Succeeded {color: #22B14C;}
            .PartiallySucceeded {color: #FFC90E;}
            .Failed {color: #ED1C24; }
            .fileName{word-break: break-all;word-wrap: break-word;}
        </style>");
        reportDefine.Sections
            .AsParallel()
            .ForAll(o =>
            {
                switch (o.Type)
                {
                    case BuildReportType.Definition:
                        o.Html = _.GenerateHtml(new ReportSectionForDefinition(o));
                        break;
                    case BuildReportType.WorkItems:
                        o.Html = _.GenerateHtml(new ReportSectionForWorkItems(o));
                        break;
                    case BuildReportType.LastRI:
                        o.Html = _.GenerateHtml(new ReportSectionForLastRI(o));
                        break;
                }
            });

        reportDefine.Sections
            .OrderBy(o => o.Rank)
            .ToList()
            .ForEach(o => { sb.AppendLine(o.Html); });

        return sb.ToString();
    }

    public static string GenerateHtml(this IReportService reportService, ReportSectionForLastRI section)
    {
        var lc = reportService.Tfvc.GetLatestRIChangesetRef(section.Days, section.ItemPath, section.Keyword);
        if (lc != null)
        {
            return
                $"<div style='width:50%;padding:5px;font-size:18px;font-weight:bold;'>Latest RI Time : <a href='https://demeter.healthcare.siemens.com/tfs/CT/CTS/_versionControl/changeset/{lc.ChangesetId}/' style='color:#000;text-decoration:underline;' target='_blank'>{lc.CreatedDate}</a><br/><br/></div>";
        }

        return string.Empty;
    }

    public static string GenerateHtml(this IReportService reportService, ReportSectionForDefinition section)
    {
        var sb = new StringBuilder();
        var build = reportService.Build.GetLastBuildForDefinition(section.DefinitionId);
        var d = reportService.Build.LoadDefinitionRefs()
            .FindLast(o => o.Id == section.DefinitionId);

        if (build != null && d != null)
        {
            sb.AppendLine(
                "<table align=\"center\" cellpadding=\"0\" cellspacing=\"2\" style=\"width:100%;font-size: 14px; font-family: 'Microsoft YaHei';\">");

            sb.Append(
                $"<tr><td style='width:50%;padding:5px;font-size:18px;font-weight:bold;'><a href='https://demeter.healthcare.siemens.com/tfs/CT/CTS/_build/results?buildId={build.Id}&view=results' style='color:#000;text-decoration:none;' target='_blank'>{d.Name}</a></td>" +
                $"<td style=''width:20%;padding:5px;font-size:18px;font-weight:bold;'><a href='https://demeter.healthcare.siemens.com/tfs/CT/CTS/_build/results?buildId={build.Id}&view=results' class='{build.Result}' target='_blank'>{build.Result}</a></td>" +
                $"<td style='width:15%;padding:5px;'>{build.StartTime.ShowDate()}</td>" +
                $"<td style='width:15%;padding:5px;'>{build.BuildDuration()}</td>" +
                $"</tr>");

            if (build.Result != BuildResult.Succeeded)
            {
                var artifacts = reportService.Build.ListArtifactsForBuild(build.Id);
                if (artifacts != null)
                {
                    var index = 1;
                    foreach (var buildArtifactContent in artifacts)
                    {
                        sb.AppendLine($"<tr><td colspan='4' style='padding:5px;'>");
                        sb.AppendLine($"{index}:{buildArtifactContent.Content}");
                        sb.AppendLine(
                            $"<a href='file:{buildArtifactContent.FileLocation}' target='_top'>{buildArtifactContent.FileLocation}</a>");
                        sb.AppendLine($"</td></tr>");

                        index++;
                    }
                }

                var issues = reportService.Build.GetBuildIssues(build.Id);
                if (!string.IsNullOrEmpty(issues) && issues.Length <= 1024)
                {
                    sb.AppendLine(
                        $"<tr><td colspan='4' style='padding:5px;word-break: break-all;word-wrap: break-word;' class='issuesTable'>{issues}</td></tr>");
                }
            }

            sb.Append("</table><br/><br/>");
        }

        return sb.ToString();
    }

    public static string GenerateHtml(this IReportService reportService, ReportSectionForWorkItems section)
    {
        var sb = new StringBuilder();

        var queryResult = reportService.WorkItemTracking.Query(section.Sql);
        if (queryResult is { Success: true, WorkItems: { }, Columns: { } })
        {
            var listWorkItemsResult = reportService.WorkItemTracking.ListWorkItems(
                queryResult.WorkItems?.Select(o => o.Id!.Value)!,
                queryResult.Columns?.Select(o => o.ReferenceName)!
            );

            var table = queryResult.GetWorkItemsDataTable(listWorkItemsResult);
            if (table is { Rows.Count: > 0 })
            {
                var ws = new[] { "width:8%", "width:12%", "width:45%", "width:15%", "width:8%", "width:12%" };
                sb.AppendLine(
                    "<div class=\"card\"><div class='table-responsive'><table class='table table-vcenter card-table table-striped' align=\"center\" cellpadding=\"0\" cellspacing=\"2\" style=\"width:100%;background-color: #666; font-size: 14px; font-family: 'Microsoft YaHei';\"><thead><tr>");
                var colIndex = 0;
                foreach (DataColumn col in table.Columns)
                {
                    sb.Append($"<th style='padding:5px;{ws[Math.Min(ws.Length - 1, colIndex)]}'>{col.ColumnName}</th>");
                    colIndex++;
                }

                sb.Append("</tr></thead><tbody>");

                foreach (DataRow row in table.Rows)
                {
                    sb.Append("<tr>");
                    var id = table.Columns.Contains("Id") ? Convert.ToInt32(row["Id"]) : 0;
                    foreach (DataColumn col in table.Columns)
                    {
                        if (id > 0)
                        {
                            sb.Append(
                                $"<td style='padding:5px;background-color: #FFF' class='fileName'><a href='https://demeter.healthcare.siemens.com/tfs/CT/CTS/_workitems/edit/{id}/' style='color:#333;' target='_blank'>{row[col.ColumnName]}</a></td>");
                        }
                        else
                        {
                            sb.Append(
                                $"<td style='padding:5px;background-color: #FFF'>{row[col.ColumnName]}</td>");
                        }
                    }

                    sb.Append("</tr>");
                }

                sb.AppendLine("</tbody></table></div></div><br/><br/>");
            }
        }

        return sb.ToString();
    }

    #endregion

    #region dlls/xmls

    public static void AppendDllRoads(this Dictionary<string, List<string>> dic, List<string[]> roads)
    {
        foreach (var road in roads)
        {
            var roadString = string.Join("->", road);

            var dll = road.Last();
            if (dic.ContainsKey(dll))
            {
                if (!dic[dll].Contains(roadString))
                {
                    dic[dll].Add(roadString);
                }
            }
            else
            {
                dic.Add(dll, new List<string> { roadString });
            }
        }
    }

    public static void AppendXmlRoads(this Dictionary<string, List<string>> dic,
        List<string[]> roads,
        List<SpringXml> allXml,
        List<AliasObject> alias,
        List<Declare> declares)
    {
        foreach (var road in roads)
        {
            var roadString = string.Join("->", road);
            var xml = allXml.FindLast(o => o.FilePath == road[road.Length - 1]);

            var assemblies = xml.GetAssemblies(alias, declares);
            if (assemblies != null)
            {
                foreach (var a in assemblies)
                {
                    if (string.IsNullOrEmpty(a)) continue;
                    var dll = a.AssemblyName();

                    if (dic.ContainsKey(dll))
                    {
                        if (!dic[dll].Contains(roadString))
                        {
                            dic[dll].Add(roadString);
                        }
                    }
                    else
                    {
                        dic.Add(dll, new List<string> { roadString });
                    }
                }
            }
        }
    }

    #endregion

    #region Analyze

    public static AnalyzeReferencesResult GetResult(this IReportService reportService, AnalyzeReferences? request)
    {
        var result = new AnalyzeReferencesResult
        {
            AssemblyFilesFromSpringConfigs = new Dictionary<string, List<string>>(),
            AssemblyFilesFromDependencies = new Dictionary<string, List<string>>(),
            Request = request!,
            Proposals = new Dictionary<string, string>()
        };

        var assemblies = Infrastructures.PlatformInvoke.Helper.Load()
            .Where(o => o.Name.StartsWith(result.Request.AssembliesStartWith))
            .ToList();

        if (assemblies.Any())
        {
            var allDlls = Infrastructures.PlatformInvoke.Helper.Load();
            foreach (var dll in assemblies)
            {
                var roads = Infrastructures.PlatformInvoke.Helper.AllLowerLevels(dll.Name, allDlls);
                result.AssemblyFilesFromDependencies.AppendList(roads.UnionAll().ToList(), dll.Name);
            }
        }

        var springConfig = Infrastructures.SpringConfig.Helper.LoadConfigs()
            .FindLast(o => o.FileName == result.Request.SpringConfigFile);

        if (springConfig != null)
        {
            var configs = new List<SpringXml> { springConfig }
                .ExpandWithImports();
            
            var allXmls = Infrastructures.SpringConfig.Helper.LoadConfigs();
            var allDeclares = Infrastructures.SpringConfig.Helper.LoadDeclares();
            var allAlias = Infrastructures.SpringConfig.Helper.LoadAlias();

            var xmlRoads= Infrastructures.SpringConfig.Helper.AllLowerLevels(springConfig.FilePath, allXmls);

            configs.ForEach(c =>
            {
                var dlls = c.GetAssemblies(allAlias, allDeclares)
                    .Where(o=>!string.IsNullOrEmpty(o))
                    .Select(o => o.AssemblyName()).ToList();
                result.AssemblyFilesFromSpringConfigs.AppendList(dlls, c.FilePath
                );

                if (dlls.All(o => !result.AssemblyFilesFromDependencies.ContainsKey(o)))
                {
                    var level1 = springConfig.Imports.Any(o =>Path.GetFileName(o)==c.FileName) ? true : false;
                    var desc = level1? $"at root imports":"in imports";

                    if (!level1)
                    {
                        desc = "<ol>";
                        var rs = xmlRoads.FindAll(o => o.Any(x=>Path.GetFileName(x)==c.FileName)).ToList();
                        rs.ForEach(o =>
                        {
                            desc += $"<li>{string.Join("<br/>", o.Select(f=>Path.GetFileName(f)))}</li>";
                        });
                        desc += "</ol>";
                    }

                    result.Proposals.Add(c.FileName, desc);
                }
            });
        }



        return result;
    }

    #endregion
}

