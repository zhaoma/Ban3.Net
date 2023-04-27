using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Response.Build;

public class GetReportResult
    : IResponse
{
    public bool Success { get; set; }

    public string Html { get; set; } = string.Empty;
}