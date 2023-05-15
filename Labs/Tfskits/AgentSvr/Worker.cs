using Ban3.Infrastructures.Common.Extensions;
using Ban3.Platforms.TeamFoundationCollector.Application.CollectAndReport;
using Ban3.Platforms.TeamFoundationCollector.Application.CollectAndReport.Extensions;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Extensions;
using log4net;

namespace Ban3.Labs.TeamFoundationCollector.Presentation.AgentSvr
{
    public class Worker : BackgroundService
    {
        static readonly ILog _logger = LogManager.GetLogger(typeof(Worker));
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                new Action(() =>
                {
                    _logger.Debug($"start timer job : SyncTfvc");
                    DevOps.Collector.SyncTfvc();
                }).CreateTimer(1000*60*30);
            }
        }
    }
}