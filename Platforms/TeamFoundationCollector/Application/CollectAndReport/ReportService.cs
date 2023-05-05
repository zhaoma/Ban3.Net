using Ban3.Platforms.TeamFoundationCollector.Application.CollectAndReport.Functions;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces.Functions;

namespace Ban3.Platforms.TeamFoundationCollector.Application.CollectAndReport
{
    public class ReportService
        : IReportService
    {
        public IBuild Build { get; set; } = new Build();

        public ICore Core { get; set; } = new Core();

        public IDiscussion Discussion { get; set; } = new Discussion();

        public IPipelines Pipelines { get; set; } = new Pipelines();

        public ITfvc Tfvc { get; set; } = new Tfvc();
    }
}