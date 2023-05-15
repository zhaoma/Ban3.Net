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

}