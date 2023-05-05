using Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces.Functions;

namespace Ban3.Platforms.TeamFoundationCollector.Domain.Contract.Interfaces;

public interface IReportService
{
    IBuild Build { get; set; }

    ICore Core { get; set; }
    IDiscussion Discussion { get; set; }
    IPipelines Pipelines { get; set; }
    ITfvc Tfvc { get; set; }
}
