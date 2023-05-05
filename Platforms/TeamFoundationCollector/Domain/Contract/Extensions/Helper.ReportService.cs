using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.NetMail;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models.BranchSpec;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Request.Reports;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Response.Reports;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Extensions;

public static partial class Helper
{
    #region SendEmail

    public static bool SendMail(this IReportService _,List<string>? to,List<string>? cc,string? subject , string? mailHtml)
    {
        new Ban3.Infrastructures.NetMail.Entries.TargetServer()
            .SendByOutlook(to, cc, subject, mailHtml);
        return true;
    }

    #endregion

    public static TfvcFilterResult GetTfvcReport(this IReportService _, TfvcFilter filter)
    {
        var result = new TfvcFilterResult { Filter = filter };



        return result;
    }

    #region ParseMonitorJobs

    public static bool ParseMonitorJob(this IReportService _, MonitorJob job)
    {
        var html = new StringBuilder();
        job.Sections.ForEach(o =>
        {
            html.AppendLine(_.RenderMonitorSection(o));
        });

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
        sb.AppendLine("<table  align=\"center\" cellpadding=\"0\" cellspacing=\"2\" style=\"background-color: #666; width: 600px; font-size: 14px; font-family: 'Microsoft YaHei'; \">");

        sb.AppendLine(
            $"<tr><td style='padding:5px;background-color:#FFF;font-weight:bold;'>Dependency</td><td style='padding:5px;background-color:#FFF;font-weight:bold;'>{section.Target.Key}</td>");

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
                    sb.Append($"<tr><td style='padding:5px;background-color:#FFF;font-weight:bold'>{o.Name}</td><td style='padding:5px;background-color:#FFF'>{o.Version}</td>");

                    foreach (var jobGuideline in section.Guidelines)
                    {
                        if (o.GuidelineVersions.ContainsKey(jobGuideline.Key))
                        {
                            sb.Append($"<td style='padding:5px;background-color:#FFF'>{o.GuidelineVersions[jobGuideline.Key]}</td>");
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
            sb.AppendLine($" <a href='https://demeter.healthcare.siemens.com/tfs/CT/CTS/_versionControl?path={jobGuideline.Value}' target='_blank' target='_blank' style='color:#AAA;text-decoration:none;'>{jobGuideline.Key} ; {jobGuideline.Value}</a><br/>");
        }
        sb.AppendLine("</div>");

        return sb.ToString();
    }

    #endregion
}

