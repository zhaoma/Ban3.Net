using Ban3.Infrastructures.Common.Extensions;
using Ban3.Platforms.TeamFoundationCollector.Application.CollectAndReport;
using Ban3.Platforms.TeamFoundationCollector.Application.CollectAndReport.Extensions;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Extensions;
using log4net;

namespace Ban3.Labs.TeamFoundationCollector.Presentation.AgentSvr
{
    public class Worker : BackgroundService
    {
        static readonly ILog Logger = LogManager.GetLogger(typeof(Worker));

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            new Action(() =>
            {
                Logger.Info($"start timer job : SyncTfvc");
                DevOps.Collector.SyncTfvc();
            }).CreateTimer(1000 * 60 * 60);


            while (!stoppingToken.IsCancellationRequested)
            {
            }
        }
    }
}