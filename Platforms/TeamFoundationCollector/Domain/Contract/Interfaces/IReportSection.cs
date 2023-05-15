using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Enums;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;

public interface IReportSection
{
    int Rank { get; set; }

    string Subject { get; set; }

    BuildReportType Type { get; set; }

    string Html { get; set; }
}