using Ban3.Platforms.TeamFoundationCollector.Application.CollectAndReport.Request;
using Ban3.Platforms.TeamFoundationCollector.Application.CollectAndReport.Response;
using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces.Functions;

namespace Ban3.Platforms.TeamFoundationCollector.Application.CollectAndReport.Interfaces;

public interface IReportService
{
    IBuild Build { get; set; }

    ICore Core { get; set; }

    IDiscussion Discussion { get; set; }

    IPipelines Pipelines { get; set; }

    ITfvc Tfvc { get; set; }

    IWorkItemTracking WorkItemTracking { get; set; }

    QueryAnythingResult QueryAnything(QueryAnything request);



    GetRelationsResult GetRelations(GetRelations request);
}
