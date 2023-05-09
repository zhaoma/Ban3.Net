using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces.Functions;
using Ban3.Platforms.TeamFoundationCollector.Application.CollectAndReport.Functions;

namespace Ban3.Platforms.TeamFoundationCollector.Application.CollectAndReport;

/// <summary>
/// not in use
/// </summary>
public class CollectService
    : ICollectService
{
    public IBuild Build { get; set; } = new Build();

    public ICore Core { get; set; } = new Core();

    public IDiscussion Discussion { get; set; } = new Discussion();

    public IPipelines Pipelines { get; set; } = new Pipelines();

    public ITfvc Tfvc { get; set; } = new Tfvc();

    public IWorkItemTracking WorkItemTracking { get; set; } = new WorkItemTracking();
}
