using Ban3.Platforms.TeamFoundationCollector.Application.CollectAndReport.Interfaces;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;

namespace Ban3.Platforms.TeamFoundationCollector.Application.CollectAndReport;

public  class DevOps
{
    public static ICollectService Collector { get; set; } = new CollectService();

    public static IReportService Reportor = new ReportService();


}