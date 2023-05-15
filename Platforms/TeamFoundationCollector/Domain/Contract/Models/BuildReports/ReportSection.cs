using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Models.BuildReports;

public class ReportSection:IReportSection
{
    public int Rank { get; set; }

    public string Subject { get; set; } = string.Empty;

    public BuildReportType Type { get; set; }

    public int DefinitionId { get; set; }

    public string Sql { get; set; } = string.Empty;

    public string Html { get; set; } = string.Empty;
}