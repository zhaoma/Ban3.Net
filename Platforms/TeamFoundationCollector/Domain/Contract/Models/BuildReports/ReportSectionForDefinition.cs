using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Extensions;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using NPOI.SS.Formula.Functions;
using System.Text;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models.BuildReports;

public class ReportSectionForDefinition
    : ReportSection
{
    public ReportSectionForDefinition(int rank,int definitionId, string subject)
    {
        Rank = rank;
        DefinitionId = definitionId;
        Type = BuildReportType.Definition;
        Subject = subject;
    }

    public ReportSectionForDefinition(ReportSection reportSection)
    {
        Rank = reportSection.Rank;
        DefinitionId = reportSection.DefinitionId;
        Type = reportSection.Type;
        Subject = reportSection.Subject;
    }

    public override string GenerateHtml(IReportService reportService)
    {
        var sb = new StringBuilder();
        var build = reportService.Build.GetLastBuildForDefinition(DefinitionId);
        var d = reportService.Build.LoadDefinitionRefs()
            .FindLast(o => o.Id == DefinitionId);

        if (build != null && d != null)
        {
            sb.AppendLine("<table align=\"center\" cellpadding=\"0\" cellspacing=\"2\" style=\"width:100%;font-size: 14px; font-family: 'Microsoft YaHei';\">");

            sb.Append($"<tr><td style='width:50%;padding:5px;font-size:18px;font-weight:bold;'><a href='https://demeter.healthcare.siemens.com/tfs/CT/CTS/_build/results?buildId={build.Id}&view=results' style='color:#000;text-decoration:none;' target='_blank'>{d.Name}</a></td>" +
                      $"<td style=''width:20%;padding:5px;font-size:18px;font-weight:bold;'><a href='https://demeter.healthcare.siemens.com/tfs/CT/CTS/_build/results?buildId={build.Id}&view=results' class='{build.Result}' target='_blank'>{build.Result}</a></td>" +
                      $"<td style='width:15%;padding:5px;'>{build.StartTime.ShowDate()}</td>" +
                      $"<td style='width:15%;padding:5px;'>{build.BuildDuration()}</td>" +
                      $"</tr>");

            if (build.Result != BuildResult.Succeeded)
            {
                var artifacts = reportService.Build.ListArtifactsForBuild(build!.Id);
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
                if (!string.IsNullOrEmpty(issues)&&issues.Length<= 1024)
                {
                    sb.AppendLine($"<tr><td colspan='4' style='padding:5px;word-break: break-all;word-wrap: break-word;' class='issuesTable'>{issues}</td></tr>");
                }
            }
            sb.Append("</table><br/><br/>");
        }

        return sb.ToString();
    }
}