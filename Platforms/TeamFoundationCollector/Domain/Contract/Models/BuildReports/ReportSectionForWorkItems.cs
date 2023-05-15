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

}