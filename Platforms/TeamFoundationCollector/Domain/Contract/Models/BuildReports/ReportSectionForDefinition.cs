using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Extensions;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using System.Text;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models.BuildReports;

public class ReportSectionForDefinition
    : IReportSection
{
    public ReportSectionForDefinition(int rank,int definitionId, string subject)
    {
        Rank = rank;
        DefinitionId = definitionId;
        Type = BuildReportType.Definition;
        Subject = subject;
    }
    public int Rank { get; set; }

    public string Subject { get; set; }

    public BuildReportType Type { get; set; }

    public int DefinitionId { get; set; }

    public string Html { get; set; } = string.Empty;

    public void GenerateHtml(IReportService reportService)
    {
        var sb = new StringBuilder();
        var build = reportService.Build.GetLastBuildForDefinition(DefinitionId);
        var d = reportService.Build.LoadDefinitionRefs()
            .FindLast(o => o.Id == DefinitionId);

        if (build != null && d != null)
        {
            sb.AppendLine("<table align=\"center\" cellpadding=\"0\" cellspacing=\"2\" style=\"width:100%;font-size: 14px; font-family: 'Microsoft YaHei';\">");

            sb.Append($"<tr><td style=padding:5px;font-size:18px;font-weight:bold;'><a href='https://demeter.healthcare.siemens.com/tfs/CT/CTS/_build/results?buildId={build.Id}&view=results' style='color:#000;text-decoration:none;' target='_blank'>{d.Name}</a></td>" +
                      $"<td style=''width:20%;padding:5px;font-size:18px;font-weight:bold;'><a href='https://demeter.healthcare.siemens.com/tfs/CT/CTS/_build/results?buildId={build.Id}&view=results' class='{build.Result}' target='_blank'>{build.Result}</a></td>" +
                      $"<td style='width:10%;padding:5px;'>{build.QueueTime.ShowDate()}</td>" +
                      $"<td style='width:10%;padding:5px;'>{build.StartTime.ShowDate()}</td>" +
                      $"<td style='width:10%;padding:5px;'>{build.FinishTime.ShowDate()}</td>" +
                      $"</tr>");

            if (build.Result != BuildResult.Succeeded)
            {
                var artifacts = reportService.Build.ListArtifactsForBuild(build!.Id);
                if (artifacts != null)
                {
                    foreach (var buildArtifactContent in artifacts)
                    {
                        sb.AppendLine($"<tr><td colspan='5' style='padding:5px;'>");
                        sb.AppendLine($"{buildArtifactContent.Content}");
                        sb.AppendLine(
                            $"<a href='{buildArtifactContent.FileLocation}' target='_BLANK'>{buildArtifactContent.FileLocation}</a>");
                        sb.AppendLine($"</td></tr>");
                    }
                }
            }
            sb.Append("</table><br/><br/>");
        }

        Html = sb.ToString();
    }
}