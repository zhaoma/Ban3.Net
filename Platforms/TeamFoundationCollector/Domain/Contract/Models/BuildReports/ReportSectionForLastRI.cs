using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Extensions;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using NPOI.SS.Formula.Functions;
using System.Text;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models.BuildReports;

public class ReportSectionForLastRI
    : ReportSection
{
    public ReportSectionForLastRI(int rank, string subject,string itemPath,string keyword,int days)
    {
        Rank = rank;
        ItemPath = itemPath;
        Keyword= keyword;
        Type = BuildReportType.LastRI;
        Subject = subject;
        Days = days;
    }

    public ReportSectionForLastRI(ReportSection reportSection)
    {
        Rank = reportSection.Rank;
        ItemPath = reportSection.ItemPath;
        Keyword = reportSection.Keyword;
        Type = reportSection.Type;
        Subject = reportSection.Subject;
        Days = reportSection.Days;
    }

}